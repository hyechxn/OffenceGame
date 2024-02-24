using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("속성")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private int hitPoint = 2;
    [SerializeField] private int coinWorth = 50;
       
    private bool isDestroyed = false;
    public void TakeDamage(int dmg)
    {
        hitPoint -= dmg;
        if(hitPoint <= 0 && !isDestroyed)
        {
            isDestroyed = true;
            Destroy(gameObject);
        }
    }
}