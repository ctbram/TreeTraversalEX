using System;
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

            Console.WriteLine("Breadthwise Print:");
            bt.BreadthWisePrint(bt.Root);
        }
    }
}
