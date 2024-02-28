using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Tower
{
    public string name;
    public int cost;
    public GameObject towerPrefab;

    public Tower(string name, int cost, GameObject towerPrefab)
    {
        this.name = name;
        this.cost = cost;
        this.towerPrefab = towerPrefab;
    }
}
