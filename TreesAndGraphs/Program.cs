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

            //g = g.CreateDummyGraph(g);

            //Console.WriteLine(g.IsPathExists(g, new Graph(60)));

            TreeNode root = new TreeNode(100);
            List<List<TreeNode>> lists = new List<List<TreeNode>>();

            root = root.CreateDummyTree(root);


            int[,] inputs = new int[9, 2] { { 50, 40 }, { 150, 200 }, { 50, 130 }, { 165, 200 }, { 125, 185 }, { 25, 40 }, { 35, 55 }, { 35, 60 }, { 52, 52 } };

            for (int i = 0; i < 9; i++)
            {
                var result = root.GetLeastCommonAncestor(root, new TreeNode(inputs[i,0]), new TreeNode(inputs[i, 1]));
                Console.WriteLine("Least Common ancestor of "+ inputs[i, 0].ToString() + " and "+ inputs[i, 1].ToString() + " - " + result.data.ToString());
            }
            //lists=root.CreateListLevels(root, lists, 0);
            //lists = root.CreateListsLevelIterative(root);

            //Console.WriteLine(root.GetHeight(root)!=int.MinValue);

            //Console.WriteLine(root.CheckBSTMinMax(root,-1,-1));

            //MinHeap minHeap = new MinHeap();
            //minHeap.items =new int[]{ 10,20,30,40,50};
            //minHeap.Add(45);
            //minHeap.Add(55);
            //minHeap.Add(25);

            //for (int i = 0; i < minHeap.items.Length; i++)
            //    Console.WriteLine(minHeap.items[i].ToString());

            //MaxHeap maxHeap = new MaxHeap();
            //List<Heap> heap = maxHeap.CreateDummyHeap();

            //maxHeap.Add(new Heap(60));
            //maxHeap.Add(new Heap(70));

            //for (int i = 0; i < maxHeap.maxHeap.Count; i++) {
            //    Console.WriteLine(maxHeap.maxHeap[i].priority);
            //}


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
            TreeNode g = new TreeNode(25);
            TreeNode h = new TreeNode(40);
            TreeNode i = new TreeNode(52);
            TreeNode j = new TreeNode(60);
            TreeNode k = new TreeNode(120);
            TreeNode l = new TreeNode(130);
            TreeNode m = new TreeNode(165);
            TreeNode n = new TreeNode(200);

            root.left = a;
            root.right = b;
            a.left = c;
            a.right = d;
            b.left = e;
            b.right = f;
            c.left = g;
            c.right = h;
            d.left = i;
            d.right = j;
            e.left = k;
            e.right = l;
            f.left = m;
            f.right = n;

            return root;
        }

        public TreeNode GetLeastCommonAncestor(TreeNode root,TreeNode a,TreeNode b) {

            if (IsNodeExistsInBinaryTree(root, a) && IsNodeExistsInBinaryTree(root, b)) {
                while (root != null)
                {                    
                    if(root.data > a.data && root.data > b.data)
                        root = root.left;
                    else if (root.data < a.data && root.data < b.data)
                        root = root.right;
                    else if ((root.data < a.data && root.data > b.data) || (root.data > a.data && root.data < b.data))
                        return root;
                    else if (root.data == a.data)
                        return a;
                    else if (root.data == b.data)
                        return b;
                }
            }

            return root;
        }

        public bool IsNodeExistsInBinaryTree(TreeNode root,TreeNode searchNode) {

            if (root == null || searchNode==null) return false;

            while (root != null) {
                if (root.data > searchNode.data)
                    root = root.left;
                else if (root.data < searchNode.data)
                    root = root.right;
                else if(root.data == searchNode.data)
                    return true;
            }

            return false;
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

    public class MaxHeap {
        public List<Heap> maxHeap;

        public MaxHeap() {
            maxHeap = new List<Heap>();
        }

        public List<Heap> CreateDummyHeap() {
            Heap a = new Heap(50);
            Heap b = new Heap(40);
            Heap c = new Heap(30);
            Heap d = new Heap(20);
            Heap e = new Heap(10);

            maxHeap.Add(a);
            maxHeap.Add(b);
            maxHeap.Add(c);
            maxHeap.Add(d);
            maxHeap.Add(e);
            return maxHeap;
        }

        public int GetLeftIndex(int index) {
            return (index * 2) + 1;
        }
        public int GetRightIndex(int index)
        {
            return (index * 2) + 2;
        }
        public int GetParentIndex(int index)
        {
            return (index - 2) / 2;
        }
        public bool HasParent(int index) {
            return (index > 0);
        }
        public bool HasRightChild(int index)
        {
            return ((index *2)+2)<maxHeap.Count;
        }
        public bool HasLeftChild(int index)
        {
            return ((index * 2) + 1) < maxHeap.Count;
        }

        public void Swap(int a, int b) {
            Heap temp = maxHeap[a];
            maxHeap[a] = maxHeap[b];
            maxHeap[b] = temp;
        }

        public Heap Peek() {
            return maxHeap[0];
        }

        public void Add(Heap heap) {
            if (maxHeap.Count == 0) throw new Exception("The Heap is Empty");
            maxHeap.Add(heap);
            HeapifyUp();
        }

        public Heap Poll() {
            if (maxHeap.Count == 0) throw new Exception("The Heap is Empty");
            var heap = maxHeap[0];
            maxHeap[0] = maxHeap[maxHeap.Count-1];
            HeapifyDown();
            return heap;
        }

        public void HeapifyUp() {
            int index = maxHeap.Count-1;
            while (HasParent(index)) {
                if (maxHeap[index].priority > maxHeap[GetParentIndex(index+1)].priority)
                {
                    Swap(index,GetParentIndex(index+1));
                    index = GetParentIndex(index+1);
                }
                else {
                    break;
                }
            }
        }

        public void HeapifyDown()
        {
            int index = 0;
            int largestIndex;
            while (HasLeftChild(index)) {
                largestIndex = GetLeftIndex(index);
                if (HasRightChild(index) && maxHeap[largestIndex].priority < maxHeap[GetRightIndex(index)].priority) {
                    largestIndex = GetRightIndex(index);
                }

                if (maxHeap[index].priority < maxHeap[largestIndex].priority)
                {
                    Swap(index, largestIndex);
                    index = largestIndex;
                }
                else {
                    break;
                }
            }
        }



    }

    public class Heap {
        public string value;
        public int priority;
        public Heap() {
        }
        public Heap(string value)
        {
            this.value = value;
        }
        public Heap(int priority)
        {
            this.priority = priority;
        }
        public Heap(string value,int priority)
        {
            this.value = value;
            this.priority = priority;
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
