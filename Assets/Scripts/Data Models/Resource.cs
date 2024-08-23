﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexGridGame.DataModels
{
    [Serializable]
    public class Resource
    {
        public ResourcesType ResourcesType;
        public string Name;
        public string Description;
        public Sprite Image;

        public Resource() { }
    }
}