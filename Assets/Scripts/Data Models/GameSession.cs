using System;
using System.Collections;
using System.Collections.Generic;

namespace HexGridGame.DataModels
{
    [Serializable]
    public class GameSession
    {
        public int CurrentTurn;
        public bool IsDay;
        public List<string> PastNightEvents;

        public GameSession() { }
    }
}
