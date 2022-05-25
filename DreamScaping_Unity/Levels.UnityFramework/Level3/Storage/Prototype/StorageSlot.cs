﻿// *********************************************************************************************************************
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
        public readonly List<Tuple<StorageSlot, ConnectionTypes>> Connections = new List<Tuple<StorageSlot, ConnectionTypes>>();

        public StorageSlot(Vector2 position)
        {
            Position = position;
        }

        public bool IsConnectedTo(Vector2 to)
        {
            bool flag = false;
            
            for (int i = 0; i < Connections.Count; i++)
            {
                flag = flag || (Connections[i].Item1.Position == to && Connections[i].Item2 == ConnectionTypes.Connected);
            }

            return flag;
        }
        
        public bool IsLockedTo(Vector2 to)
        {
            bool flag = false;
            
            for (int i = 0; i < Connections.Count; i++)
            {
                flag = flag || (Connections[i].Item1.Position == to && Connections[i].Item2 == ConnectionTypes.Locked);
            }

            return flag;
        }
        
        public bool IsDisconnectedTo(Vector2 to)
        {
            bool flag = false;
            
            for (int i = 0; i < Connections.Count; i++)
            {
                flag = flag || (Connections[i].Item1.Position == to && Connections[i].Item2 == ConnectionTypes.Disconnected);
            }

            return flag;
        }
        
        public bool IsHasAConnectionTo(Vector2 to)
        {
            bool flag = false;
            
            for (int i = 0; i < Connections.Count; i++)
            {
                flag = flag || (Connections[i].Item1.Position == to);
            }

            return flag;
        }
    }
}