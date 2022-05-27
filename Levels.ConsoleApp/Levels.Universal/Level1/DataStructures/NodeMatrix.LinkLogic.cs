// *********************************************************************************************************************
// Created: Sys0 
// Levels.ConsoleApp/Levels.UnityFramework/LinksBroker.cs
// Created: 2022-05-24-10:14 PM
// *********************************************************************************************************************

namespace Levels.UnityFramework.DataStructure.NodeMatrix.LinkLogic
{
    using System.Collections.Generic;
    using Levels.UnityFramework.DataStructure.NodeMatrix.Datatypes;
    using Levels.UnityFramework.Storage;
    using Levels.Universal;

    // TODO: go over comments.
    // TODO: Make Levels.ConsoleApp representation tests.
    // TODO: Make unit tests.
    public static class NodeMatrixExtension
    {
        /// <summary>
        /// Checks if there is a connection between the two slots <see cref="a"/> and <see cref="b"/> at index <see cref="i"/> in <see cref="storage"/>
        /// </summary>
        /// <param name="nodeage">The <see cref="NodeMatrix{TN}"/> to be using.</param>
        /// <param name="a">One of two slots to check the link on.</param>
        /// <param name="b">One of two slots to check the link on.</param>
        /// <param name="i">The index to check for the link at.</param>
        /// <returns></returns>
        public static bool IsLinkedAt<TN>(this NodeMatrix<TN> nodes, Node<TN> a, Node<TN> b, int i)
        {
            var storageLink = nodes._links[i];
            
            return storageLink.nodeA == a && storageLink.nodeB == b ||
                   storageLink.nodeA == b && storageLink.nodeB == a;
        }
        
        /// <summary>
        /// Used to see if there is a connection between two slots in a <see cref="NodeMatrix{TN}"/>.
        /// </summary>
        /// <param name="nodeage">The <see cref="NodeMatrix{TN}"/> to check against.</param>
        /// <param name="a">One of the two StorageSlots the connection is on.</param>
        /// <param name="b">One of the two StorageSlots the connection is on.</param>
        /// <returns>True if there is a link. False if there is not.</returns>
        public static bool IsLinked<TN>(this NodeMatrix<TN> nodes, Node<TN> a, Node<TN> b)
        {
            bool flag = false;
            
            for (int i = 0; i < nodes._links.Count; i++)
            {
                flag = IsLinkedAt(nodes, a, b, i) || flag;
            }

            return flag;
        }

        /// <summary>
        /// Returns a copy of the slot link if it exists.
        /// </summary>
        /// <param name="nodeage">The <see cref="NodeMatrix{TN}"/> to check against.</param>
        /// <param name="a">One of the two StorageSlots the link is on.</param>
        /// <param name="b">One of the two StorageSlots the link is on.</param>
        /// <returns>Will return the link if it exists, otherwise the returned link will be empty,
        /// check value for link.</returns>
        public static (Node<TN>slotA, Node<TN>slotB, ConnectionTypes connection) ViewLinkFor<TN>(this NodeMatrix<TN> nodes, Node<TN> a, Node<TN> b)
        {
            for (int i = 0; i < nodes._links.Count; i++)
            {
                if (IsLinkedAt(nodes, a, b, i))
                    return nodes._links[i];
            }
            
            return (null, null, ConnectionTypes.Not);
        }


        /// <summary>
        /// Used to see if there is a connection between two slots in a <see cref="NodeMatrix{TN}"/>
        /// , and the type is Connected.
        /// </summary>
        /// <param name="nodeage">The <see cref="NodeMatrix{TN}"/> to check against.</param>
        /// <param name="a">One of the two StorageSlots the connection is on.</param>
        /// <param name="b">One of the two StorageSlots the connection is on.</param>
        /// <param name="type">The type of <see cref="ConnectionTypes"/> to compare against.</param>
        /// <returns>True if there is a link of type. False if there is not.
        /// You should check the link exists first. </returns>
        public static bool IsLinkType<TN>(this NodeMatrix<TN> nodes, Node<TN> a, Node<TN> b, ConnectionTypes type)
        {
            var holder = ViewLinkFor(nodes, a, b);

            if (holder.slotA is null)
                return false;

            return holder.connection == type;
        }
        
        /// <summary>
        /// Returns the first connection of Slots A and B.
        /// </summary>
        /// <param name="nodeage">The <see cref="NodeMatrix{TN}"/> to check against.</param>
        /// <param name="a">One of the two StorageSlots the connection is on.</param>
        /// <param name="b">One of the two StorageSlots the connection is on.</param>
        /// <returns></returns>
        public static ConnectionTypes CheckLinkType<TN>(this NodeMatrix<TN> node, Node<TN> a, Node<TN> b)
        {
            for (int i = 0; i < node._links.Count; i++)
            {
                if (IsLinkedAt(node, a, b, i))
                    return node._links[i].Connection;
            }

            return ConnectionTypes.Not;
        }
        
        /// <summary>
        /// Returns all connections of Slots A and B.
        /// </summary>
        /// <param name="nodeage">The <see cref="NodeMatrix{TN}"/> to check against.</param>
        /// <param name="a"> StorageSlots the connection is on.</param>
        /// <returns>Returns all connections on <see cref="a"/>.</returns>
        public static ConnectionTypes[] CheckConnectionsType<TN>(this NodeMatrix<TN> node, Node<TN> a)
        {
            var empty = true;
            var connections = new ConnectionTypes[4];
            var index = 0;
            
            for (int i = 0; i < node._links.Count; i++)
            {
                bool flag = node._links[i].nodeA == a || node._links[i].nodeB == a;
                
                if (flag)
                {
                    empty = false;
                    connections[index++] = node._links[i].Connection;
                }
            }
            
            if (empty)
                connections[0] = ConnectionTypes.Not;
            
            return connections;
        }
        
        /// <summary>
        /// Will change the <see cref="ConnectionTypes"/> on the link if there is any found.
        /// </summary>
        /// <param name="nodeage">The <see cref="NodeMatrix{TN}"/> that the link is in.</param>
        /// <param name="link">The link details for the new connection.</param>
        /// <returns>True if the connection was changed. False if not.</returns>
        public static bool ChangeConnectionType<TN>(this NodeMatrix<TN> node, (Node<TN> a, Node<TN> b, ConnectionTypes type) link)
        {
            var result = ViewLinkFor(node, link.a, link.b);
            if (result.connection != ConnectionTypes.Not)
            {
                if (result.connection == link.type)
                    return true;
                
                node._links.Remove(result);
                node._links.Add(link);

                return true;
            }
            
            return false;
        }
        
        /// <summary>
        /// Returns a copy of all links for <see cref="a"/> if there are any.
        /// </summary>
        /// <param name="nodeage">The <see cref="NodeMatrix{TN}"/> to check against.</param>
        /// <param name="a">The StorageSlots the links are on.</param>
        /// <returns>Will return all links if any exist, otherwise the returned link will be empty,
        /// check value for link.
        /// The returned List will have the requested slot first in the tuple.</returns>
        public static List<(Node<TN> nodeA, Node<TN> nodeB, ConnectionTypes Connection)> ViewLinksOn<TN>(this NodeMatrix<TN> node, Node<TN> a)
        {
            var holder = new List<(Node<TN> nodeA, Node<TN> nodeB, ConnectionTypes Connection)>();
            var flag = false;

            for (int i = 0; i < node._links.Count; i++)
            {
                if (node._links[i].nodeA == a)
                {
                    holder.Add(node._links[i]);
                    flag = true;
                }
                else if (node._links[i].nodeB == a)
                {
                    holder.Add((node._links[i].nodeB, node._links[i].nodeA, node._links[i].Connection));
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
        /// <param name="nodeage"></param>
        /// <param name="link"></param>
        /// <returns> Will return true if added, else will return false(like if it already existed).</returns>
        public static bool TryLink<TN>(this NodeMatrix<TN> node, (Node<TN> nodeA, Node<TN> nodeB, ConnectionTypes Connection)  link)
        {
            if (IsLinked(node, link.nodeA, link.nodeB))
                return false;

            node._links.Add(link);
            
            return true;
        }
        
        /// <summary>
        /// Will try to add the <see cref="link"/> to the <see cref="storage"/>.
        /// Check to make sure the link doesn't already exist, or exists with a different connection.
        /// </summary>
        /// <param name="nodeage"></param>
        /// <param name="link"></param>
        /// <returns> Will return true if added, else will return false(like if it already existed).</returns>
        public static Report Link<TN>(this NodeMatrix<TN> node, (Node<TN> nodeA, Node<TN> nodeB, ConnectionTypes Connection)  link)
        {
            var report = new Report();
            
            var result = CheckLinkType(node, link.nodeA, link.nodeB);
            if (result != ConnectionTypes.Not)
            {
                report.Add(Report.AlreadyExists("A connection of type " + result + " already exists."));
            }
            else
            {
                node._links.Add(link);
            }
            
            return report;
        }

        /// <summary>
        /// Will try to unlink <see cref="slotA"/> and <see cref="slotB"/>.
        /// </summary>
        /// <param name="nodeage">The <see cref="NodeMatrix{TN}"/> that the link will be removed from.</param>
        /// <param name="link">The link that will be tried to be removed.</param>
        /// NOTE: slotA and slotB aren't ordered.
        /// <returns></returns>
        public static bool TryUnlink<TN>(this NodeMatrix<TN> node, (Node<TN> nodeA, Node<TN> nodeB, ConnectionTypes Connection)  link)
        {
            if (IsLinked(node, link.nodeA, link.nodeB))
                node._links.Remove(link);

            node._links.Add(link);
            
            return true;
        }
    }
}