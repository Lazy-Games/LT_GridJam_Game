using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexGridGame.DataModels
{
    [Serializable]
    public class NightEvent
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Modifier { get; set; }
        public Sprite Image { get; set; }
    }
}