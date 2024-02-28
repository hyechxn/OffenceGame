using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildManager : MonoBehaviour
{
    private static BuildManager instance;
    private void Awake()
    {
        instance = this;
        canvas = instance.transform.GetChild(0).gameObject;
    }


    [Header("타워")]
    [SerializeField] private Tower[] towers;

    //상점 패널
    private GameObject canvas;

    private int selectedTower = 0;

    public Tower GetSelectedTower()
    {
        return towers[selectedTower];
    }

    public void SetSelectedTower(int selectedTower)
    {
        this.selectedTower = selectedTower;
    }
}
