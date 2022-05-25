namespace Levels.Inventory
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class InventorySlot
    {
        #region variables
        public readonly Dictionary<InventorySlot, ConnectionTypes> Connections = new();
        #endregion

        #region initialization
        public InventorySlot(Dictionary<InventorySlot, ConnectionTypes> connections)
        {
            Connections = connections;
        }
        
        public InventorySlot(SlotConnect[] invConnects) : this()
        {
            for (int i = 0; i < invConnects.Length; i++)
            {
                Connections.Add(invConnects[i].Connection, invConnects[i].ConnectionType);
            }
        }

        public InventorySlot()
        {
        }

        #endregion

        #region Methods
        public static InventorySlot AddConnection(InventorySlot from, InventorySlot slot, ConnectionTypes type)
        {
            from.Connections.Add(slot, type);
            return from;
        }
        #endregion
    }

    [Serializable]
    public struct SlotConnect
    {
        public InventorySlot Connection;
        public ConnectionTypes ConnectionType;
    }
}




