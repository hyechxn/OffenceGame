using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTurret : Turret
{
    protected override void Attack()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        bulletScript.SetTarget(target);
    }
}
