namespace Levels.Inventory
{
    using System.Collections.Generic;
    
    using UnityEngine;
    
    public class InventorySlotManager
    {
        public List<InventorySlot> Equipment;
        
        // A 2D storage web, each slot location is on a grid (0,0) starting.
        public readonly Dictionary<Vector2, InventorySlot> Slots = new();
        
        private StorageInfo Info;
        
        public InventorySlotManager(StorageInfo info)
        {
            Info = info;
            
            // Iterate through all the slots.
            for (int i = 0; i < Info.SlotCount; i++)
            {
                // Get the current slot position in the Array.
                var slotColumn = i % Info.Size.x;
                var slotRow = i / Info.Size.x;
                
                // Add the slot to inventory.
                Slots.Add(new Vector2(slotColumn, slotRow),  new InventorySlot());
            }
        }
        
        public static InventorySlotManager AddSlots(InventorySlotManager inv, List<GameObject> slots)
        {
            return inv;
        }
        
        public static void RemoveSlot(GameObject obj)
        {
            
        }
    }
}