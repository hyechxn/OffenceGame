using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public GameObject[] enemies;

    private EnemyCount;
    private void Awake()
    {
        instance = this;
    }

    IEnumerator SpawnEnemy()
    {
        yield return 3f;
        int enemyIndex = Random.Range(0, enemies.Length);
        Instantiate(enemies[enemyIndex]);
            if()
            StartCoroutine(SpawnEnemy());
    }

    public Transform[] path;
    public Transform startPath;
}
