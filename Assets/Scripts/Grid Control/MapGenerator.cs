using HexGridGame.Scriptables;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using Random = System.Random;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private GameObject grid;
    [SerializeField] private HexTile tilePrefab;
    [SerializeField] private int testGridSize;
    [SerializeField] private float tileSize = 1.5f;
    [SerializeField] private CustomMap customMap;

    [ContextMenu("Create Map With Custom Data")]
    private void CreateMapWithCustomData()
    {
        if(customMap == null) { return; }

        foreach (var dataZone in customMap.CustomMapDataZones)
        {
            Debug.Log("Generation of Custom Map Part: " + dataZone.ZoneKeyname);
            Queue<BiomeType> biomesQueue = GenerateFillingBiomes(dataZone.automaticTilesSettings);
            Dictionary<int, MountainStatus> zoneMountainsState = GenerateMountainsStatus(dataZone.amountOfMountains);

            foreach (var dataZoneRow in dataZone.customMapDataZoneRows)
            {
                HexCoord startingCoord = dataZoneRow.startingRowCoords;
                for (int i = 0; i < dataZoneRow.CustomMapTiles.Count; i++)
                {
                    int q = startingCoord.q + i;
                    int r = startingCoord.r;
                    int s = startingCoord.s - i;
                    HexCoord tileCoord = new HexCoord(q, r, s);

                    MapTileDataType mapTileDataType = dataZoneRow.CustomMapTiles[i].tileDataType;
                    BiomeType biomeType = dataZone.automaticTilesSettings.defaultBiome;
                    int mountainRollSubzone = dataZoneRow.CustomMapTiles[i].mountainRollSubzone;

                    if (mapTileDataType == MapTileDataType.Automatic)
                    {
                        biomeType = GetAutomaticBiomeType(dataZone.amountOfMountains, dataZoneRow.CustomMapTiles.Count, i,
                            biomesQueue, zoneMountainsState, biomeType, mountainRollSubzone);
                    }
                    else if (mapTileDataType == MapTileDataType.Ocean)
                    {
                        biomeType = BiomeType.Ocean;
                    }
                    else if (mapTileDataType == MapTileDataType.PlayersSpawn)
                    {
                        biomeType = BiomeType.PlayersSpawn;
                    }
                    else if (mapTileDataType == MapTileDataType.PlayersGoal)
                    {
                        biomeType = BiomeType.PlayersGoal;
                    }

                    GenerateTile(tileCoord, biomeType);
                }
            }
        }
    }

    private BiomeType GetAutomaticBiomeType(int amountOfMountains, int tilesRowCount, int currentTileRowIndex,
        Queue<BiomeType> biomesQueue, Dictionary<int, MountainStatus> zoneMountainsState, BiomeType biomeType, int mountainRollSubzone)
    {
        // If automatic and its at the edges of a row - will always be ocean
        if (currentTileRowIndex == 0 || currentTileRowIndex == tilesRowCount - 1)
        {
            biomeType = BiomeType.Ocean;
        }
        else if (amountOfMountains > 0 && mountainRollSubzone > 0)
        {
            MountainStatus mountainStatus = zoneMountainsState[mountainRollSubzone];
            if (mountainStatus.alreadyFilled == false)
            {
                if (mountainStatus.countOfSpawned >= mountainStatus.randomTileToSpawn)
                {
                    mountainStatus.alreadyFilled = true;
                    biomeType = BiomeType.Mountain;
                }
                else
                {
                    mountainStatus.countOfSpawned = mountainStatus.countOfSpawned + 1;
                    if (biomesQueue.Count > 0) { biomeType = biomesQueue.Dequeue(); }
                }
                zoneMountainsState[mountainRollSubzone] = mountainStatus;
            }
            else
            {
                if (biomesQueue.Count > 0) { biomeType = biomesQueue.Dequeue(); }
            }
        }
        else
        {
            if (biomesQueue.Count > 0) { biomeType = biomesQueue.Dequeue(); }
        }

        return biomeType;
    }

    private HexTile GenerateTile(HexCoord coord, BiomeType biomeType)
    {
        HexTile tile = Instantiate(tilePrefab, grid.transform);
        tile.SetTileCoordinates(coord);
        tile.SetTileBiome(biomeType);
        tile.transform.position = GetPointyTopPositionFromCoord(coord);

        return tile;
    }

    private Vector3 GetPointyTopPositionFromCoord(HexCoord coord)
    {
        float q = coord.q;  
        float r = coord.r;
        float s = coord.s;

        float horizontal = MathF.Sqrt(3f) * tileSize;  
        float vertical = (3f / 2f) * tileSize;
        float x = (q - s) / 2f * horizontal;
        float y = -r * vertical;

        return new Vector3(x, y, 0);
    }

    // Not used right now, maybe useful later
    private Vector3 GetFlatTopPositionFromCoord(HexCoord coord)
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


    private static Random rng = new Random();
    private Queue<BiomeType> GenerateFillingBiomes(AutomaticTilesFilling tilesFilling)
    {
        List<BiomeType> biomesList = new List<BiomeType>();
        foreach (var tilesFillingByBiome in tilesFilling.tilesFillingByBiomes)
        {
            for (int i = 0; i < tilesFillingByBiome.amount; i++)
            {
                biomesList.Add(tilesFillingByBiome.biomeType);
            }
        }
        List<BiomeType> suffledBiomes = biomesList.OrderBy(_ => rng.Next()).ToList();
        return new Queue<BiomeType>(suffledBiomes);
    }

    private Dictionary<int, MountainStatus> GenerateMountainsStatus(int amountOfMountains)
    {
        var dictionary = new Dictionary<int, MountainStatus>();
        for (int i = 0; i < amountOfMountains; i++)
        {
            int tileToSpawn = rng.Next(0, 8); // random from 0 to 7
            MountainStatus mountainStatus = new MountainStatus(tileToSpawn);
            dictionary.Add(i + 1, mountainStatus);
        }
        return dictionary;
    }
}

public class MountainStatus
{
    public int randomTileToSpawn;
    public bool alreadyFilled;
    public int countOfSpawned;


    public MountainStatus(int randomTileToSpawn)
    {
        this.randomTileToSpawn = randomTileToSpawn;
        alreadyFilled = false;
        countOfSpawned = 0;
    }
}