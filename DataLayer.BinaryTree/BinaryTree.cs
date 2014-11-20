﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace DataLayer.BinaryTree
{
    public class BinaryTree
    {
        /// <summary>
        /// the root nod, it won't be seen on the graph!
        /// </summary>
        public Node RootNode { get; private set; }
        static int count;

        public BinaryTree()
        {
            RootNode = new Node(new NodeData { Age = 0, Name = "" });
        }

        /// <summary>
        /// gets the count of nodes on the tree
        /// </summary>
        public int Count { get { return count; } }

        /// <summary>
        /// adds a node to the tree
        /// </summary>
        public bool Add(Node node)
        {
            bool rtn = false;

            if (RootNode == null)
            {
                RootNode = node;
                count++;
                rtn = true;
            }
            else
            {
                rtn = RootNode.Add(node);
                if (rtn)
                    count++;
            }

            return rtn;
        }

        /// <summary>
        /// Removes the node containing the inserted value.
        /// returns true if could find and remove the node.
        /// return false if the value does not exist on any of nodes. (except rootnode)
        /// </summary>
        public bool Remove(Node value)
        {
            bool isRootNode;
            var res = RootNode.Remove(value, out isRootNode);
            return !isRootNode && res;// return false if the inserted value is on rootNode, or the value does not exist on any of nodes
        }

        // draw
        public Image Draw()
        {
            GC.Collect(); // collects the unreffered locations on the memory
            int temp;
            return RootNode.Right == null ? null : RootNode.Right.Draw(out temp);
        }

        /// <summary>
        /// returns true if the current node or it's childs containd the inserted value
        /// </summary>
        public bool Exists(Node item)
        {
            return RootNode.Exists(item);
        }
    }
}