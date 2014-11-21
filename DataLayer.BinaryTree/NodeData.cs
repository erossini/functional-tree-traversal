using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.BinaryTree
{
    public class NodeData
    {
        public int Age { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// get or set the value of id node from database
        /// </summary>
        public int NodeId { get; set; }
    }
}
