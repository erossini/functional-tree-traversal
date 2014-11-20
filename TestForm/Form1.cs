using DataLayer.BinaryTree;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestForm
{
    public partial class Form1 : Form
    {
        private BinaryTree _tree;

        public Form1()
        {
            InitializeComponent();

            _tree = new BinaryTree();
            bool result = _tree.Add(new Node(new NodeData { Age = 30, Name = "Pippo" }));
            PaintTree();

            _tree.Add(new Node(new NodeData { Age = 6, Name = "Pluto" }));
            PaintTree();

            _tree.Add(new Node(new NodeData { Age = 5, Name = "Qui" }));
            PaintTree();

            _tree.Add(new Node(new NodeData { Age = 22, Name = "Quo" }));
            PaintTree();

            _tree.Add(new Node(new NodeData { Age = 40, Name = "Qua" }));
            PaintTree();

            System.Console.WriteLine("The sum of nodes are " + _tree.Count);
            Console.ReadLine();
        }

        private void PaintTree()
        {
            if (_tree == null) return;
            this.pictureBox1.Image = _tree.Draw();
        }
    }
}
