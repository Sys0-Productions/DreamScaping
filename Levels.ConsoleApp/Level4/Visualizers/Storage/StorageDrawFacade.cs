// *********************************************************************************************************************
// Created: Sys0
// Levels.ConsoleApp/Levels.ConsoleApp/StorageDrawFacade.cs
// Created: 2022-05-24-9:08 PM
// *********************************************************************************************************************

using System.Text;

using Levels.ConsoleApp.Visualizers.DataStructures;
using Levels.Universal.DataStructures;

namespace Levels.Universal.DataStructures {
using ExtensionMethods;

	/// <todo>
	/// Change this to a better place.
	/// </todo>
	class StorageDrawFacade {
	public static void Draw (
		(int x, int y) size) {
		Console.WriteLine(
			StorageTxtVis.Draw(
				Node.Matrix<int>.Build(size),
				new List<StringBuilder>().FillWithNew((int)size.y * 2 - 1).
										  ToArray(),
				new NodeMatrixStylizer()));
	}
}
}
