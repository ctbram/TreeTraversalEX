using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace TreeTraversalEx
{
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

        //Breathwise print
        //==================================
        public void BreadthWisePrint(Node root)
        {
            Queue<Node> q = new Queue<Node>();

            q.Enqueue(root);
            q.Enqueue(null);

            while (q.Count > 1)
            {
                Node n = q.Dequeue();
                if (n != null)
                {
                    Console.Write(n.Value);
                    if (n.Left != null) q.Enqueue(n.Left);
                    if (n.Right != null) q.Enqueue(n.Right);
                }
                else
                {
                    Console.WriteLine();
                    q.Enqueue(null);
                }
            }
            Console.WriteLine();
        }
    }
}