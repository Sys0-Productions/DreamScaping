// *********************************************************************************************************************
// Created: Sys0 
// Levels.ConsoleApp/Levels.ConsoleApp/StorageVisStylizer.cs
// Created: 2022-05-20-2:04 AM
// *********************************************************************************************************************

namespace Levels.ConsoleApp.Visualizers.DataStructures;

using Levels.UnityFramework.DataStructure.NodeMatrix.Datatypes;

public class NodeMatrixStylizer
{
    public char Slot = '*';
    public char Connection = '-';
    public char Locked = '=';
    public char Disconnected = 'x';

    public char GetConnectionStyle(ConnectionTypes type)
    {
        switch (type)
        {
            case ConnectionTypes.Connected:
                return Connection;
            case ConnectionTypes.Disconnected:
                return Disconnected;
            case ConnectionTypes.Locked:
                return Locked;
        }

        return ' ';
    }
}