using DataLayer.BinaryTree;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace functional_tree_traversal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BinaryTree _tree;

        private void PaintTree()
        {
            if (_tree == null) return;

            MemoryStream ms = new MemoryStream();
            System.Drawing.Image img = _tree.Draw();
            if (img != null)
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                ms.Position = 0;
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = ms;
                bi.EndInit();

                this.Image1.Source = bi;
            }

            this.StatusBarItem1.Content = "The number of nodes are " + _tree.Count;
        }

        public MainWindow()
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
    }
}