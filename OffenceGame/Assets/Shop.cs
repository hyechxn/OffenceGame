using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] Animator anim;

    private bool isMenuOpen = false;

    public void TogleShop()
    {
        isMenuOpen = !isMenuOpen;
        anim.SetBool("IsOpen", isMenuOpen);
    }
}
