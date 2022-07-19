// *********************************************************************************************************************
// Created: Sys0 
// Levels.ConsoleApp/Levels.UnityFramework/Node.cs
// Created: 2022-05-27-3:36 PM
// *********************************************************************************************************************

namespace Levels.Universal.DataStructures {
public class /*.*/ Node<TD> : iNode<TD> {
	public virtual (int x, int y) Position {
		get;
		protected set;
	}

	/// <summary>
	/// Public as we are just wrapping this.
	/// </summary>
	public TD /*.*/ Value;

	public Node (
		(int x, int y) position) {
		Position = position;
	}

	public Node() { }

	public TD GetValue () {
		return Value;
	}
}
}