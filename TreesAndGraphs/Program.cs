using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesAndGraphs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1,2,3,4,5,6,7};
            MinimalBinaryTree bTree = new MinimalBinaryTree();
            TreeNode node = bTree.CreateMinimalBinaryTree(arr, 0, arr.Length - 1);


            Graph g = new Graph(10);

            g=g.CreateDummyGraph(g);

            Console.WriteLine(g.IsPathExists(g, new Graph(60)));

            Console.Read();
        }
    }


    public class TreeNode {
        public int data;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int data) {
            this.data = data;
        }
    }

    public class Graph
    {
        int data;
        State state;
        Graph[] adjacentNodes;

        public Graph(int data) {
            this.data = data;
            this.state = State.Unvisited;
        }

        public Graph CreateDummyGraph(Graph g) {
            List<Graph> adjacentNodes = new List<Graph>();

            Graph a = new Graph(20);
            Graph b = new Graph(30);
            Graph c = new Graph(40);
            Graph d = new Graph(50);
            Graph e = new Graph(60);

            adjacentNodes.Add(a);
            adjacentNodes.Add(b);
            adjacentNodes.Add(c);

            g.adjacentNodes = adjacentNodes.ToArray();

            c.adjacentNodes = new Graph[] { d };
            d.adjacentNodes = new Graph[] { e};
            e.adjacentNodes = new Graph[] { b};


            return g;
        }

        enum State { Visited,Unvisited,Visiting};

        public bool IsPathExists(Graph g, Graph b)
        {

            Queue<Graph> q = new Queue<Graph>();
            g.state = State.Unvisited;
            q.Enqueue(g);

            Graph u;
            while (q.Count > 0)
            {
                u = q.Dequeue();
                if (u != null && u.adjacentNodes != null)
                {
                    foreach (var t in u.adjacentNodes)
                    {
                        if (t.state == State.Unvisited)
                        {
                            if (t.data == b.data) return true;
                            else
                            {
                                t.state = State.Visiting;
                                q.Enqueue(t);
                            }
                        }
                    }
                }
                u.state = State.Visited;
            }

            return false;

        }
    }

    public class MinimalBinaryTree
    {

        public TreeNode CreateMinimalBinaryTree(int[] arr, int start, int end) {
            if (end < start) return null;

            int mid = (start + end) / 2;
            TreeNode node = new TreeNode(arr[mid]);

            node.left = CreateMinimalBinaryTree(arr,start,mid-1);
            node.right = CreateMinimalBinaryTree(arr, mid + 1, end);

            return node;

        }
    }

    //public class Traversals {

    //    // Depth first traversal
    //    public void Search(Node root)
    //    {
    //        if (root == null) return;

    //        root.visited = true;
    //        visit(root);

    //        foreach (Node n in root.adjacentNodes)
    //        {
    //            if (n.visited == false)
    //            {
    //                Search(n);
    //            }
    //        }
    //    }

    //    //Breadth first traversal
    //    public void Search(Node root)
    //    {
    //        Queue q = new Queue();
    //        q.Enque(root);
    //        root.visited = true;

    //        Node t;
    //        while (q.Count > 0)
    //        {
    //            t = q.Dequeue();
    //            visit(t);
    //            foreach (Node n in t.adjacentNodes)
    //            {
    //                if (n.visited == false)
    //                {
    //                    n.visited = true;
    //                    q.Enqueue(n);
    //                }
    //            }
    //        }
    //    }


    //    //Is Root exists between two nodes in a Graph

    //    enum State { Unvisited, Visited, Visiting }

    //    public bool IsRootExists(Graph g, Node start, Node end)
    //    {
    //        if (start == end) return true;

    //        foreach (Node n in g.Nodes)
    //        {
    //            n.state = State.Unvisited;
    //        }

    //        List<Node> q = new List<Node>();
    //        start.state = State.Visiting;
    //        q.Add(start);

    //        Node u;
    //        while (q.Count > 0)
    //        {
    //            u = q.removeFirst();
    //            if (u != null)
    //            {
    //                foreach (Node n in u.adjacentNodes)
    //                {
    //                    if (n.state == State.Unvisited)
    //                    {
    //                        if (n == end) return true;
    //                        else
    //                        {
    //                            n.state = State.Visiting;
    //                            q.Add(n);
    //                        }
    //                    }
    //                }
    //            }
    //            u.state = State.Visited;
    //        }

    //        return false;
    //    }
    //}
}
