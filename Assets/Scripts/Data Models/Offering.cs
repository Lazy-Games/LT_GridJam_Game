using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexGridGame.DataModels
{
    [Serializable]
    public class Offering
    {
        public string Identifier { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Sprite Image { get; set; }
        
        public Offering() { }
    }
}