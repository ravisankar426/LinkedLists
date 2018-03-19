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
            //int[] arr = new int[] { 1,2,3,4,5,6,7};
            //MinimalBinaryTree bTree = new MinimalBinaryTree();
            //TreeNode node = bTree.CreateMinimalBinaryTree(arr, 0, arr.Length - 1);


            //Graph g = new Graph(10);

            //g=g.CreateDummyGraph(g);

            //Console.WriteLine(g.IsPathExists(g, new Graph(60)));

            //TreeNode root = new TreeNode(100);
            //List<List<TreeNode>> lists = new List<List<TreeNode>>();

            //root = root.CreateDummyTree(root);
            //lists=root.CreateListLevels(root, lists, 0);
            //lists = root.CreateListsLevelIterative(root);

            //Console.WriteLine(root.GetHeight(root)!=int.MinValue);

            //Console.WriteLine(root.CheckBSTMinMax(root,-1,-1));

            MinHeap minHeap = new MinHeap();
            minHeap.items =new int[]{ 10,20,30,40,50};
            minHeap.Add(45);
            minHeap.Add(55);
            minHeap.Add(25);

            for (int i = 0; i < minHeap.items.Length; i++)
                Console.WriteLine(minHeap.items[i].ToString());

            Console.Read();
        }
    }


    public class TreeNode {
        public int data;
        public TreeNode left;
        public TreeNode right;
        int last_print = -1;


        public bool CheckBST(TreeNode root)
        {
            if (root == null) return true;

            if (!CheckBST(root.left)) return false;

            if (last_print != -1 && root.data <= last_print)
                return false;

            last_print = root.data;

            if (!CheckBST(root.right)) return false;

            return true;

        }

        public bool CheckBSTMinMax(TreeNode root,int min,int max) {

            if (root == null) return true;

            if ((min != -1 && root.data <= min) || (max!=-1 && root.data>max))
                return false;

            if (!CheckBSTMinMax(root.left, min, root.data) || !CheckBSTMinMax(root.right, root.data, max))
                return false;
            return true;

        }

        public TreeNode(int data) {
            this.data = data;
        }

        public List<List<TreeNode>> CreateListLevels(TreeNode root,List<List<TreeNode>> lists,int level) {

            if (root == null) return null;

            List<TreeNode> list = null;

            if (lists.Count == level)
            {
                list = new List<TreeNode>();
                lists.Add(list);
            }
            else {
                list = lists.ElementAt(level);
            }

            list.Add(root);

            root.CreateListLevels(root.left,lists,level+1);
            root.CreateListLevels(root.right, lists, level + 1);



            return lists;
        }

        public List<List<TreeNode>> CreateListsLevelIterative(TreeNode root)
        {
            if (root == null) return new List<List<TreeNode>>();

            List<List<TreeNode>> result = new List<List<TreeNode>>();
            List<TreeNode> current = new List<TreeNode>();
            current.Add(root);

            while (current.Count > 0)
            {
                result.Add(current);
                List<TreeNode> parents = current;
                current = new List<TreeNode>();
                foreach (var parent in parents)
                {
                    if (parent.left != null)
                    {
                        current.Add(parent.left);
                    }
                    if (parent.right != null)
                    {
                        current.Add(parent.right);
                    }
                }
            }

            return result;
        }

        public int GetHeight(TreeNode root)
        {
            if (root == null) return -1;

            int leftHeight = GetHeight(root.left);
            if (leftHeight == int.MinValue) return int.MinValue;

            int rightHeight = GetHeight(root.right);
            if (rightHeight == int.MinValue) return int.MinValue;


            int height = leftHeight - rightHeight;

            if (Math.Abs(height) > 1)
                return int.MinValue;
            else
                return Math.Max(leftHeight, rightHeight) + 1;
        }

        public TreeNode CreateDummyTree(TreeNode root) {
            TreeNode a = new TreeNode(50);
            TreeNode b = new TreeNode(150);
            TreeNode c = new TreeNode(35);
            TreeNode d = new TreeNode(55);
            TreeNode e = new TreeNode(125);
            TreeNode f = new TreeNode(185);

            root.left = a;
            root.right = b;
            a.left = c;
            a.right = d;
            b.left = e;
            b.right = f;

            return root;
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

    public class MinHeap
    {
        public int capacity;
        public int size;

        public int[] items;

        public MinHeap()
        {
            items = new int[5];
            capacity = 5;
            size = 5;
        }

        public int GetParentIndex(int index)
        {
            return (index - 2) / 2;
        }
        public int GetLeftIndex(int index)
        {
            return (index * 2) + 1;
        }
        public int GetRightIndex(int index)
        {
            return (index * 2) + 2;
        }
        public bool HasLeftIndex(int index)
        {
            return (index * 2) + 1 < size;
        }
        public bool HasRightIndex(int index)
        {
            return (index * 2) + 2 < size;
        }
        public bool HasParent(int index)
        {
            return index > 0;
        }

        public void EnsureCapacity()
        {
            if (size == capacity)
            {
                Array.Resize<int>(ref items, capacity * 2);
                capacity = capacity * 2;
            }
        }

        public int Peek()
        {
            if (items.Length == 0) throw new Exception("The queue is Empty");
            return items[0];
        }

        public int Poll()
        {
            if (items.Length == 0) throw new Exception("The queue is Empty");
            int item = items[0];
            items[0] = items[size - 1];
            size--;
            HeapifyDown();
            return item;
        }

        public void Add(int data)
        {
            if (items.Length == 0) throw new Exception("The queue is not initialized");
            if (size == capacity)
            {
                EnsureCapacity();
            }
            size++;
            items[size - 1] = data;
            HeapifyUp();
        }

        public void HeapifyUp()
        {
            int index = size - 1;
            while (HasParent(index))
            {
                if (items[index] < items[GetParentIndex(index)])
                {
                    Swap(index, GetParentIndex(index));
                    index = GetParentIndex(index);
                }
                else {
                    break;
                }
            }
        }

        public void HeapifyDown()
        {
            int index = 0;
            while (HasLeftIndex(index))
            {
                int smallerChildIndex = GetLeftIndex(index);
                if (HasRightIndex(index) && items[smallerChildIndex] > items[GetRightIndex(index)])
                {
                    smallerChildIndex = GetRightIndex(index);
                }

                if (items[index] > items[smallerChildIndex])
                {
                    Swap(index, smallerChildIndex);
                    index = smallerChildIndex;
                }
                else
                {
                    break;
                }
            }
        }

        public void Swap(int a, int b)
        {
            int temp = items[a];
            items[a] = items[b];
            items[b] = temp;
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
