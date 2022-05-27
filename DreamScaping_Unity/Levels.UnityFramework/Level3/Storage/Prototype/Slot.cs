// *********************************************************************************************************************
// Created: Sys0 
// Levels.ConsoleApp/Levels.UnityFramework/StorageSlot.cs
// Created: 2022-05-19-11:40 PM
// *********************************************************************************************************************

namespace Levels.UnityFramework.Storage
{
    using System;
    using System.Collections.Generic;
    using Levels.UnityFramework.Storage.Datatypes;
    using UnityEngine;
    
    public class StorageSlot
    {
        public Vector2 Position;
        public GameObject Holding;

        public StorageSlot(Vector2 position)
        {
            Position = position;
        }
    }
}