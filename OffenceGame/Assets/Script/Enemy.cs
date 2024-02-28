using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("참조")]
    Rigidbody2D rigid;

    [Header("속성")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private int hitPoint = 2;
    [SerializeField] private int coinWorth = 50;

    private Transform target;
    private int pathIndex;

    private float baseSpeed;

    private bool isDestroyed = false;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        target = LevelManager.instance.path[pathIndex];
        baseSpeed = moveSpeed;
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, target.position) <= 0.1f)
        {
            pathIndex++;
            if (pathIndex >= LevelManager.instance.path.Length)
                return;
            target = LevelManager.instance.path[pathIndex];
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;

        rigid.velocity = direction * moveSpeed;
    }

    public void TakeDamage(int dmg)
    {
        hitPoint -= dmg;
        if (hitPoint <= 0 && !isDestroyed)
        {
            isDestroyed = true;
            Destroy(gameObject);
        }
    }
}