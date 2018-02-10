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
            Stack.CreateDummyStack();
            Console.WriteLine("******** This is Dummy Stack *************");
            Stack.DisplayStack(Stack.Top);

            Stack.Pop();
            Console.WriteLine("******** After 1st Pop *************");
            Stack.DisplayStack(Stack.Top);

            Stack.Push(100);
            Console.WriteLine("******** After another push *************");
            Stack.DisplayStack(Stack.Top);


            Queue.CreateDummyQueue();
            Console.WriteLine("******** This is Dummy Queue *************");
            Queue.DisplayQueue(Queue.Head);

            Queue.Deque();
            Console.WriteLine("******** After 1st Dequeue *************");
            Queue.DisplayQueue(Queue.Head);

            Queue.Enque(100);
            Console.WriteLine("******** After another Enqueue *************");
            Queue.DisplayQueue(Queue.Head);

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
}
