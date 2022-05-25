// *********************************************************************************************************************
// Created: Sys0 
// Levels.ConsoleApp/Levels.UnityFramework/StorageSlot.cs
// Created: 2022-05-19-11:40 PM
// *********************************************************************************************************************

namespace Levels.UnityFramework.Storage
{
    using System;
    using System.Collections.Generic;
    using Levels.UnityFramework.Storage.Datatypes;
    using UnityEngine;
    
    public class StorageSlot
    {
        public Vector2 Position;
        public GameObject Holding;
        public readonly List<Tuple<StorageSlot, LinkTypes>> Links = new List<Tuple<StorageSlot, LinkTypes>>();

        public StorageSlot(Vector2 position)
        {
            Position = position;
        }

        public bool IsConnectedTo(Vector2 to)
        {
            bool flag = false;
            
            for (int i = 0; i < Links.Count; i++)
            {
                flag = flag || (Links[i].Item1.Position == to && Links[i].Item2 == LinkTypes.Connected);
            }

            return flag;
        }
        
        public bool IsLockedTo(Vector2 to)
        {
            bool flag = false;
            
            for (int i = 0; i < Links.Count; i++)
            {
                flag = flag || (Links[i].Item1.Position == to && Links[i].Item2 == LinkTypes.Locked);
            }

            return flag;
        }
        
        public bool IsDisconnectedTo(Vector2 to)
        {
            bool flag = false;
            
            for (int i = 0; i < Links.Count; i++)
            {
                flag = flag || (Links[i].Item1.Position == to && Links[i].Item2 == LinkTypes.Disconnected);
            }

            return flag;
        }
        
        public bool IsHasAConnectionTo(Vector2 to)
        {
            bool flag = false;
            
            for (int i = 0; i < Links.Count; i++)
            {
                flag = flag || (Links[i].Item1.Position == to);
            }

            return flag;
        }
    }
}