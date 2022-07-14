﻿// *********************************************************************************************************************
// Created: Sys0 
// Levels.ConsoleApp/Levels.UnityFramework/StorageBuilder.cs
// Created: 2022-05-19-11:39 PM
// *********************************************************************************************************************

using System;
using System.Collections.Generic;

namespace Levels.Universal.DataStructures {
public static partial class Node {
	public static partial class Matrix {
			public static class /*.*/ Builder {
				public static Node.Matrix<TN> /*.*/ Build<TN>(
					(int x, int y) size) {
					var holder = new Node.Matrix<TN>();

					holder.SetSize(size);
					FillNodeMatrix(holder);

					return holder;
				}

				/// <summary>
				/// Will return a filled 2D matrix of nodes, each with a connected link on their neighbors.
				/// </summary>
				/// <param name="nodeMatrix">The matrix that will be filled.</param>
				/// <typeparam name="TN">The data that each node holds.</typeparam>
				public static void /*.*/ FillNodeMatrix<TN>(
					Node.Matrix<TN> nodeMatrix) {
					var nodes = nodeMatrix.GetNodes();

					nodes.Clear();

					// Create all nodes
					CreateNodes(
						nodeMatrix
					  , nodes);

					// Get the current nodes.
					CreateLinks(
						nodeMatrix
					  , nodes);
				}

				private static void CreateNodes<TN>(
					Node.Matrix<TN> nodeMatrix,
					List<Node<TN>> nodes) {
					var matrixSize = nodeMatrix.GetSize();

					for (int i = 0;i < matrixSize.x * matrixSize.y;i++) {
						var holder = new Node<TN> { Position = (i % matrixSize.x + 1, i / matrixSize.x + 1) };
						nodes.Add(holder);
					}
				}

				private static void CreateLinks<TN>(
					Node.Matrix<TN> nodeMatrix,
					List<Node<TN>> nodes) {

					for (int i = 0;i < nodes.Count;i++) {
						var currentNode = nodes[i];

						// Get the node to compare to.
						for (int j = 0;j < nodes.Count;j++) {
							if (i == j)
								continue;

							var compToNode = nodes[j];

							// Positions of each node.
							(int x, int y) jPosition = compToNode.Position,
										   iPosition = currentNode.Position;

							// Make sure at least one position value is the same as the current node,
							if ((jPosition.x == iPosition.x) ^ (jPosition.y == iPosition.y)
							 && // and the distance from the node is +-1.
								(Math.Abs(jPosition.x - iPosition.x) == 1 || Math.Abs(jPosition.y - iPosition.y) == 1)) {
								nodeMatrix.Link((currentNode, compToNode, Node.ConnectionTypes.Connected));
							}
						}
					}
				}
			}
		}
}
}