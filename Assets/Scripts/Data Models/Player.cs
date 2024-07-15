using System;
using System.Collections;
using System.Collections.Generic;

namespace HexGridGame.DataModels
{
    [Serializable]
    public class Player
    {
        public string Name;
        public int Energy;
        public HexCoord Position;
        public List<ResourceCollected> Resources;

        public Player() { }
    }
}