// *********************************************************************************************************************
// Created: Sys0 
// Levels.ConsoleApp/Levels.UnityFramework/LinksBroker.cs
// Created: 2022-05-24-10:14 PM
// *********************************************************************************************************************

namespace Levels.UnityFramework.Storage
{
    using System.Collections.Generic;
    using Levels.UnityFramework.Storage.Datatypes;
    using Levels.Universal;

    // TODO: go over comments.
    // TODO: Make Levels.ConsoleApp representation tests.
    // TODO: Make unit tests.
    public partial class StorageMatrix
    {
        private readonly List<(StorageSlot slotA, StorageSlot slotB, ConnectionTypes Connection)> _links = 
            new List<(StorageSlot slotA, StorageSlot slotB, ConnectionTypes Connection)>();

        /// <summary>
        /// Checks if there is a connection between the two slots <see cref="a"/> and <see cref="b"/> at index <see cref="i"/> in <see cref="storage"/>
        /// </summary>
        /// <param name="storage">The <see cref="StorageMatrix"/> to be using.</param>
        /// <param name="a">One of two slots to check the link on.</param>
        /// <param name="b">One of two slots to check the link on.</param>
        /// <param name="i">The index to check for the link at.</param>
        /// <returns></returns>
        private static bool IsLinkedAt(StorageMatrix storage, StorageSlot a, StorageSlot b, int i)
        {
            var storageLink = storage._links[i];
            
            return storageLink.Item1 == a && storageLink.Item2 == b ||
                   storageLink.Item1 == b && storageLink.Item2 == a;
        }
        
        /// <summary>
        /// Used to see if there is a connection between two slots in a <see cref="StorageMatrix"/>.
        /// </summary>
        /// <param name="storage">The <see cref="StorageMatrix"/> to check against.</param>
        /// <param name="a">One of the two StorageSlots the connection is on.</param>
        /// <param name="b">One of the two StorageSlots the connection is on.</param>
        /// <returns>True if there is a link. False if there is not.</returns>
        public static bool IsLinked(StorageMatrix storage, StorageSlot a, StorageSlot b)
        {
            bool flag = false;
            
            for (int i = 0; i < storage._links.Count; i++)
            {
                flag = IsLinkedAt(storage, a, b, i) || flag;
            }

            return flag;
        }

        /// <summary>
        /// Returns a copy of the slot link if it exists.
        /// </summary>
        /// <param name="storage">The <see cref="StorageMatrix"/> to check against.</param>
        /// <param name="a">One of the two StorageSlots the link is on.</param>
        /// <param name="b">One of the two StorageSlots the link is on.</param>
        /// <returns>Will return the link if it exists, otherwise the returned link will be empty,
        /// check value for link.</returns>
        public static (StorageSlot slotA, StorageSlot slotB, ConnectionTypes connection) ViewLinkFor(StorageMatrix storage, StorageSlot a, StorageSlot b)
        {
            for (int i = 0; i < storage._links.Count; i++)
            {
                if (IsLinkedAt(storage, a, b, i))
                    return storage._links[i];
            }
            
            return (null, null, ConnectionTypes.Not);
        }


        /// <summary>
        /// Used to see if there is a connection between two slots in a <see cref="StorageMatrix"/>
        /// , and the type is Connected.
        /// </summary>
        /// <param name="storage">The <see cref="StorageMatrix"/> to check against.</param>
        /// <param name="a">One of the two StorageSlots the connection is on.</param>
        /// <param name="b">One of the two StorageSlots the connection is on.</param>
        /// <param name="type">The type of <see cref="ConnectionTypes"/> to compare against.</param>
        /// <returns>True if there is a link of type. False if there is not.
        /// You should check the link exists first. </returns>
        public static bool IsLinkType(StorageMatrix storage, StorageSlot a, StorageSlot b, ConnectionTypes type)
        {
            var holder = ViewLinkFor(storage, a, b);

            if (holder.slotA is null)
                return false;

            return holder.connection == type;
        }
        
        /// <summary>
        /// Returns the first connection of Slots A and B.
        /// </summary>
        /// <param name="storage">The <see cref="StorageMatrix"/> to check against.</param>
        /// <param name="a">One of the two StorageSlots the connection is on.</param>
        /// <param name="b">One of the two StorageSlots the connection is on.</param>
        /// <returns></returns>
        public static ConnectionTypes CheckLinkType(StorageMatrix storage, StorageSlot a, StorageSlot b)
        {
            for (int i = 0; i < storage._links.Count; i++)
            {
                if (IsLinkedAt(storage, a, b, i))
                    return storage._links[i].Connection;
            }

            return ConnectionTypes.Not;
        }
        
        /// <summary>
        /// Returns all connections of Slots A and B.
        /// </summary>
        /// <param name="storage">The <see cref="StorageMatrix"/> to check against.</param>
        /// <param name="a"> StorageSlots the connection is on.</param>
        /// <returns>Returns all connections on <see cref="a"/>.</returns>
        public static ConnectionTypes[] CheckConnectionsType(StorageMatrix storage, StorageSlot a)
        {
            var empty = true;
            var connections = new ConnectionTypes[4];
            var index = 0;
            
            for (int i = 0; i < storage._links.Count; i++)
            {
                bool flag = storage._links[i].slotA == a || storage._links[i].slotB == a;
                
                if (flag)
                {
                    empty = false;
                    connections[index++] = storage._links[i].Connection;
                }
            }
            
            if (empty)
                connections[0] = ConnectionTypes.Not;
            
            return connections;
        }
        
        /// <summary>
        /// Will change the <see cref="ConnectionTypes"/> on the link if there is any found.
        /// </summary>
        /// <param name="storage">The <see cref="StorageMatrix"/> that the link is in.</param>
        /// <param name="link">The link details for the new connection.</param>
        /// <returns>True if the connection was changed. False if not.</returns>
        public static bool ChangeConnectionType(StorageMatrix storage, (StorageSlot a, StorageSlot b, ConnectionTypes type) link)
        {
            var result = ViewLinkFor(storage, link.a, link.b);
            if (result.connection != ConnectionTypes.Not)
            {
                if (result.connection == link.type)
                    return true;
                
                storage._links.Remove(result);
                storage._links.Add(link);

                return true;
            }
            
            return false;
        }
        
        /// <summary>
        /// Returns a copy of all links for <see cref="a"/> if there are any.
        /// </summary>
        /// <param name="storage">The <see cref="StorageMatrix"/> to check against.</param>
        /// <param name="a">The StorageSlots the links are on.</param>
        /// <returns>Will return all links if any exist, otherwise the returned link will be empty,
        /// check value for link.</returns>
        public static List<(StorageSlot slotA, StorageSlot slotB, ConnectionTypes Connection)> ViewLinksOn(StorageMatrix storage, StorageSlot a)
        {
            var holder = new List<(StorageSlot slotA, StorageSlot slotB, ConnectionTypes Connection)>();
            var flag = false;

            for (int i = 0; i < storage._links.Count; i++)
            {
                if (storage._links[i].slotA == a || storage._links[i].slotB == a)
                {
                    holder.Add(storage._links[i]);
                    flag = true;
                }
            }
            
            if (!flag)
                holder.Add((null, null, ConnectionTypes.Not));
            
            return holder;
        }
        
        /// <summary>
        /// Will try to add the <see cref="link"/> to the <see cref="storage"/>.
        /// Check to make sure the link doesn't already exist, or exists with a different connection.
        /// </summary>
        /// <param name="storage"></param>
        /// <param name="link"></param>
        /// <returns> Will return true if added, else will return false(like if it already existed).</returns>
        public static bool TryLink(StorageMatrix storage, (StorageSlot slotA, StorageSlot slotB, ConnectionTypes Connection)  link)
        {
            if (IsLinked(storage, link.slotA, link.slotB))
                return false;

            storage._links.Add(link);
            
            return true;
        }
        
        /// <summary>
        /// Will try to add the <see cref="link"/> to the <see cref="storage"/>.
        /// Check to make sure the link doesn't already exist, or exists with a different connection.
        /// </summary>
        /// <param name="storage"></param>
        /// <param name="link"></param>
        /// <returns> Will return true if added, else will return false(like if it already existed).</returns>
        public static Report Link(StorageMatrix storage, (StorageSlot slotA, StorageSlot slotB, ConnectionTypes Connection)  link)
        {
            var report = new Report();
            
            var result = CheckLinkType(storage, link.slotA, link.slotB);
            if (result != ConnectionTypes.Not)
            {
                report.Add(Report.AlreadyExists("A connection of type " + result + " already exists."));
            }
            else
            {
                storage._links.Add(link);
            }
            
            return report;
        }

        /// <summary>
        /// Will try to unlink <see cref="slotA"/> and <see cref="slotB"/>.
        /// </summary>
        /// <param name="storage">The <see cref="StorageMatrix"/> that the link will be removed from.</param>
        /// <param name="link">The link that will be tried to be removed.</param>
        /// NOTE: slotA and slotB aren't ordered.
        /// <returns></returns>
        public static bool TryUnlink(StorageMatrix storage, (StorageSlot slotA, StorageSlot slotB, ConnectionTypes Connection)  link)
        {
            if (IsLinked(storage, link.slotA, link.slotB))
                storage._links.Remove(link);

            storage._links.Add(link);
            
            return true;
        }
    }
}