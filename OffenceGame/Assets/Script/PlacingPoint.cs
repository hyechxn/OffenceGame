using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlacingPoint : MonoBehaviour
{
    [Header("컴포넌트")]
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Color selectColor;

    private GameObject canvas;

    private Color baseColor;
    [SerializeField] GameObject placedTurret;

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
        if (placedTurret == null)
        {
            canvas.SetActive(!canvas.activeSelf);
            return;
        }
        //placedTurret.transform.GetChild(0);

    }
}
