using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildManager : MonoBehaviour
{
    [Header("타워")]
    [SerializeField] private Tower[] towers;

    private int selectedTower = 0;


    private static BuildManager instance;
    public static BuildManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new BuildManager();
            }
            return instance;
        }
    }

    public Tower GetSelectedTower()
    {
        return towers[selectedTower];
    }

    public void SetSelectedTower(int selectedTower)
    {
        this.selectedTower = selectedTower;
    }
}
