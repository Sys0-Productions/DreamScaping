// *********************************************************************************************************************
// Created: Sys0 
// Levels.ConsoleApp/Levels.UnityFramework/StorageInfo.cs
// Created: 2022-05-19-11:40 PM
// *********************************************************************************************************************

namespace Levels.UnityFramework.DataStructure.NodeMatrix
{
    using System.Collections.Generic;
    using Levels.UnityFramework.DataStructure.NodeMatrix.Builder;
    using Levels.UnityFramework.DataStructure.NodeMatrix.Datatypes;
    using Levels.UnityFramework.Storage;
    
    public partial class NodeMatrix<TN>
    {
        // TODO: Make this not public.
        public (int x, int y) Size;
        
        // TODO: Make this not public.
        public readonly List<Node<TN>> Nodes = new List<Node<TN>>();
        
        internal readonly List<(Node<TN> nodeA, Node<TN> nodeB, ConnectionTypes Connection)> _links = 
            new List<(Node<TN> nodeA, Node<TN> nodeB, ConnectionTypes Connection)>();


        public NodeMatrix((int x, int y) size)
        {
            Size = size;
            NodeMatrixBuilder.CreateStorageSlots(this);
        }

        public int SlotCount()
        {
            return (int)Size.x * (int)Size.y;
        }
    }
}