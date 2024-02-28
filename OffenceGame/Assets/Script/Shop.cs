using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] ShopText[] texts;

    public bool isMenuOpen = false;

    public void ToggleShop()
    {
        isMenuOpen = !isMenuOpen;
        anim.SetBool("IsOpen", isMenuOpen);

        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].name.text = BuildManager.instance.towers[i].name.ToString();
            texts[i].cost.text = BuildManager.instance.towers[i].cost.ToString();
        }
    }
}

[Serializable]
class ShopText
{
    public TextMeshProUGUI name;
    public TextMeshProUGUI cost;
}
