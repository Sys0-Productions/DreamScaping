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
        internal (int x, int y) _size;
            public (int x, int y) GetSize() { return _size;}
            public void SetSize((int x, int y) size) { _size = size;}

        internal readonly List<Node<TN>> _Nodes = new List<Node<TN>>();
            public List<Node<TN>> GetNodes() {return _Nodes;}
        
        internal readonly List<(Node<TN> nodeA, Node<TN> nodeB, ConnectionTypes Connection)> _Links = 
            new List<(Node<TN> nodeA, Node<TN> nodeB, ConnectionTypes Connection)>();

        public static NodeMatrix<TN> Build((int x, int y) size)
        {
            return NodeMatrixBuilder.Build<TN>((size.x, size.y));
        }
    }
}