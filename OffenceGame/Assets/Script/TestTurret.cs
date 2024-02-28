using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class TestTurret : Turret
{
    protected override void Init()
    {
        base.Init();
        bps = 1.5f;
        targetingRange = 3;
    }

    protected override void Attack()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        bulletScript.SetTarget(target);
    }
    public void OnMouseEnter()
    {
        turretRangeObj.localScale = new Vector3(3.65f * targetingRange, 4.4f * targetingRange, 1f);
        turretRangeObj.gameObject.SetActive(true);

    }


    public void OnMouseExit()
    {
        turretRangeObj.gameObject.SetActive(false);
    }
    public void OnMouseDown()
    {

    }
}
