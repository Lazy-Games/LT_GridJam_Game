using HexGridGame.DataModels;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexGridGame.Scriptables
{
    [CreateAssetMenu(fileName = "ResourcesCollection", menuName = "ScriptableObjects/ResourcesCollection", order = 1)]
    public class ResourcesCollection : ScriptableObject
    {
        [SerializeField] private List<Resource> resources;

        public List<Resource> Resources { get => resources; set => resources = value; }
    }
}