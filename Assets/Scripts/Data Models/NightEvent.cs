using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexGridGame.DataModels
{
    [Serializable]
    public class NightEvent
    {
        public string Name;
        public string Description;
        public float Modifier;
        public Sprite Image;
    }
}