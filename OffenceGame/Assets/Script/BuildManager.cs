using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private void Awake()
    {
        instance = this;
        canvas = instance.transform.GetChild(0).gameObject;
    }


    public Tower[] towers;
    public Transform selectedPoint;
    public GameObject canvas;

    public void SetSelectedTower(int selectedTower)
    {
        if (LevelManager.instance.GetCoin() > towers[selectedTower].cost)
        {
            LevelManager.instance.SpendCoin(towers[selectedTower].cost);
            selectedPoint.GetComponent<PlacingPoint>().placedTurret =  Instantiate(towers[selectedTower].towerPrefab, selectedPoint.position + new Vector3(0f, 0.1f), Quaternion.identity);
            transform.GetChild(0).GetChild(0).GetComponent<Shop>().ToggleShop();
        }
        else
        {
            Debug.Log("이잉");
        }
    }
}
