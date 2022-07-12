// *********************************************************************************************************************
// Created: Sys0 
// Levels.ConsoleApp/Levels.UnityFramework/StorageSlot.cs
// Created: 2022-05-19-11:40 PM
// *********************************************************************************************************************

namespace Levels.UnityFramework.DataStructure.NodeMatrix
{
    using Levels.UnityFramework.Storage;
    using UnityEngine;
    
    public class StorageSlot : Node<GameObject>
    {
        public StorageSlot((int x, int y) position) : base(position) { }

        public StorageSlot() { }
    }
}