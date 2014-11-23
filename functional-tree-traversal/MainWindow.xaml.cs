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

            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

            //_tree = new BinaryTree();

            TreeDatabase td = new TreeDatabase();
            _tree = td.Load();

            bool result = _tree.Add(new Node(new NodeData { Age = 30, Name = "Pippo" }));
            PaintTree();

            _tree.Add(new Node(new NodeData { Age = 6, Name = "Pluto" }));
            PaintTree();

            _tree.Add(new Node(new NodeData { Age = 5, Name = "Qui" }));
            PaintTree();

            _tree.Add(new Node(new NodeData { Age = 22, Name = "Quo" }));
            PaintTree();

            _tree.Add(new Node(new NodeData { Age = 42, Name = "QuaRush" }));
            PaintTree();

            System.Console.WriteLine("The sum of nodes are " + _tree.Count);
            Console.ReadLine();

            Console.WriteLine("Inorder traversal resulting Tree Sort");
            Inorder(_tree.RootNode);
            Console.WriteLine(" ");

            Console.WriteLine();
            Console.WriteLine("Preorder traversal");
            Preorder(_tree.RootNode);
            Console.WriteLine(" ");

            Console.WriteLine();
            Console.WriteLine("Postorder traversal");
            Postorder(_tree.RootNode);
            Console.WriteLine(" ");

            Console.WriteLine();
            Console.WriteLine("Exists an item in the tree");
            Console.WriteLine(_tree.Exists(new Node(new NodeData { Age = 22, Name = "Quo" })));

            td.DeleteAll();
            td.Save(_tree);
        }

        void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            this.StatusBarItem1.Content = "Update tree in progress...";
            this.UpdateLayout();
            PaintTree();
        }

        public void Preorder(Node Root)
        {
            if (Root != null)
            {
                Console.Write(Root.Value.NodeId.ToString() + " ");
                Preorder(Root.Left);
                Preorder(Root.Right);
            }
        }

        public void Inorder(Node Root)
        {
            if (Root != null)
            {
                Inorder(Root.Left);
                Console.Write(Root.Value.NodeId.ToString() + " ");
                Inorder(Root.Right);
            }
        }

        public void Postorder(Node Root)
        {
            if (Root != null)
            {
                Postorder(Root.Left);
                Postorder(Root.Right);

                Console.Write(Root.Value.NodeId.ToString() + " ");
            }
        }
    }
}