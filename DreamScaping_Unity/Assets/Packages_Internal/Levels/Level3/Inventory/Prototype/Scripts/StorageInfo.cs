namespace Levels.Inventory
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    [Serializable]
    public class StorageInfo
    {
        [Header("Test1.1")]
        public Vector2 Size;
        private Vector2 _size;
        
        [SerializeField]
        public readonly List<StorageSlot> Slots = new List<StorageSlot>();
        [SerializeField]
        public readonly List<SlotConnection> SlotConnections = new List<SlotConnection>();
        
        public readonly float SlotCount;

        public StorageInfo(Vector2 size, List<SlotConnection> slotConnections)
        {
            Size = size;
            SlotCount = Size.x * Size.y;
            SlotConnections = slotConnections;
            StorageBuilder.CreateStorageSlots(this);
        }
    }
}