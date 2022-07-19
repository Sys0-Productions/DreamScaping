// *********************************************************************************************************************
// Created: Sys0 
// Levels.ConsoleApp/Levels.ConsoleApp/StorageVisStylizer.cs
// Created: 2022-05-20-2:04 AM
// *********************************************************************************************************************

using Levels.Universal.DataStructures;

namespace Levels.ConsoleApp.Visualizers.DataStructures {

public class NodeMatrixStylizer {
	public char Slot = '*';
	public char Connection = '-';
	public char Locked = '=';
	public char Disconnected = 'x';

	public char GetConnectionStyle(
		Node.ConnectionTypes type) {
		switch (type) {
		case Node.ConnectionTypes.Connected:
			return Connection;

		case Node.ConnectionTypes.Disconnected:
			return Disconnected;

		case Node.ConnectionTypes.Locked:
			return Locked;
		}

		return ' ';
	}
}
}

