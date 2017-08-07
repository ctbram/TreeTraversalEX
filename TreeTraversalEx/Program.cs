using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace TreeTraversalEx
{
    class Program
    {
        static void Main(string[] args)
        {
            BTree bt = new BTree();
            char[] data = { 'F', 'D', 'B', 'A', 'C', 'E', 'J', 'G', 'I', 'K', 'H' };

            foreach (char v in data)
            {
                bt.Add(v);
            }

            Console.Write("Pre-Order:  ");
            bt.PreOrder(bt.Root);
            Console.WriteLine();

            Console.Write("In-Order:  ");
            bt.InOrder(bt.Root);
            Console.WriteLine();

            Console.Write("Post-Order:  ");
            bt.PostOrder(bt.Root);
            Console.WriteLine();

            Console.Write("Breath-First:  ");
            bt.BreathFirst(bt.Root);
            Console.WriteLine();

            Console.WriteLine("Height of the tree is {0}", bt.FindHeight(bt.Root));

            Console.WriteLine("Total nodes in the tree is {0}", bt.Count);
        }
    }

    class Node
    {
        public char? Value;
        public Node Left;
        public Node Right;

        public Node(char? v)
        {
            Value = v;
            Left = null;
            Right = null;
        }
    }

    class BTree
    {
        public Node Root;
        public int Count { get; private set; }


        public BTree()
        {
            Root = null;
            Count = 0;
        }

        public BTree(char? v)
        {
            Root = new Node(v);
            Count = 1;
        }

        //add a value to the tree using a non-recursive search
        //====================================================
        public void Add(char? v)
        {
            //non-recursive add

            // tree is empty
            if (Root == null)
            {
                Node n = new Node(v);
                Root = n;
                Count++;
                return;
            }

            //tree is not empty
            Node cn = Root;
            bool added = false;
            do
            {
                if (v < cn.Value)
                {
                    //go left
                    if (cn.Left == null)
                    {
                        //add the node
                        Node n = new Node(v);
                        cn.Left = n;
                        Count++;
                        added = true;
                    }
                    else
                    {
                        cn = cn.Left;
                    }
                }

                if (v >= cn.Value)
                {
                    //go right
                    if (cn.Right == null)
                    {
                        //add the node
                        Node n = new Node(v);
                        cn.Right = n;
                        Count++;
                        added = true;
                    }
                    else
                    {
                        cn = cn.Right;
                    }
                }
            } while (!added);
        }

        // add a value to the tree using a recursive search
        //=================================================
        public void AddRc(char? v)
        {
            //recursive add
            AddR(ref Root, v);
        }

        private void AddR(ref Node n, char? v)
        {
            //private recursive search for place to add the new node
        }


        // Depth-First Binary Tree Traversal methods
        // Pre-Order, In-Order, Post-Order traversals of a char Btree
        //===========================================================
        public void PreOrder(Node root)
        {
            if (root != null)
            {
                Console.Write(root.Value);
                PreOrder(root.Left);
                PreOrder(root.Right);
            }
        }

        public void InOrder(Node root)
        {
            if (root != null)
            {
                InOrder(root.Left);
                Console.Write(root.Value);
                InOrder(root.Right);
            }
        }

        public void PostOrder(Node root)
        {
            if (root != null)
            {
                PostOrder(root.Left);
                PostOrder(root.Right);
                Console.Write(root.Value);
            }
        }


        //Breath-First Binary Tree Traversal methods
        //===========================================
        public void BreathFirst(Node root)
        {
            Queue<Node> queue = new Queue<Node>();

            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                Node dn = queue.Dequeue();
                Console.Write(dn.Value);
                if (dn.Left != null)
                {
                    queue.Enqueue(dn.Left);
                }
                if (dn.Right != null)
                {
                    queue.Enqueue(dn.Right);
                }
            }
        }

        //find the height of a binary tree
        //==================================
        public int FindHeight(Node root)
        {
            if (root == null)
                return -1;

            int leftHeight = FindHeight(root.Left);
            int rightHeight = FindHeight(root.Right);
            return Math.Max(leftHeight, rightHeight) + 1;
        }

    }

}
