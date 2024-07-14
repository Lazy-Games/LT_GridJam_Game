using System;
using System.Collections;
using System.Collections.Generic;

namespace HexGridGame.DataModels
{
    [Serializable]
    public class ResourceCollected
    {
        public string ResourceIdentifier { get; set; }
        public int Amount { get; set; }

        public ResourceCollected() { }
    }
}
        