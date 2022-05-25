using UnityEngine;

namespace Levels.Inventory
{
    using System;
    using System.Collections.Generic;

    public class StorageSlot
    {
        public Vector2 Position;
        public GameObject Holding;
        public List<Tuple<StorageSlot, ConnectionTypes>> Connections;

        public StorageSlot(Vector2 position)
        {
            Position = position;
        }
    }
}