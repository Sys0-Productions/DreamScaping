// *********************************************************************************************************************
// Created: Sys0 
// Levels.ConsoleApp/Levels.UnityFramework/LinksBroker.cs
// Created: 2022-05-24-10:14 PM
// *********************************************************************************************************************

namespace Levels.UnityFramework.Storage
{
    using System;
    using System.Collections.Generic;
    using Levels.UnityFramework.Storage.Datatypes;
    using System.Linq;
    
    public partial class StorageMatrix
    {
        private readonly List<(StorageSlot SlotA, StorageSlot SlotB, LinkTypes Link)> _links = new List<(StorageSlot SlotA, StorageSlot SlotB, LinkTypes Link)>();

        /// <summary>
        /// Used to see if there is a connection between two slots in a <see cref="StorageMatrix"/>.
        /// </summary>
        /// <param name="storage">The <see cref="StorageMatrix"/> to check against.</param>
        /// <param name="a">One of the two StorageSlots the connection is on.</param>
        /// <param name="b">One of the two StorageSlots the connection is on.</param>
        /// <returns>True if there is a link. False if there is not.</returns>
        public static bool IsLinked(StorageMatrix storage, StorageSlot A, StorageSlot B)
        {
            bool flag = false;
            
            for (int i = 0; i < storage._links.Count; i++)
            {
                flag = (storage._links[i].Item1 == A &&
                        storage._links[i].Item2 == B ^
                        storage._links[i].Item1 == B &&
                        storage._links[i].Item2 == A) || 
                       flag;
            }

            return flag;
        }
        
        /// <summary>
        /// Used to see if there is a connection between two slots in a <see cref="StorageMatrix"/>
        /// , and the type is Connected.
        /// </summary>
        /// <param name="storage">The <see cref="StorageMatrix"/> to check against.</param>
        /// <param name="a">One of the two StorageSlots the connection is on.</param>
        /// <param name="b">One of the two StorageSlots the connection is on.</param>
        /// <returns>True if there is a link of type. False if there is not.
        /// You should check the link exists first. </returns>
        public static bool IsLinkType(StorageMatrix storage, StorageSlot a, StorageSlot b, LinkTypes type)
        {
            var holder = ViewLinkFor(storage, a, b);

            if (holder.SlotA is null)
                return false;

            return holder.Link == type;
        }
        
        /// <summary>
        /// Returns the first connection of Slots A and B.
        /// </summary>
        /// <param name="storage">The <see cref="StorageMatrix"/> to check against.</param>
        /// <param name="a">One of the two StorageSlots the connection is on.</param>
        /// <param name="b">One of the two StorageSlots the connection is on.</param>
        /// <returns></returns>
        public static LinkTypes CheckLinkType(StorageMatrix storage, StorageSlot a, StorageSlot b)
        {
            bool flag = false;
            
            for (int i = 0; i < storage._links.Count; i++)
            {
                flag = storage._links[i].Item1 == a && storage._links[i].Item2 == b ||
                       storage._links[i].Item1 == b && storage._links[i].Item2 == a;

                if (flag)
                    return storage._links[i].Item3;
            }

            return LinkTypes.Not;
        }
        
        /// <summary>
        /// Returns all connections of Slots A and B.
        /// </summary>
        /// <param name="storage">The <see cref="StorageMatrix"/> to check against.</param>
        /// <param name="a"> StorageSlots the connection is on.</param>
        /// <returns>Returns all connections on <see cref="a"/>.</returns>
        public static LinkTypes[] CheckLinkType(StorageMatrix storage, StorageSlot a)
        {
            var empty = true;
            var connections = new LinkTypes[4];
            var index = 0;
            
            for (int i = 0; i < storage._links.Count; i++)
            {
                bool flag = storage._links[i].Item1 == a || storage._links[i].Item2 == a;
                
                if (flag)
                {
                    empty = false;
                    connections[index++] = storage._links[i].Item3;
                }
            }
            
            if (empty)
                connections[0] = LinkTypes.Not;
            
            return connections;
        }
        
        public static bool ChangeLinkType(StorageMatrix storage, StorageSlot a, StorageSlot b, LinkTypes type)
        {
            throw new InvalidOperationException();
        }
        
        public static List<(StorageSlot SlotA, StorageSlot SlotB, LinkTypes Link)> ViewLinksOn(StorageMatrix storage, StorageSlot a)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns a copy of the slot connection
        /// </summary>
        /// <param name="storage">The <see cref="StorageMatrix"/> to check against.</param>
        /// <param name="a">One of the two StorageSlots the connection is on.</param>
        /// <param name="b">One of the two StorageSlots the connection is on.</param>
        /// <returns>Will return the connection if it exists, otherwise the returned link will be empty,
        /// check value for link.</returns>
        public static (StorageSlot SlotA, StorageSlot SlotB, LinkTypes Link) ViewLinkFor(StorageMatrix storage, StorageSlot a, StorageSlot b)
        {
            for (int i = 0; i < storage._links.Count; i++)
            {
                if (storage._links[i].Item1 == a && storage._links[i].Item2 == b ||
                    storage._links[i].Item1 == b && storage._links[i].Item2 == a)
                    return storage._links[i].ToValueTuple();
            }
            
            return (null, null, LinkTypes.Not);
        }

        public static bool Link(StorageMatrix storage, Tuple<StorageSlot, StorageSlot, LinkTypes> link)
        {
            throw new InvalidOperationException();
        }

        public static bool Unlink(StorageMatrix storage, StorageSlot a, StorageSlot b)
        {
            throw new InvalidOperationException();
        }
    }
}