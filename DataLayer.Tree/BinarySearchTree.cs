using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Tree
{
    public class BinarySearchTree
    {
        public Node<NodeData> root;
        static int count;

        /// <summary>
        /// Create the root of the binary tree
        /// </summary>
        public BinarySearchTree()
        {
            root = null;
        }

        /// <summary>
        /// Add a node in the binary tree
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Node<NodeData> AddNode(NodeData data)
        {
            Node<NodeData> newNode = new Node<NodeData>(data);

            if (root == null)
            {
                root = newNode;

            }
            count++;
            return newNode;
        }

        /// <summary>
        /// Count of items in binary tree
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return count;
        }

        /// <summary>
        /// Insert a node in the binary tree
        /// </summary>
        /// <param name="root">Node of root of binary tree</param>
        /// <param name="newNode">The new node to insert in the tree</param>
        public void InsertNode(Node<NodeData> root, Node<NodeData> newNode)
        {
            Node<NodeData> temp;
            temp = root;

            if (newNode.data.Age < temp.data.Age)
            {
                if (temp.left == null)
                {
                    temp.left = newNode;
                }

                else
                {
                    temp = temp.left;
                    InsertNode(temp, newNode);
                }
            }
            else if (newNode.data.Age > temp.data.Age)
            {
                if (temp.right == null)
                {
                    temp.right = newNode;
                }

                else
                {
                    temp = temp.right;
                    InsertNode(temp, newNode);
                }
            }
        }

        /// <summary>
        /// Display all detail of the tree
        /// </summary>
        /// <param name="root"></param>
        public void DisplayTree(Node<NodeData> root)
        {
            Node<NodeData> temp;
            temp = root;

            if (temp == null)
                return;

            DisplayTree(temp.left);
            System.Console.Write(temp.data.Age + "-" + temp.data.Name + "   ");
            DisplayTree(temp.right);
        }
    }
}