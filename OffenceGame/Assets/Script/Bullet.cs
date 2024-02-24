using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("참조")]
    [SerializeField] private Rigidbody2D rigid;

    [Header("속성")]
    [SerializeField] private float bulletSpeed = 15f;
    [SerializeField] private int bulletDamage = 1;

    public Transform target;
    Vector2 direction;

    private void Start()
    {
        Destroy(gameObject, 5f);
        Invoke("AddForce", 0.01f);
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    private void AddForce()
    {
        if (!target) Invoke("AddForce", 0.01f);

        direction = (target.position - transform.position).normalized;

        rigid.velocity = direction * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            other.transform.GetComponent<Enemy>().TakeDamage(bulletDamage);
        }
        Destroy(gameObject);
    }
}