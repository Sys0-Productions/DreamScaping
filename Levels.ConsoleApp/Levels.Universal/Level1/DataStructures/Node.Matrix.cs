// *********************************************************************************************************************
// Created: Sys0 
// Levels.ConsoleApp/Levels.UnityFramework/StorageInfo.cs
// Created: 2022-05-19-11:40 PM
// *********************************************************************************************************************

using System.Collections.Generic;

namespace Levels.Universal.DataStructures {
public static partial class Node {
	public class Matrix<TN> {
		internal (int x, int y) _size;
		public (int x, int y) /*.*/ GetSize() { return _size; }
		public void            /*.*/ SetSize (
			(int x, int y) size) {
			_size = size;
		}

		internal readonly List<Node<TN>> _Nodes = new List<Node<TN>>();
		public List<Node<TN>> /*.*/ GetNodes() { return _Nodes; }

		internal readonly List<(Node<TN> nodeA, Node<TN> nodeB, Node.ConnectionTypes Connection)> _Links =
			new List<(Node<TN> nodeA, Node<TN> nodeB, Node.ConnectionTypes Connection)>();

		public static Matrix<TN> /*.*/ Build (
			(int x, int y) size) {
			return Node.Matrix.Builder.Build<TN>((size.x, size.y));
		}
	}
}

}