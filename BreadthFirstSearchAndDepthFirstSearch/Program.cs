using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadthFirstSearchAndDepthFirstSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = PopulateTree();
            DepthFirstSearchByRecursion(root);
            DepthFirstSearch(root);
            BreadthFirstSearch(root);
        }

        static TreeNode PopulateTree()
        {
            TreeNode root = new TreeNode { NodeName = "1" };
            Action<TreeNode> act = (node) =>
            {
                for (int i = 0; i < 3; i++)
                    node.Children.Add(new TreeNode { NodeName = node.NodeName + "-" + (i + 1).ToString() });
            };

            act(root);
            foreach (TreeNode node in root.Children)
                act(node);

            return root;
        }

        static void DepthFirstSearchByRecursion(TreeNode node)
        {
            //do self
            Console.WriteLine(node.NodeName);

            foreach (TreeNode child in node.Children)
                DepthFirstSearchByRecursion(child);
        }

        static void DepthFirstSearch(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            
            while (stack.Count > 0)
            {
                TreeNode node = stack.Pop();

                //do self
                Console.WriteLine(node.NodeName);

                for (int i = node.Children.Count - 1; i >= 0; i--)
                    stack.Push(node.Children[i]);
            }
        }

        static void BreadthFirstSearch(TreeNode root)
        {
            Queue<TreeNode> stack = new Queue<TreeNode>();
            stack.Enqueue(root);

            while (stack.Count > 0)
            {
                TreeNode node = stack.Dequeue();

                //do self
                Console.WriteLine(node.NodeName);

                for (int i = 0; i < node.Children.Count; i++)
                    stack.Enqueue(node.Children[i]);
            }
        }
    }

    class TreeNode
    {
        public string NodeName;
        public List<TreeNode> Children = new List<TreeNode>();
    }
}
