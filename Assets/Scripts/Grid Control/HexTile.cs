using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using HexGridGame.DataModels;

public class HexTile : MonoBehaviour
{
    [SerializeField] private TMP_Text q;
    [SerializeField] private TMP_Text r;
    [SerializeField] private TMP_Text s;
    [SerializeField] private SpriteRenderer borderSprite;
    [SerializeField] private SpriteRenderer tileSprite;
    [SerializeField] Color hoverColor = Color.red;

    private HexCoord _position;
    private Biome _biome;
    private Color _originalColor = Color.white;

    public void SetTileCoordinates(HexCoord coord)
    {
        _position = coord;
        q.text = coord.q.ToString();
        r.text = coord.r.ToString();
        s.text = coord.s.ToString();
    }

    public void SetTileBiome(BiomeType biomeType)
    {
        var biome = CollectionsReferences.Instance.GetBiomeFromType(biomeType);
        if (biome != null)
        {
            _biome = biome;
            _originalColor = biome.TileColor;
            tileSprite.color = _originalColor;
            borderSprite.color = _originalColor;
        }
    }

    void OnMouseOver()
    {
        borderSprite.color = hoverColor;
    }

    void OnMouseExit()
    {
        borderSprite.color = _originalColor;
    }

    public Biome Biome { get => _biome; set => _biome = value; }
    public HexCoord Position { get => _position; set => _position = value; }
}
