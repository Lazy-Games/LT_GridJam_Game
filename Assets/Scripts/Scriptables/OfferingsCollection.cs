using HexGridGame.DataModels;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexGridGame.Scriptables
{
    [CreateAssetMenu(fileName = "OfferingsCollection", menuName = "ScriptableObjects/OfferingsCollection", order = 3)]
    public class OfferingsCollection : ScriptableObject
    {
        [SerializeField] private List<Offering> _offerings;

        public List<Offering> Offerings { get => _offerings; set => _offerings = value; }
    }
}
