using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            //Stack.CreateDummyStack();
            //Console.WriteLine("******** This is Dummy Stack *************");
            //Stack.DisplayStack(Stack.Top);

            //Stack.Pop();
            //Console.WriteLine("******** After 1st Pop *************");
            //Stack.DisplayStack(Stack.Top);

            //Stack.Push(100);
            //Console.WriteLine("******** After another push *************");
            //Stack.DisplayStack(Stack.Top);


            //Queue.CreateDummyQueue();
            //Console.WriteLine("******** This is Dummy Queue *************");
            //Queue.DisplayQueue(Queue.Head);

            //Queue.Deque();
            //Console.WriteLine("******** After 1st Dequeue *************");
            //Queue.DisplayQueue(Queue.Head);

            //Queue.Enque(100);
            //Console.WriteLine("******** After another Enqueue *************");
            //Queue.DisplayQueue(Queue.Head);


            //StackWithMin stackWithMin = new StackWithMin();
            //stackWithMin.push(5);
            //stackWithMin.push(6);
            //stackWithMin.push(3);
            //stackWithMin.push(7);

            //stackWithMin.pop();
            //int min = stackWithMin.Min();
            //stackWithMin.pop();
            //min = stackWithMin.Min();

            //Console.WriteLine(min.ToString());

            MultiStackFixed multiStackFixed = new MultiStackFixed(3);

            multiStackFixed.Push(1,1);
            multiStackFixed.Push(1, 2);
            multiStackFixed.Push(1, 3);
            multiStackFixed.Push(2, 4);
            multiStackFixed.Push(2, 5);
            multiStackFixed.Push(2, 6);
            multiStackFixed.Push(3, 7);
            multiStackFixed.Push(3, 8);
            multiStackFixed.Push(3, 9);
            multiStackFixed.Pop(2);
            multiStackFixed.Push(2, 6);

            Console.Read();
        }
    }

    public class Node
    {
        public int data;
        public Node next;

        public Node(int data) {
            this.data = data;
        }
    }

    public class Stack
    {
        public static Node Top;
        public static Node Bottom;

        public static void Push(int data) {
            var newNode = new Node(data);
            if (Top == null) Top = newNode;
            else {
                var tempNode = Top;
                newNode.next = Top;
                Top = newNode;
                while (tempNode.next != null) {
                    tempNode = tempNode.next;
                }
                Bottom = tempNode;
            }
        }

        public static void Pop()
        {
            Top = Top.next;
        }

        public static void DisplayStack(Node p) {
            if (p == null) return;
            else {
                while (p!= null) {
                    Console.WriteLine(p.data.ToString());
                    p = p.next;
                }
            }
        }

        public static void CreateDummyStack() {
            Stack.Push(10);
            Stack.Push(20);
            Stack.Push(30);
            Stack.Push(40);
            Stack.Push(50);
        }
    }

    public class StackWithMin : Stack<int>
    {
        Stack<int> s;

        public StackWithMin()
        {
            s = new Stack<int>();
        }

        public void push(int value)
        {
            if (value <= Min())
                s.Push(value);
            base.Push(value);
        }

        public int pop()
        {
            int value = base.Pop();
            if (value == Min())
                s.Pop();

            return value;
        }

        public int Min()
        {
            if (s.Count == 0)
                return int.MaxValue;
            else
                return s.Peek();
        }
    }

    public class Queue
    {
        public static Node Head;
        public static Node Tail;

        public static void Enque(int data)
        {
            var newNode = new Node(data);
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                var currentNode = Head;
                while (currentNode.next != null) {
                    currentNode = currentNode.next;
                }
                currentNode.next = newNode;
                Tail = currentNode.next;
            }
        }

        public static void Deque() {
            if (Head == null) return;
            else if (Head.next == null)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Head = Head.next;
            }
        }

        public static void DisplayQueue(Node p)
        {
            if (p == null) return;
            else {
                var currentNode = p;
                while (currentNode != null) {
                    Console.WriteLine(currentNode.data.ToString());
                    currentNode = currentNode.next;
                }
            }
        }

        public static void CreateDummyQueue()
        {
            Queue.Enque(10);
            Queue.Enque(20);
            Queue.Enque(30);
            Queue.Enque(40);
            Queue.Enque(50);
        }
    }

    public class MultiStackFixed
    {
        public int numberOfStacks = 3;
        public int[] sizes;
        public int[] values;
        public int capacity;

        public MultiStackFixed(int stackSize)
        {
            capacity = stackSize;
            values = new int[capacity * numberOfStacks];
            sizes = new int[numberOfStacks];
        }

        public void Push(int stackNum, int value)
        {
            if (!IsStackFull(stackNum))
            {
                values[IndexOfTop(stackNum) + 1] = value;
                sizes[stackNum - 1]++;
            }
            else
            {
                Console.WriteLine("The stack - "+stackNum.ToString()+" is Full");
            }
        }

        public int Pop(int stackNum)
        {
            if (!IsStackEmpty(stackNum))
            {
                int value = values[IndexOfTop(stackNum)];
                sizes[stackNum - 1]--;
                return value;
            }
            else
            {
                Console.WriteLine("The stack - " + stackNum.ToString() + " is Empry");
                return 0;
            }
        }

        public int IndexOfTop(int stackNum)
        {
            int offset = (stackNum - 1) * capacity;
            return offset + sizes[stackNum - 1] - 1;
        }

        public bool IsStackFull(int stackNum)
        {
            return sizes[stackNum - 1] == capacity;
        }

        public bool IsStackEmpty(int stackNum)
        {
            return sizes[stackNum - 1] == 0;
        }
    }
}
