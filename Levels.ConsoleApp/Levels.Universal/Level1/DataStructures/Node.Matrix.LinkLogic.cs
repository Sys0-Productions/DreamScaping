// *********************************************************************************************************************
// Created: Sys0 
// Levels.ConsoleApp/Levels.UnityFramework/LinksBroker.cs
// Created: 2022-05-24-10:14 PM
// *********************************************************************************************************************

using System.Collections.Generic;

namespace Levels.Universal.DataStructures {
// TODO: go over comments.
// TODO: Make Levels.ConsoleApp representation tests.
// TODO: Make unit tests.

public static class /*.*/ Node_MatrixExtension {
	/// <summary>
	/// Checks if there is a connection between the two nodes <see cref="a"/> and <see cref="b"/> at index <see cref="i"/> in <see cref="storage"/>
	/// </summary>
	/// <param name="nodeMatrix">The <see cref="Node.Matrix{TN}"/> to be using.</param>
	/// <param name="a">One of two nodes to check the link on.</param>
	/// <param name="b">One of two nodes to check the link on.</param>
	/// <param name="i">The index to check for the link at.</param>
	/// <returns></returns>
	public static bool /*.*/ IsLinkedAt<TN> (
		this Node.Matrix<TN> nodeMatrix,
		Node<TN> a,
		Node<TN> b,
		int i) {

		var storageLink = nodeMatrix._Links[i];

		return storageLink.nodeA == a && storageLink.nodeB == b || storageLink.nodeA == b && storageLink.nodeB == a;
	}

	/// <summary>
	/// Used to see if there is a connection between two nodes in a <see cref="Node.Matrix{TN}"/>.
	/// </summary>
	/// <param name="nodeMatrix">The <see cref="Node.Matrix{TN}"/> to check against.</param>
	/// <param name="a">One of the two nodes the connection is on.</param>
	/// <param name="b">One of the two nodes the connection is on.</param>
	/// <returns>True if there is a link. False if there is not.</returns>
	public static bool /*.*/ IsLinked<TN> (
		this Node.Matrix<TN> nodeMatrix,
		Node<TN> a,
		Node<TN> b) {
		bool flag = false;

		for (int i = 0;i < nodeMatrix._Links.Count;i++) {
			flag = IsLinkedAt(nodeMatrix, a, b, i) || flag;
		}

		return flag;
	}

	/// <summary>
	/// Used to see if there is a connection between two nodes in a <see cref="Node.Matrix{TN}"/>.
	/// </summary>
	/// <param name="nodeMatrix">The <see cref="Node.Matrix{TN}"/> to check against.</param>
	/// <param name="a">One of the two nodes the connection is on.</param>
	/// <param name="b">One of the two nodes the connection is on.</param>
	/// <returns>True if there is a link. False if there is not.</returns>
	public static bool /*.*/ IsLinked<TN> (
		this Node.Matrix<TN> nodeMatrix,
		(int x, int y) a,
		(int x, int y) b) {

		return IsLinked(nodeMatrix, ViewNodeAt(nodeMatrix, a), ViewNodeAt(nodeMatrix, b));
	}

	/// <summary>
	/// Returns a copy of the node link if it exists.
	/// </summary>
	/// <param name="nodeMatrix">The <see cref="Node.Matrix{TN}"/> to check against.</param>
	/// <param name="a">One of the two nodes the link is on.</param>
	/// <param name="b">One of the two nodes the link is on.</param>
	/// <returns>Will return the link if it exists, otherwise the returned link will be empty,
	/// check value for link.</returns>
	public static (Node<TN> nodeA, Node<TN> nodeB, Node.ConnectionTypes connection) /*.*/ ViewLinkFor<TN> (
		this Node.Matrix<TN> nodeMatrix,
		Node<TN> a,
		Node<TN> b) {

		for (int i = 0;i < nodeMatrix._Links.Count;i++) {
			if (IsLinkedAt(nodeMatrix, a, b, i))
				return nodeMatrix._Links[i];
		}

		return (null, null, Node.ConnectionTypes.Not);
	}


	/// <summary>
	/// Used to see if there is a connection between two nodes in a <see cref="Node.Matrix{TN}"/>
	/// , and the type is Connected.
	/// </summary>
	/// <param name="nodeMatrix">The <see cref="Node.Matrix{TN}"/> to check against.</param>
	/// <param name="a">One of the two nodes the connection is on.</param>
	/// <param name="b">One of the two nodes the connection is on.</param>
	/// <param name="type">The type of <see cref="Node.ConnectionTypes"/> to compare against.</param>
	/// <returns>True if there is a link of type. False if there is not.
	/// You should check the link exists first. </returns>
	public static bool /*.*/ IsLinkType<TN> (
		this Node.Matrix<TN> nodeMatrix,
		Node<TN> a,
		Node<TN> b,
		Node.ConnectionTypes type) {
		var holder = ViewLinkFor(nodeMatrix, a, b);

		if (holder.nodeA is null)
			return false;

		return holder.connection == type;
	}

	/// <summary>
	/// Returns the first connection of nodes A and B.
	/// </summary>
	/// <param name="nodeMatrix">The <see cref="Node.Matrix{TN}"/> to check against.</param>
	/// <param name="a">One of the two nodes the connection is on.</param>
	/// <param name="b">One of the two nodes the connection is on.</param>
	/// <returns></returns>
	public static Node.ConnectionTypes /*.*/ CheckLinkType<TN> (
		this Node.Matrix<TN> nodeMatrix,
		Node<TN> a,
		Node<TN> b) {

		for (int i = 0;i < nodeMatrix._Links.Count;i++) {
			if (IsLinkedAt(nodeMatrix, a, b, i))
				return nodeMatrix._Links[i].
								  Connection;
		}

		return Node.ConnectionTypes.Not;
	}

	/// <summary>
	/// Will change the <see cref="Node.ConnectionTypes"/> on the link if there is any found.
	/// </summary>
	/// <param name="nodeMatrix">The <see cref="Node.Matrix{TN}"/> that the link is in.</param>
	/// <param name="link">The link details for the new connection.</param>
	/// <returns>True if the connection was changed. False if not.</returns>
	public static bool /*.*/ ChangeConnectionType<TN> (
		this Node.Matrix<TN> nodeMatrix,
		(Node<TN> a, Node<TN> b, Node.ConnectionTypes type) link) {
		var result = ViewLinkFor(nodeMatrix, link.a, link.b);

		if (result.connection != Node.ConnectionTypes.Not) {
			if (result.connection == link.type)
				return true;

			nodeMatrix._Links.Remove(result);
			nodeMatrix._Links.Add(link);

			return true;
		}

		return false;
	}

	public static bool /*.*/ HasNode<TN> (
		this Node.Matrix<TN> nodeMatrix,
		Node<TN> a) {

		return nodeMatrix._Nodes.Contains(a);
	}

	/// <summary>
	/// Returns a copy of all links for <see cref="a"/> if there are any.
	/// </summary>
	/// <param name="nodeMatrix">The <see cref="Node.Matrix{TN}"/> to check against.</param>
	/// <param name="a">The nodes the links are on.</param>
	/// <returns>Will return all links if any exist, otherwise the returned link will be empty,
	/// check value for link.
	/// The returned List will have the requested node first in the tuple.</returns>
	public static List<(Node<TN> nodeA, Node<TN> nodeB, Node.ConnectionTypes Connection)> /*.*/ ViewLinksOn<TN> (
		this Node.Matrix<TN> nodeMatrix,
		Node<TN> a) {

		if (a == null
		 || !nodeMatrix.HasNode(a))
			return null;

		var holder = new List<(Node<TN> nodeA, Node<TN> nodeB, Node.ConnectionTypes Connection)>();
		var flag   = false;

		for (int i = 0;i < nodeMatrix._Links.Count;i++) {
			if (nodeMatrix._Links[i].
						   nodeA
			 == a)
				holder.Add(nodeMatrix._Links[i]);
			else if (nodeMatrix._Links[i].
								nodeB
				  == a)
				holder.Add(
					(nodeMatrix._Links[i].
								nodeB, nodeMatrix._Links[i].
												  nodeA, nodeMatrix._Links[i].
																	Connection));
		}

		return holder;
	}

	public static Node<TN> /*.*/ ViewNodeAt<TN> (
		this Node.Matrix<TN> nodeMatrix,
		(int x, int y) a) {

		for (int i = 0;i < nodeMatrix._Nodes.Count;i++) {
			if (nodeMatrix._Nodes[i].
						   Position
			 == a)
				return nodeMatrix._Nodes[i];
		}

		return null;
	}

	/// <summary>
	/// Returns a copy of all links for <see cref="a"/> if there are any.
	/// </summary>
	/// <param name="nodeMatrix">The <see cref="Node.Matrix{TN}"/> to check against.</param>
	/// <param name="a">The nodes the links are on.</param>
	/// <returns>Will return all links if any exist, otherwise the returned link will be empty,
	/// check value for link.
	/// The returned List will have the requested node first in the tuple.</returns>
	public static List<(Node<TN> nodeA, Node<TN> nodeB, Node.ConnectionTypes Connection)> /*.*/ ViewAllLinks<TN> (
		this Node.Matrix<TN> nodeMatrix) {
		var holder = new List<(Node<TN> nodeA, Node<TN> nodeB, Node.ConnectionTypes Connection)>();

		foreach (var link in nodeMatrix._Links) {
			holder.Add(link);
		}

		return holder;
	}

	/// <summary>
	/// Will try to add the <see cref="link"/> to the <see cref="storage"/>.
	/// Check to make sure the link doesn't already exist, or exists with a different connection.
	/// </summary>
	/// <param name="nodeMatrix">The <see cref="Node.Matrix{TN}"/> to get the nodes from.</param>
	/// <param name="link">The link data to be used.</param>
	/// <returns> Will return true if added, else will return false(like if it already existed).</returns>
	public static bool /*.*/ TryLink<TN> (
		this Node.Matrix<TN> nodeMatrix,
		(Node<TN> nodeA, Node<TN> nodeB, Node.ConnectionTypes Connection) link) {

		if (IsLinked(nodeMatrix, link.nodeA, link.nodeB)
		 || link.nodeB == null
		 || link.nodeA == null)
			return false;

		nodeMatrix._Links.Add(link);

		return true;
	}

	/// <summary>
	/// Will try to add the <see cref="link"/> to the <see cref="storage"/>.
	/// Check to make sure the link doesn't already exist, or exists with a different connection.
	/// </summary>
	/// <param name="nodeMatrix">The <see cref="Node.Matrix{TN}"/> to get the nodes from.</param>
	/// <param name="link">The link data to be used.</param>
	/// <returns> Will return true if added, else will return false(like if it already existed).</returns>
	public static Report /*.*/ Link<TN> (
		this Node.Matrix<TN> nodeMatrix,
		(Node<TN> nodeA, Node<TN> nodeB, Node.ConnectionTypes Connection) link) {
		var report = new Report();
		var result = CheckLinkType(nodeMatrix, link.nodeA, link.nodeB);

		if (result != Node.ConnectionTypes.Not)
			report.Add(Report.AlreadyExists("A connection of type " + result + " already exists."));
		else
			nodeMatrix._Links.Add(link);

		return report;
	}

	/// <summary>
	/// Will try to unlink <see cref="link.nodeA"/> and <see cref="link.nodeB"/>.
	/// </summary>
	/// <param name="nodeMatrix">The <see cref="Node.Matrix{TN}"/> that the link will be removed from.</param>
	/// <param name="link">The link that will be tried to be removed.</param>
	/// NOTE: <see cref="link.nodeA"/> and <see cref="link.nodeB"/> aren't ordered.
	/// <returns> True if link was removed. False if no link.</returns>
	public static bool /*.*/ TryUnlink<TN> (
		this Node.Matrix<TN> nodeMatrix,
		(Node<TN> nodeA, Node<TN> nodeB, Node.ConnectionTypes Connection) link) {
		var linked = nodeMatrix.ViewLinkFor<TN>(link.nodeA, link.nodeB);

		if (linked.nodeA is object) {
			nodeMatrix._Links.Remove(linked);

			return true;
		}

		return false;
	}
}
}
