using System;
using System.Collections;
using System.Collections.Generic;

namespace HexGridGame.DataModels
{
    [Serializable]
    public class Player
    {
        public string Name { get; set; }
        public int Energy { get; set; }
        public PlayerPosition Position { get; set; }
        public List<ResourceCollected> Resources { get; set; }

        public Player() { }
    }

    [Serializable]
    public struct PlayerPosition
    {
        public int q { get; set; }
        public int r { get; set; }
        public int s { get; set; }
    }
}