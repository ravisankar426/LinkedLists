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
            LinkedList.Append(LinkedList.Head,10);
            LinkedList.Append(LinkedList.Head,20);
            LinkedList.Append(LinkedList.Head, 30);
            LinkedList.Append(LinkedList.Head, 30);
            LinkedList.Append(LinkedList.Head, 40);
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

    public class SumNode
    {
        public Node result = null;
        public int sum;
        public static Node resultList;
        public int carry = 0;
    }

    public class SumParent
    {
        public Node SumCaller(Node l1, Node l2)
        {
            int lenL1 = GetListLength(l1);
            int lenL2 = GetListLength(l2);
            if (lenL1 < lenL2)
            {
                l1 = PadLeft(l1, lenL2 - lenL1);
            }
            else
            {
                l2 = PadLeft(l2, lenL1 - lenL2);
            }

            SumNode sum = AddLists(l1, l2);

            if (sum.carry == 0) return sum.result;
            else
            {
                sum.result = Prepend(sum.result, sum.carry);

                return sum.result;
            }
        }

        public SumNode AddLists(Node l1, Node l2)
        {
            if (l1 == null && l2 == null)
            {
                return new SumNode();
            }

            SumNode sum = AddLists(l1.next, l2.next);

            int value = l1.data + l2.data + sum.carry;

            sum.carry = value / 10;
            sum.result = Prepend(sum.result, value % 10);

            return sum;
        }

        public int GetListLength(Node n)
        {
            if (n == null) return 0;
            if (n.next == null) return 1;
            Node current = n;
            int length = 0;
            while (current != null)
            {
                current = current.next;
                length++;
            }
            return length;
        }

        public Node PadLeft(Node n, int p)
        {
            Node newNode;
            for (int i = 0; i < p; i++)
            {
                newNode = new Node(0);
                newNode.next = n;
                n = newNode;
            }
            return n;
        }

        public Node Prepend(Node n, int data)
        {
            Node newNode = new Node(data);
            newNode.next = n;
            n = newNode;
            return n;
        }
    }

    public class LinkedList
    {
        public static Node Head;

        public static Node Append(Node node,int data)
        {

            if (node == null)
            {
               node = new Node(data);
            }
            else
            {
                var currentNode = node;
                while (currentNode.next != null) {
                    currentNode = currentNode.next;
                }
                currentNode.next = new Node(data);
            }

            return node;
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

        public static int PrintKthNodeFromEndTwoPointer(Node head, int k)
        {
            Node p1 = head;
            Node p2 = head;

            for (int i = 0; i < k; i++)
            {
                p1 = p1.next;
            }

            while (p1 != null)
            {
                p1 = p1.next;
                p2 = p2.next;
            }

            return p2.data;
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

        // To partition the nodes based on a value
        public static Node Partition(Node node, int x)
        {
            Node beforeStart = null;
            Node beforeEnd = null;
            Node afterStart = null;
            Node afterEnd = null;

            while (node != null)
            {
                Node newNode = new Node(node.data);
                if (node.data < x)
                {
                    if (beforeStart == null)
                    {
                        beforeStart = newNode;
                        beforeEnd = beforeStart;
                    }
                    else
                    {
                        beforeEnd.next = newNode;
                        beforeEnd = newNode;
                    }
                }
                else
                {
                    if (afterStart == null)
                    {
                        afterStart = newNode;
                        afterEnd = afterStart;
                    }
                    else
                    {
                        afterEnd.next = newNode;
                        afterEnd = newNode;
                    }
                }

                node = node.next;
            }

            if (beforeStart == null)
                return afterStart;

            beforeEnd.next = afterStart;
            return beforeStart;
        }

        //To partition the nodes based on a value order not mentioned
        public static Node PartitionOrderNotMentioned(Node node, int x)
        {
            Node head = null;
            Node tail = null;

            while (node != null)
            {
                Node newNode = new Node(node.data);
                if (node.data < x)
                {
                    newNode.next = head;
                    head = newNode;
                    if (tail == null)
                    {
                        tail = head;
                    }
                }
                else
                {
                    tail.next = newNode;
                    tail = newNode;
                    if (head == null)
                    {
                        head = tail;
                    }
                }
                node = node.next;
            }

            tail.next = null;

            return head;
        }

        public static SumNode SumOfLinkedListReverse(Node l1, Node l2, int carry)
        {
            if (l1 == null && l2 == null && carry == 0) return null;

            SumNode resultNode = new SumNode();
            int value = 0;

            if (l1 != null)
                value += l1.data;
            if (l2 != null)
                value += l2.data;
            value += carry;

            resultNode.result = new Node(value);
            resultNode.sum = value % 10;

            SumOfLinkedListReverse(l1 == null ? null : l1.next, l2 == null ? null : l2.next, value >= 10 ? 1 : 0);
            SumNode.resultList = LinkedList.Append(SumNode.resultList, resultNode.sum);

            resultNode.result = SumNode.resultList;
            return resultNode;
        }
    }


}
