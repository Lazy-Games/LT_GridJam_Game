using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexGridGame.DataModels
{
    [Serializable]
    public class Biome
    {
        public BiomeType BiomeType;
        public string Name;
        public string Description;
        public Sprite Image;
        public Color TileColor;

        public Biome() { }
    }
}