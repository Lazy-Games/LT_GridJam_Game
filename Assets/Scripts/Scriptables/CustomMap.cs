using HexGridGame.DataModels;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexGridGame.Scriptables
{
    [CreateAssetMenu(fileName = "CustomMap", menuName = "ScriptableObjects/CustomMap", order = 5)]
    [Serializable]
    public class CustomMap : ScriptableObject
    {
        [SerializeField] private List<CustomMapDataZone> customMapDataZones;

        public List<CustomMapDataZone> CustomMapDataZones { get => customMapDataZones; set => customMapDataZones = value; }
    }

    [Serializable]
    public class CustomMapDataZone
    {
        public string ZoneKeyname;
        public List<CustomMapDataZoneRow> customMapDataZoneRows;
        public AutomaticTilesFilling automaticTilesSettings;
        public int amountOfMountains;
    }

    [Serializable]
    public class AutomaticTilesFilling
    {
        public List<TilesFillingByBiome> tilesFillingByBiomes;
        public BiomeType defaultBiome;
    }

    [Serializable]
    public class TilesFillingByBiome
    {
        public BiomeType biomeType;
        public int amount;
    }

    [Serializable]
    public class CustomMapDataZoneRow
    {
        public HexCoord startingRowCoords;
        public List<CustomMapTileData> CustomMapTiles;
    }

    [Serializable]
    public class CustomMapTileData
    {
        public MapTileDataType tileDataType;
        public int mountainRollSubzone;
    }

    [Serializable]
    public enum MapTileDataType
    {
        Automatic,
        Ocean,
        PlayersSpawn,
        PlayersGoal
    }
}
   
