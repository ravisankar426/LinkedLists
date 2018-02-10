using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Node.root=BinaryTree.CreateBinaryTree(Node.root);

            Console.WriteLine("*********** Sample Binary Tree In Order *****************");
            BinaryTree.DisplayInOrderBinaryTree(Node.root);

            Console.WriteLine("*********** Sample Binary Tree Pre Order *****************");
            BinaryTree.DisplayPreOrderBinaryTree(Node.root);

            Console.WriteLine("*********** Sample Binary Tree Post Order *****************");
            BinaryTree.DisplayPostOrderBinaryTree(Node.root);

            Console.Read();
        }
    }

    public class BinaryTree
    {
        public static Node CreateBinaryTree(Node root)
        {
            root = new Node(100);
            root.left = new Node(50);
            root.right = new Node(75);
            root.left.left = new Node(25);
            root.left.right = new Node(65);
            root.right.left = new Node(70);
            root.right.right = new Node(80);
            return root;
        }

        public static void DisplayInOrderBinaryTree(Node root) {
            if (root == null) return;
            else {
                DisplayInOrderBinaryTree(root.left);
                Console.WriteLine(root.data.ToString());
                DisplayInOrderBinaryTree(root.right);
            }
        }

        public static void DisplayPreOrderBinaryTree(Node root)
        {
            if (root == null) return;
            else
            {
                Console.WriteLine(root.data.ToString());
                DisplayPreOrderBinaryTree(root.left);
                DisplayPreOrderBinaryTree(root.right);
            }
        }

        public static void DisplayPostOrderBinaryTree(Node root)
        {
            if (root == null) return;
            else
            {
                DisplayPostOrderBinaryTree(root.left);
                DisplayPostOrderBinaryTree(root.right);
                Console.WriteLine(root.data.ToString());
            }
        }
    }

    public class Node
    {
        public static Node root;
        public Node right, left;
        public int data;

        public Node(int data) {
            this.data = data;
        }

        
    }
}
