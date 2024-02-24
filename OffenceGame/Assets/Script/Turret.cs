using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public abstract class Turret : MonoBehaviour
{
    //참조
    Transform turretRotation;
    [SerializeField] LayerMask enemyMask;
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected Transform firingPoint;


    //속성 변수
    [SerializeField] private float targetingRange;
    private float rotationSpeed = 200;
    [SerializeField] private float bps; // Bullets Per Second

    //베이스 속성 변수
    private float targetingRangeBase;
    private float bpsBase;

    protected Transform target;
    private float timeUntilAttack;

    private void Start()
    {
        Init();
    }

    protected void Init()
    {
        //bpsBase = bps; 초당 공격횟수 설정 필요!!
        //targetingRangeBase = targetingRange; 사거리 설정 필요!!
        turretRotation = transform.GetChild(0);
    }

    private void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }
        RotateTowardsTarget();

        if (!CheckTargetIsInRange())
        {
            target = null;
        }
        else
        {
            timeUntilAttack += Time.deltaTime;

            if (timeUntilAttack > 1f / bps)
            {
                Attack();
                timeUntilAttack = 0f;
            }
        }
    }
    protected abstract void Attack();
    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)
            transform.position, 0f, enemyMask);

        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }

    private bool CheckTargetIsInRange()
    {
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }

    private void RotateTowardsTarget()
    {
        float angle = Mathf.Atan2(target.position.y- transform.position.y, 
            target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;

        Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);
        turretRotation.rotation = Quaternion.RotateTowards(turretRotation.rotation, targetRotation,
            rotationSpeed * Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }
}
