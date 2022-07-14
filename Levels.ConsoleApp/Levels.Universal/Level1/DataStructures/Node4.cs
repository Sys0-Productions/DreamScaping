///<contrib>Xan.Nava<contrib>

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Levels.Universal.DataStructures;

/// <uses>
/// Used to make a four connection node of Node4&lt;<see cref="VT"/>=ValueType&gt;. <br/>
/// <inst>
/// Cast the type based on its reflected type, or only use one type per matrix.
/// </inst>
/// .<br/>
/// .<br/>
/// .<br/>
/// </uses>
/// <todo>
/// TODO:[FUTURE][C# 11] Change this abstract class to interface. Probably trust people to override Equals by reading documentation.<br/>
/// https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/static-abstract-interface-methods <br/>
/// <code>
/// Change to interface when we can. And probably trust people to override Equals by reading codumentation.
/// </code>
/// </todo>
/// <typeparam name="VT">Value Type</typeparam>
public class Node4<VT> : Node<VT> {
	public(int x, int y) Position {
		get;
		protected set;
	}

	public Type NodeType {
		get;
		protected set;
	}

	public(Node4<VT> node, Node.ConnectionTypes connecetion) NodeUp {
		get;
		protected set;
	}
	public(Node4<VT> node, Node.ConnectionTypes connecetion) NodeDown {
		get;
		protected set;
	}
	public(Node4<VT> node, Node.ConnectionTypes connecetion) NodeLeft {
		get;
		protected set;
	}
	public(Node4<VT> node, Node.ConnectionTypes connecetion) NodeRight {
		get;
		protected set;
	}

	public Node4<VT> Setup(
		((Node4<VT> node, Node.ConnectionTypes connecetion) up, 
		(Node4<VT> node, Node.ConnectionTypes connecetion) down,
		(Node4<VT> node, Node.ConnectionTypes connecetion) left,
		(Node4<VT> node, Node.ConnectionTypes connecetion) right) connections,
		(int x, int y) position) {

		NodeUp    = connections.up;
		NodeDown  = connections.down;
		NodeLeft  = connections.left;
		NodeRight = connections.right;

		Position = position;

		NodeType = typeof(VT);

		return this;
	}

	public Node4<VT> Setup(
		((Node4<VT> node, Node.ConnectionTypes connecetion) up, 
		(Node4<VT> node, Node.ConnectionTypes connecetion) down,
		(Node4<VT> node, Node.ConnectionTypes connecetion) left,
		(Node4<VT> node, Node.ConnectionTypes connecetion) right) connections,
		(int x, int y) position,
		VT value) {

		Setup(connections, position);

		Value = value;

		return this;
	}

	public void map (
		VT value) {
		base.Value = value;
	}

	public VT GetValue (
		int index) {
		return base.Value;
	}
}
