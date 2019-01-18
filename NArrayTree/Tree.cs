using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NArrayTree
{
    public class Tree<T>
    {
        private TreeNode<T> tree;
        public Tree(TreeNode<T> rootNode)
        {
            this.tree = rootNode;
        }

        //Number of Nodes in the Tree
        public int Count()
        {
            return tree.Count();
        }

        //Number of leaf Nodes in the Tree
        public int LeafCount()
        {
            int n = new int();
            foreach (TreeNode<T> i in tree)
            {
                if (i.Children.Count() == 0)
                {
                    ++n;
                }
            }
            return n;
        }
    }
}
