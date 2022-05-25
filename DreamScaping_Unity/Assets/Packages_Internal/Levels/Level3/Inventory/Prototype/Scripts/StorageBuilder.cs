// *********************************************************************************************************************
// Created: Sys0 
// DreamScaping_Unity/Assembly-CSharp/StorageBuilder.cs
// Created: 2022-05-19-10:55 PM
// *********************************************************************************************************************

namespace Levels.Inventory
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using UnityEngine;
    
    public static class StorageBuilder
    {
        [SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator")]
        public static void CreateStorageSlots(StorageInfo storageInfo)
        {
            storageInfo.Slots?.Clear();
            storageInfo.SlotConnections?.Clear();
    
            // Create all slots
            for (int i = 0; i < storageInfo.Size.x * storageInfo.Size.y; i++)
            {
                Debug.Log("Colm = " + (storageInfo.Size.x - storageInfo.Size.x % i));
                Debug.Log("Row = " + (i / storageInfo.Size.x));
                storageInfo.Slots.Add(new StorageSlot(new Vector2(storageInfo.Size.x - storageInfo.Size.x % i, i / storageInfo.Size.x)));
            }
    
            // Get the current slot.
            for (int i = 0; i < storageInfo.Slots.Count; i++)
            {
                var currentSlot = storageInfo.Slots[i];
                    
                // Get the slot to compare to.
                for (int j = 0; j < storageInfo.Slots.Count; j++)
                {
                    if (i == j)
                        continue;
                        
                    StorageSlot compToSlot = storageInfo.Slots[j];
                    // Positions of each slot.
                    Vector2 jPosition = compToSlot.Position, iPosition = currentSlot.Position; 
                        
                    // Positional Values of each slot.
                    float jPx = jPosition.x, iPx = iPosition.x, jPy = jPosition.y, iPy = iPosition.y;
                        
                    // Make sure at least one position value is the same as the current slot,
                    if ((jPx == iPx) ^ (jPy == iPy) 
                        &&  // and the distance from the slots is +-1.
                        (Mathf.Abs(jPx - iPx) == 1 || Mathf.Abs(jPy -iPy)  == 1)) 
                    {
                        currentSlot.Connections.Add(Tuple.Create(compToSlot, ConnectionTypes.Connected));
                    }
                }
            }
        }
    }
}