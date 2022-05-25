// *********************************************************************************************************************
// Created: Sys0 
// Levels.ConsoleApp/Levels.ConsoleApp/StorageTxtVis.cs
// Created: 2022-05-19-11:51 PM
// *********************************************************************************************************************

namespace Levels.ConsoleApp.Visualizers.Storage;

using System.Text;
using Levels.UnityFramework.Storage;
using Levels.UnityFramework.Storage.Datatypes;

public static class StorageTxtVis
{
    /// <summary>
    /// Draws Storage Info
    /// </summary>
    /// <param name="storage"></param>
    /// <param name="builders">Must have double the number of rows as there are in the <see cref="storage.Size"/> minus one.</param>
    /// <param name="style">The style to use for drawing.</param>
    /// <returns></returns>
    public static string Draw(StorageMatrix storage, StringBuilder[] builders, StorageStylizer style)
    {
        if (builders.Length != storage.Size.y * 2 - 1)
            throw new ArgumentException("Not enough builders passed. Check method param doc for details.");


        // Go over each slot
        foreach (var slot in storage.Slots)
        {
            int index = (int)slot.Position.y;
            // Have a spacer row builder for every row, and then account for array position of builder.
            // The row will be offset by the number of spacer rows above.
            int row = index + index - 2;
            
            // Draw the slot
            builders[row].Append(style.Slot);

            // Draw Connections bellow or to the right of slot.
            DrawSlotConnections(builders, style, slot, row);

            // Draw new line char for end of matrix.
            if (slot.Position.x == storage.Size.x)
            {
                builders[row].Append('\n');
                
                if(row + 1 < builders.Length)
                    builders[row + 1].Append('\n');
            }
        }

        StringBuilder EndMatrix = new StringBuilder();
        foreach (var builder in builders)
            EndMatrix.Append(builder.ToString());

        return EndMatrix.ToString();
    }

    private static void DrawSlotConnections(StringBuilder[] builders, StorageStylizer style, StorageSlot slot, int row)
    {
        foreach (var connection in slot.Connections)
        {
            // Draw connection type bellow.
            if (connection.Item1.Position.y > slot.Position.y)
            {
                switch (connection.Item2)
                {
                    case ConnectionTypes.Connected:
                        builders[row + 1].Append(style.Connection);
                        break;
                    case ConnectionTypes.Disconnected:
                        builders[row + 1].Append(style.Disconnected);
                        break;
                    case ConnectionTypes.Locked:
                        builders[row + 1].Append(style.Locked);
                        break;
                }

                builders[row + 1].Append(' ');
            }

            if (connection.Item1.Position.x > slot.Position.x)
            {
                switch (connection.Item2)
                {
                    case ConnectionTypes.Connected:
                        builders[row].Append(style.Connection);
                        break;
                    case ConnectionTypes.Disconnected:
                        builders[row].Append(style.Disconnected);
                        break;
                    case ConnectionTypes.Locked:
                        builders[row].Append(style.Locked);
                        break;
                }
            }
        }
    }



    private enum Keys
    {
        slot = 0,
        con = 1,
        locked = 2,
        not = 3
    }
}