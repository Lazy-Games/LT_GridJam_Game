using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private GameObject grid;
    [SerializeField] private HexTile tilePrefab;
    [SerializeField] private int testGridSize;
    [SerializeField] private float tileSize = 1.5f;

    private void Start()
    {
        CreateMap();
    }

    private void CreateMap()
    {
        for (int q = -testGridSize; q <= testGridSize; q++)
        {
            for (int r = -testGridSize; r <= testGridSize; r++)
            {
                int s = -q - r;
                if(Math.Abs(s) <= testGridSize)
                {
                    GenerateTile(new HexCoord(q, r, s));
                }
            }
        }
    }

    private void GenerateTile(HexCoord coord)
    {
        HexTile tile = Instantiate(tilePrefab, grid.transform);
        tile.Init(coord);

        // Set position from coord parameter:
        tile.transform.position = GetPositionFromCoord(coord);
    }

    private Vector3 GetPositionFromCoord(HexCoord coord)
    {
        float q = coord.q;  
        float r = coord.r;
        float s = coord.s;
        float horizontal = (3f / 2f) * tileSize;
        float vertical = MathF.Sqrt(3f) * tileSize;

        float x = q * horizontal;
        float y = (s - r) / 2f * vertical;

        return new Vector3(x, y, 0);
    }
}
