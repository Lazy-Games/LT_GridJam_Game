using System;
using System.Collections;
using System.Collections.Generic;

namespace HexGridGame.DataModels
{
    [Serializable]
    public class GameSettings
    {
        public bool TurnsAreTimed { get; set; }
        public int TurnTime { get; set; }
        public bool GameContinuesOnWin {  get; set; }

        public GameSettings() { }
    }
}
