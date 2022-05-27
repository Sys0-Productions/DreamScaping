// *********************************************************************************************************************
// Created: Sys0 
// Levels.ConsoleApp/Levels.UnityFramework/Node.cs
// Created: 2022-05-27-3:36 PM
// *********************************************************************************************************************

namespace Levels.UnityFramework.Storage
{
    public class Node<TD>
    {
        public (int x, int y) Position;
        public TD Data;

        public Node((int x, int y) position)
        {
            Position = position;
        }

        public Node() { }
    }
}