using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Tree
{
    public class Node<T>
    {
        public T data;
        public Node<T> left;
        public Node<T> right;

        public Node(T value)
        {
            this.data = value;
            left = null;
            right = null;
        }
    }
}
