namespace Levels.Inventory
{
    using System;
    using UnityEngine;

    [Serializable]
    public struct SlotConnection
    {
        [SerializeField]
        public Vector2 From;
        public Vector2 To;
        public bool Connected;
        public ConnectionTypes Connection;

        public SlotConnection(Vector2 from, Vector2 to, bool connected = true, ConnectionTypes connection = ConnectionTypes.Connected)
        {
            From = from;
            To = to;
            Connected = connected;
            Connection = connection;
        }
    }
}

