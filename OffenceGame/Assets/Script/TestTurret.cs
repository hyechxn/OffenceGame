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
        targetingRange = 5;
    }

    protected override void Attack()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        bulletScript.SetTarget(target);
    }
    public void OnMouseEnter()
    {
        spriteRenderer.color = selectColor;
    }


    public void OnMouseExit()
    {
        spriteRenderer.color = baseColor;
    }
    public void OnMouseDown()
    {
        Debug.Log("456");
        turretRangeObj.localScale = new Vector3(3.3f * targetingRange, 4f * targetingRange, 1f);
        turretRangeObj.gameObject.SetActive(!turretRangeObj.gameObject.activeSelf);
        Debug.Log("123");
    }
}
