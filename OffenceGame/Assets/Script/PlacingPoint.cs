using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlacingPoint : MonoBehaviour
{
    [Header("ÄÄÆ÷³ÍÆ®")]
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Color selectColor;

    private GameObject canvas;

    private Color baseColor;
    private GameObject towerObj;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        baseColor = spriteRenderer.color;
        canvas = transform.GetChild(0).gameObject; 
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
        if (towerObj == null)
        {
            canvas.SetActive(!canvas.activeSelf);
            return;
        }
        //towerObj.transform.GetChild(0);
        
    }
}
