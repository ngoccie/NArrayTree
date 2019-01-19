using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NArrayTree
{
    public class TreeNode<T>:IEnumerable<TreeNode<T>>
    {
        public T Value { get; set; }
        public TreeNode<T> ParentNode { get; set; }
        public List<TreeNode<T>> Children { get; set; }

        public TreeNode(T value)
        {
            Value = value;
            Children = new List<TreeNode<T>>();
        }

        //Adds new TreeNode with supplied value to Tree below node parentNode
        public TreeNode<T> AddChildNode(T node)
        {
            TreeNode<T> childNode = new TreeNode<T>(node) { ParentNode = this };          
            Children.Add(childNode);
            return childNode;
        }

        public override string ToString()
        {
            return Value != null ? Value.ToString() : "[null]";
        }

        //Iterator, it returns all node values
        private IEnumerator<TreeNode<T>> CreateEnumerator()
        {
            yield return this;
            foreach (var child in this.Children)
            {
                foreach (var childChild in child)
                    yield return childChild;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return CreateEnumerator();
        }
        public IEnumerator<TreeNode<T>> GetEnumerator()
        {
            return CreateEnumerator();
        }

        //Remove specific TreeNode from Tree
        public bool RemoveNode(TreeNode<T> node)
        {
            return Children.Remove(node);
        }

        //Returns only all summed node values on the paths to each leaf node
        public List<T> SumToLeafs()
        {
            List<T> sum2leafs = new List<T>();
            foreach (TreeNode<T> val in this)
            {
                if (val.Children.Count() == 0)
                {
                    dynamic addAll = default(T);
                    TreeNode<T> leafnode = val;
                    while (leafnode.ParentNode != null)
                    {
                        addAll = leafnode.Value + addAll;
                        leafnode = leafnode.ParentNode;
                    }
                    sum2leafs.Add(this.Value + addAll);
                }
            }
            return sum2leafs;
        }
    }
}