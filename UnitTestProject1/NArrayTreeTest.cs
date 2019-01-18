using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //geautomatiseerd geschreven test uitvoeren
using NArrayTree;
using System.Collections.Generic;

namespace NArrayTreeTest
{
    [TestFixture] //framework gaat voor iedere class met TestFixture kijken welke methods hij test moet uitvoeren adhv TestCase
    public class TreeNodeTest
    {
        [TestCase]
        public void TestIterator()
        {
            // Arrange
            List<string> list1 = new List<string>();
            list1.Add("noodles");
            list1.Add("pho");
            list1.Add("springroll");
            // Act
            List<string> list2 = new List<string>();
            foreach (string elem in list1)
            {
                list2.Add(elem);
            }
            // Assert
            CollectionAssert.AreEqual(list2, list1);
        }

        [TestCase]
        public void TestAddChildNode()
        {
            // Arrange
            TreeNode<int> root = new TreeNode<int>(3);
            root.AddChildNode(5);
            root.AddChildNode(4);
            // Act
            List<TreeNode<int>> childNode = root.Children;
            List<int> childValues = new List<int>();
            foreach (TreeNode<int> node in root.Children)
            {
                childValues.Add(node.Value);
            }
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(childValues.Count() == 2);
                Assert.Contains(5, childValues);
            });
        }

        [TestCase]
        public void TestToString()
        {
            // Arrange
            TreeNode<string> root = new TreeNode<string>(null);
            // Act
            string stringRoot = root.ToString();
            // Assert
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(stringRoot);
                Assert.That(stringRoot, Is.TypeOf<string>());
            });
        }

        [TestCase]
        public void TestRemoveNode()
        {
            //Arrange 
            TreeNode<string> root = new TreeNode<string>("Desserts");
            TreeNode<string> nodeB = root.AddChildNode("muffin");
            TreeNode<string> nodeC = root.AddChildNode("cupcake");
            //Act
            root.RemoveNode(nodeB);
            List<string> listNodes = new List<string>();
            foreach (TreeNode<string> j in root)
            {
                listNodes.Add(j.Value);
            }
            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(listNodes.Count() == 2);
                Assert.Contains("Desserts", listNodes);
            });
        }

        [TestCase]
        public void TestSum2Leafs()
        {
            //Arrange 
            TreeNode<int> root = new TreeNode<int>(7);
            TreeNode<int> nodeB = root.AddChildNode(8);
            TreeNode<int> nodeC = root.AddChildNode(9);
            TreeNode<int> nodeB1 = nodeB.AddChildNode(88);
            TreeNode<int> nodeB2 = nodeB.AddChildNode(888);
            //Act
            List<int> sumList = root.SumToLeafs();
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(sumList.Count() == 3);
                Assert.Contains(16, sumList);
            });

        }
    }

    [TestFixture]
    public class TreeTest
    {
        [TestCase]
        public void TestCount()
        {
            // Arrange
            TreeNode<string> root = new TreeNode<string>("Fruit");
            Tree<string> tree = new Tree<string>(root);
            TreeNode<string> child1 = root.AddChildNode("jackfruit");
            TreeNode<string> child2 = root.AddChildNode("dragonfruit");
            TreeNode<string> child3 = root.AddChildNode("papaya");
            // Act
            int numNodes = tree.Count();
            // Assert
            Assert.That(numNodes == 4);
        }

        [TestCase]
        public void TestLeafCount()
        {
            // Arrange
            TreeNode<string> root = new TreeNode<string>("Drinks");
            Tree<string> tree = new Tree<string>(root);
            TreeNode<string> child1 = root.AddChildNode("greenTea");
            TreeNode<string> child2 = root.AddChildNode("bubbletea");
            TreeNode<string> child3 = root.AddChildNode("smoothie");
            TreeNode<string> child11 = child1.AddChildNode("iced");
            // Act
            int numLeafs = tree.LeafCount();
            // Assert
            Assert.That(numLeafs == 3);
        }
    }
}

