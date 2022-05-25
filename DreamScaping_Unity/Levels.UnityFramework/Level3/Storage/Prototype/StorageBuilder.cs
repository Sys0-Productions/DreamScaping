// *********************************************************************************************************************
// Created: Sys0 
// Levels.ConsoleApp/Levels.UnityFramework/StorageBuilder.cs
// Created: 2022-05-19-11:39 PM
// *********************************************************************************************************************

namespace Levels.UnityFramework.Storage
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Levels.UnityFramework.Storage.Datatypes;
    using UnityEngine;
    
    public static class StorageBuilder
    {
        [SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator")]
        public static void CreateStorageSlots(StorageMatrix storageMatrix)
        {
            storageMatrix.Slots?.Clear();
    
            // Create all slots
            for (int i = 0; i < storageMatrix.Size.x * storageMatrix.Size.y; i++)
            {
                storageMatrix.Slots.Add(
                    new StorageSlot(
                        new Vector2(
                            i % storageMatrix.Size.x + 1, // This slot's x position.
                            (i / (int)storageMatrix.Size.x) + 1))); // This slot's y position.
            }
    
            // Get the current slot.
            for (int i = 0; i < storageMatrix.Slots.Count; i++)
            {
                var currentSlot = storageMatrix.Slots[i];
                    
                // Get the slot to compare to.
                for (int j = 0; j < storageMatrix.Slots.Count; j++)
                {
                    if (i == j)
                        continue;
                        
                    StorageSlot compToSlot = storageMatrix.Slots[j];
                    // Positions of each slot.
                    Vector2 jPosition = compToSlot.Position, iPosition = currentSlot.Position; 
                        
                    // Positional Values of each slot.
                    float jPx = jPosition.x, iPx = iPosition.x, jPy = jPosition.y, iPy = iPosition.y;
                        
                    // Make sure at least one position value is the same as the current slot,
                    if ((jPx == iPx) ^ (jPy == iPy) 
                        &&  // and the distance from the slots is +-1.
                        (Mathf.Abs(jPx - iPx) == 1 || Mathf.Abs(jPy -iPy)  == 1)) 
                    {
                        currentSlot.Links.Add(Tuple.Create(compToSlot, LinkTypes.Connected));
                    }
                }
            }
        }
    }
}