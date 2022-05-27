// *********************************************************************************************************************
// Created: Sys0 
// Levels.ConsoleApp/Levels.UnityFramework/StorageBuilder.cs
// Created: 2022-05-19-11:39 PM
// *********************************************************************************************************************

namespace Levels.UnityFramework.DataStructure.NodeMatrix.Builder
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Levels.UnityFramework.DataStructure.NodeMatrix.Datatypes;
    using Levels.UnityFramework.DataStructure.NodeMatrix.LinkLogic;
    using Levels.UnityFramework.Storage;
    
    public static class NodeMatrixBuilder
    {
        [SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator")]
        public static void CreateStorageSlots<TN>(NodeMatrix<TN> nodeMatrix)
        {
            nodeMatrix.Nodes.Clear();
    
            // Create all slots
            for (int i = 0; i < nodeMatrix.Size.x * nodeMatrix.Size.y; i++)
            {
                var holder = new Node<TN> { Position = (i % nodeMatrix.Size.x + 1, i / nodeMatrix.Size.x + 1) };
                nodeMatrix.Nodes.Add(holder);
            }
    
            // Get the current slot.
            for (int i = 0; i < nodeMatrix.Nodes.Count; i++)
            {
                var currentSlot = nodeMatrix.Nodes[i];
                    
                // Get the slot to compare to.
                for (int j = 0; j < nodeMatrix.Nodes.Count; j++)
                {
                    if (i == j)
                        continue;
                        
                    var compToSlot = nodeMatrix.Nodes[j];
                    // Positions of each slot.
                    (int x, int y) jPosition = compToSlot.Position, iPosition = currentSlot.Position; 
                        
                    // Positional Values of each slot.
                    float jPx = jPosition.x, jPy = jPosition.y, iPx = iPosition.x, iPy = iPosition.y;
                        
                    // Make sure at least one position value is the same as the current slot,
                    if ((jPx == iPx) ^ (jPy == iPy) 
                        &&  // and the distance from the slots is +-1.
                        (Math.Abs(jPx - iPx) == 1 || Math.Abs(jPy -iPy) == 1)) 
                    {
                        //currentSlot.Links.Add(Tuple.Create(compToSlot, ConnectionTypes.Connected));
                        nodeMatrix.Link((currentSlot, compToSlot, ConnectionTypes.Connected));
                    }
                }
            }
        }
    }
}