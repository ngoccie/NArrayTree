using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NArrayTree
{
    class Program
    {
        static void Main(string[] args)
        {
            //Build a Tree
            TreeNode<string> root = new TreeNode<string>("FOOD");
            Tree<string> tree = new Tree<string>(root);

            //Add Child to Parent
            TreeNode<string> node1 = root.AddChildNode("Pizza");
            TreeNode<string> node2 = root.AddChildNode("IceCream");
            TreeNode<string> node3 = root.AddChildNode("Rice");

            TreeNode<string> node21 = node2.AddChildNode("Strawberry");
            TreeNode<string> node22 = node2.AddChildNode("RedBeans");

            TreeNode<string> node211 = node21.AddChildNode("Cheesecake");
            TreeNode<string> node212 = node21.AddChildNode("Almond");

            TreeNode<string> node4 = root.AddChildNode("Sushi");
            TreeNode<string> node41 = node4.AddChildNode("Inari");

            //Print tree
            foreach (TreeNode<string> i in root)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("# Nodes of tree : " + tree.Count());
            Console.WriteLine("# Leafs of tree: " + tree.LeafCount() + "\n");
            
            //Print tree after removal
            root.RemoveNode(node1);
            foreach (TreeNode<string> i in root)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("# Nodes of tree : " + tree.Count());
            Console.WriteLine("# Leafs of tree: " + tree.LeafCount() + "\n");

            //Print sum to leafs
            Console.WriteLine("Sum to Leafs: ");
            List<string> sum = root.SumToLeafs();
            foreach (string s in sum)
            {
                Console.WriteLine(s);
            }
            Console.ReadLine();
        }
    }
}
