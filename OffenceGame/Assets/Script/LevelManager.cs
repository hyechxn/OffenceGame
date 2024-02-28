using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public GameObject[] enemies;

    public int patternNum;
    private int patternCount = 0;

    private int coin;
    private void Awake()
    {
        instance = this;
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < enemies.Length; i++)
        {
            Instantiate(enemies[i], startPath.position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
        patternCount++;
        if (patternCount < patternNum)
            StartCoroutine(SpawnEnemy());
    }

    public int GetCoin()
    {
        return coin;
    }

    public void SpendCoin(int amount)
    {
        if (coin < amount)
            return;
        coin -= amount;
    }
    public void GainCoin(int amount)
    {
        coin += amount;
    }

    public Transform[] path;
    public Transform startPath;
}
