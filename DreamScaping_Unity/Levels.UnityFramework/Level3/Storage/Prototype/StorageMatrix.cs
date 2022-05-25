// *********************************************************************************************************************
// Created: Sys0 
// Levels.ConsoleApp/Levels.UnityFramework/StorageInfo.cs
// Created: 2022-05-19-11:40 PM
// *********************************************************************************************************************

namespace Levels.UnityFramework.Storage
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using UnityEngine;
    
    [Serializable]
    public partial class StorageMatrix
    {
        [Header("Test1.1")]
        public Vector2 Size;
        private Vector2 _size;
        
        [SerializeField]
        public readonly List<StorageSlot> Slots = new List<StorageSlot>();

        public readonly float SlotCount;

        public StorageMatrix(Vector2 size)
        {
            Size = size;
            SlotCount = Size.x * Size.y;
            StorageBuilder.CreateStorageSlots(this);
        }
    }
}