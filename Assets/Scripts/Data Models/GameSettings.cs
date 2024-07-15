using System;
using System.Collections;
using System.Collections.Generic;

namespace HexGridGame.DataModels
{
    [Serializable]
    public class GameSettings
    {
        public bool TurnsAreTimed;
        public int TurnTime;
        public bool GameContinuesOnWin;

        public GameSettings() { }
    }
}
