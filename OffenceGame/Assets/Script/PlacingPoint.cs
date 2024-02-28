using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlacingPoint : MonoBehaviour
{
    [Header("컴포넌트")]
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Color selectColor;

    private Color baseColor;
    [SerializeField] public GameObject placedTurret;

    Shop shop;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        baseColor = spriteRenderer.color;
        shop = BuildManager.instance.transform.GetChild(0).GetChild(0).GetComponent<Shop>();
    }


    public void OnMouseEnter()
    {
        spriteRenderer.color = selectColor;
    }


    public void OnMouseExit()
    {
        spriteRenderer.color = Color.white;
        //canvas.SetActive(false);
    }


    public void OnMouseDown()
    {
        if (placedTurret == null)
        {
            Transform recentPoint = BuildManager.instance.selectedPoint;
            BuildManager.instance.selectedPoint = transform;
            if (recentPoint == BuildManager.instance.selectedPoint)
            {
                shop.ToggleShop();
                return;
            }
            else if(!shop.isMenuOpen)
                shop.ToggleShop();
        }
    }
}
