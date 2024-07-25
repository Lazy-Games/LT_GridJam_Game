using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class HexTile : MonoBehaviour
{
    [SerializeField] private TMP_Text q;
    [SerializeField] private TMP_Text r;
    [SerializeField] private TMP_Text s;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private HexCoord _position;

    public void Init(HexCoord coord)
    {
        _position = coord;
        q.text = coord.q.ToString();
        r.text = coord.r.ToString();
        s.text = coord.s.ToString();
    }

    public Color hoverColor = Color.red; // The color you want when the mouse is over the sprite
    private Color originalColor;

    void Start()
    {
        originalColor = Color.white;
    }

    void OnMouseOver()
    {
        spriteRenderer.color = hoverColor;
    }

    void OnMouseExit()
    {
        spriteRenderer.color = originalColor;
    }
}
