using HexGridGame.DataModels;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexGridGame.Scriptables
{
    [CreateAssetMenu(fileName = "BiomesCollection", menuName = "ScriptableObjects/BiomesCollection", order = 1)]
    public class BiomesCollection : ScriptableObject
    {
        [SerializeField] private List<Biome> biomes;

        public List<Biome> Biomes { get => biomes; set => biomes = value; }
    }
}
