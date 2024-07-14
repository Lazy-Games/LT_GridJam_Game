using System;
using System.Collections;
using System.Collections.Generic;

namespace HexGridGame.DataModels
{
    [Serializable]
    public class GameSession
    {
        public int CurrentTurn { get; set; }
        public bool IsDay { get; set; }
        public List<string> PastNightEvents { get; set; }

        public GameSession() { }
    }
}
