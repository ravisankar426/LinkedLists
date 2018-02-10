using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateLinkedList();
            Console.WriteLine("******* Linked List **********");
            LinkedList.DisplayLinkedListItems(LinkedList.Head);

            //LinkedList.ReverseLinkedListIterative();
            //Console.WriteLine("******* Linked List After Iterative Reversal **********");
            //LinkedList.DisplayLinkedListItems(LinkedList.Head);

            //LinkedList.Head = LinkedList.ReverseLinkedListRecursive(LinkedList.Head);
            //Console.WriteLine("******* Linked List After Recursive Reversal **********");
            //LinkedList.DisplayLinkedListItems(LinkedList.Head);

            //LinkedList.Head = LinkedList.ReverseLinkedListSwapping(LinkedList.Head);
            //Console.WriteLine("******* Linked List After Swapping Reversal **********");
            //LinkedList.DisplayLinkedListItems(LinkedList.Head);

            //LinkedList.PrintKthFromLastElement(LinkedList.Head, 2);

            //Console.WriteLine(LinkedList.IsLinkedListPalindrome(LinkedList.Head));

            LinkedList.DeleteDuplicates(LinkedList.Head);
            Console.WriteLine("******* Linked List After Deleting Duplicates **********");
            LinkedList.DisplayLinkedListItems(LinkedList.Head);

            Console.Read();
        }

        public static void CreateLinkedList()
        {
            LinkedList.Append(10);
            LinkedList.Append(20);
            LinkedList.Append(30);
            LinkedList.Append(30);
            LinkedList.Append(40);
        }

    }



    public class Node
    {
        public Node next;
        public int data;
        public Node(int data)
        {
            this.data = data;
        }
    }

    public class LinkedList
    {
        public static Node Head;

        public static void Append(int data)
        {
            if (Head == null)
            {
               Head = new Node(data);
            }
            else
            {
                var currentNode = LinkedList.Head;
                while (currentNode.next != null) {
                    currentNode = currentNode.next;
                }
                currentNode.next = new Node(data);
            }            
        }

        public static void Prepend(int data)
        {
            if (Head == null)
            {
                Head = new Node(data);
            }
            else
            {
                var newNode = new Node(data);
                newNode.next = Head;
                Head = newNode;
            }
        }

        public static void DisplayLinkedListItems(Node head)
        {
            if (head == null)
                Console.WriteLine("There are no items in the List");
            else
            {
                var currentNode = head;
                while (currentNode != null)
                {
                    Console.WriteLine(currentNode.data.ToString());
                    currentNode = currentNode.next;
                }
            }
        }

        public static void ReverseLinkedListIterative()
        {
            Node prev = null;
            Node next=null;
            Node current=Head;

            if (Head.next != null)
            {
                while(current!=null)
                {
                    next = current.next;
                    current.next = prev;
                    prev = current;
                    current = next;
                }
                Head = prev;
            }
        }

        public static Node ReverseLinkedListRecursive(Node p)
        {
            if (p == null) return null;
            else if (p.next == null) return p;
            else {
                var next = p.next;
                p.next = null;
                var root=ReverseLinkedListRecursive(next);
                next.next = p;
                return root;
            }
        }

        public static Node ReverseLinkedListSwapping(Node p)
        {
            Node root=p;
            Node firstNode=p;
            Node secondNode=p;
            int temp=0;
            int listLength = GetLinkedListLength(p);
            int j = listLength-1;
            int i = 0;
            if (p == null) return null;
            if (p.next == null) return p;
            else {
                    int k;
                    while (i<j)
                    {
                        k = 0;
                        while (k < j) {
                            secondNode = secondNode.next;
                            k++;
                        }
                        temp = firstNode.data;
                        firstNode.data = secondNode.data;
                        secondNode.data = temp;
                        firstNode = firstNode.next;
                        secondNode = root;
                        i++;
                        j--;
                    }

                    return secondNode;
               }
        }

        public static int GetLinkedListLength(Node head)
        {
            int length = 1;

            if (head == null) return 0;
            else if (head.next == null) return 1;
            else
            {
                while (head.next != null)
                {
                    head = head.next;
                    length++;
                }
            }

            return length;
        }

        public static int PrintKthFromLastElement(Node head, int k)
        {
            int index = 0;

            if (head == null) return 0;

            index = PrintKthFromLastElement(head.next, k) + 1;

            if (index == k)
                Console.WriteLine(k.ToString()+"th element from the last - "+head.data.ToString());

            return index;
        }

        public static bool IsLinkedListPalindrome(Node head)
        {
            Node slow = head;
            Node fast = head;
            Stack<int> firstHalf = new Stack<int>();

            while (fast!=null && fast.next!=null) {
                firstHalf.Push(slow.data);
                slow = slow.next;
                fast = fast.next.next;
            }

            if (fast != null) {
                slow = slow.next;
            }

            while (slow != null) {
                if (slow.data != firstHalf.Pop()) return false;
                slow = slow.next;
            }

            return true;
        }

        public static void DeleteDuplicates(Node head)
        {
            var hashSet = new HashSet<int>();
            Node previous = null;
            Node newList = null;

            while (head != null) {
                if (hashSet.Contains(head.data))
                {
                    previous.next = head.next;
                }
                else {
                    hashSet.Add(head.data);
                    previous = head;
                }

                head = head.next;
            }

            previous = null;
            for (int i = hashSet.Count-1; i >=0; i--) {
                newList = new Node(hashSet.ElementAt(i));
                newList.next = previous;
                previous = newList;
            }

            LinkedList.Head = newList;
        }
    }
}
