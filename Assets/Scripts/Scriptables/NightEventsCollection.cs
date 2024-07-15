using HexGridGame.DataModels;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexGridGame.Scriptables
{
    [CreateAssetMenu(fileName = "NightEventsCollection", menuName = "ScriptableObjects/NightEventsCollection", order = 2)]
    public class NightEventsCollection : ScriptableObject
    {
        [SerializeField] private List<NightEvent> _nightEvents;

        public List<NightEvent> NightEvents { get => _nightEvents; set => _nightEvents = value; }
    }
}
