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
    
    public class NodeMatrix<TN>
    {
        private (int x, int y) Size;
            public (int x, int y) GetSize() { return Size;}
        
        private readonly List<Node<TN>> _nodes = new List<Node<TN>>();
            public void AddNode(Node<TN> node) {_nodes.Add(node);}
            public List<Node<TN>> GetNodes() {return _nodes;}
        
        internal readonly List<(Node<TN> nodeA, Node<TN> nodeB, ConnectionTypes Connection)> _Links = 
            new List<(Node<TN> nodeA, Node<TN> nodeB, ConnectionTypes Connection)>();

        // TODO: Make this creation not inside NodeMatrix, but have builder be what is used to create a matrix.
        public NodeMatrix((int x, int y) size)
        {
            Size = size;
            NodeMatrixBuilder.FillNodeMatrix(this);
        }

        public int SlotCount()
        {
            return Size.x * Size.y;
        }
    }
}