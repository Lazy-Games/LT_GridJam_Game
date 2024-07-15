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
        public PlayerPosition Position;
        public List<ResourceCollected> Resources;

        public Player() { }
    }

    [Serializable]
    public struct PlayerPosition
    {
        public int q;
        public int r;
        public int s;
    }
}