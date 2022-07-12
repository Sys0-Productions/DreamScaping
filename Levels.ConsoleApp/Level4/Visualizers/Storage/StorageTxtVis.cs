// *********************************************************************************************************************
// Created: Sys0 
// Levels.ConsoleApp/Levels.ConsoleApp/StorageTxtVis.cs
// Created: 2022-05-19-11:51 PM
// *********************************************************************************************************************

// ReSharper disable CompareOfFloatsByEqualityOperator
namespace Levels.ConsoleApp.Visualizers.DataStructures;

using System.Drawing;
using System.Text;
using Levels.UnityFramework.DataStructure.NodeMatrix;
using Levels.UnityFramework.DataStructure.NodeMatrix.LinkLogic;
using Levels.UnityFramework.Storage;

public static class StorageTxtVis
{
    /// <summary>
    /// Draws Storage Info
    /// </summary>
    /// <param name="nodeage"></param>
    /// <param name="builders">Must have double the number of rows as there are in the <see cref="Size"/> minus one.</param>
    /// <param name="style">The style to use for drawing.</param>
    /// <returns></returns>
    public static string Draw<TN>(NodeMatrix<TN> node, StringBuilder[] builders, NodeMatrixStylizer style)
    {
        if (builders.Length != node.GetSize().y * 2 - 1)
            throw new ArgumentException("Not enough builders passed. Check method param doc for details.");
        
        DrawNodesAndLinks(node, builders, style);
        
        return BuilderArrayToString(builders);
    }

    private static string BuilderArrayToString(StringBuilder[] builders)
    {
        StringBuilder endMatrix = new StringBuilder();
        foreach (var builder in builders)
            endMatrix.Append(builder.ToString());
        return endMatrix.ToString();
    }

    private static void DrawNodesAndLinks<TN>(NodeMatrix<TN> node, StringBuilder[] builders, NodeMatrixStylizer style)
    {
        foreach (var slot in node.GetNodes())
        {
            int index = slot.Position.y;
            // Have a spacer row builder for every row, and then account for array position of builder.
            // The row will be offset by the number of spacer rows above.
            int row = index + index - 2;

            // Draw the slot
            builders[row].Append(style.Slot);

            // Draw Connections bellow or to the right of slot.
            DrawSlotConnections(node, slot, row, builders, style);

            // Draw new line char for end of matrix.
            if (slot.Position.x == node.GetSize().x)
            {
                builders[row].Append('\n');

                if (row + 1 < builders.Length)
                    builders[row + 1].Append('\n');
            }
        }
    }

    private static void DrawSlotConnections<TN>(NodeMatrix<TN> nodes, Node<TN> currentSlot, int row, StringBuilder[] builders, NodeMatrixStylizer style)
    {
        var links = nodes.ViewLinksOn( currentSlot);

        foreach (var link in links)
        {
            // If the connection is to the right of currentSlot.
            if (link.nodeA.Position.x < link.nodeB.Position.x && link.nodeA.Position.y == link.nodeB.Position.y)
            {
                builders[row].Append(style.GetConnectionStyle(link.Connection));
            }

            // If the connection is bellow of currentSlot.
            if (link.nodeA.Position.x == link.nodeB.Position.x && link.nodeA.Position.y < link.nodeB.Position.y && row + 1 != builders.Length)
            {
                builders[row + 1].Append(style.GetConnectionStyle(link.Connection));
                builders[row + 1].Append(' ');
            }
        }
    }
}