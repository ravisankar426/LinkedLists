using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedListOperations.CreateLinkedList();
            //LinkedList.Head=LinkedListOperations.PartitionOrderNotMentioned(LinkedList.Head,5);
            //Console.WriteLine(LinkedListOperations.PrintKthNodeFromEnd(LinkedList.Head,3));
            //SumNode.resultList=LinkedListOperations.SumOfLinkedListReverse(LinkedList.l1,LinkedList.l2,0).result;
            //SumParent parent = new SumParent();
            //parent.SumCaller(LinkedList.l1, LinkedList.l2);

            Intersection intersection = new Intersection();
            //Node intersect=intersection.GetIntersection(LinkedList.l1,LinkedList.l2);
            Node collide = intersection.Collide(LinkedList.Head);

            Console.Read();

        }
    }

    public class Node
    {
        public int data;
        public Node next;
        public Node(int data)
        {
            this.data = data;
        }
        public Node(){
        }
    }

    public class SumNode
    {
        public Node result=null;
        public int sum=0;
        public static Node resultList;
        public int carry = 0;
    }

    public static class LinkedListOperations
    {
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

        public static int PrintKthNodeFromEnd(Node head, int k)
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

        public static void CreateLinkedList()
        {
            LinkedList.Head=LinkedList.Append(LinkedList.Head,3);
            LinkedList.Head = LinkedList.Append(LinkedList.Head, 5);
            LinkedList.Head = LinkedList.Append(LinkedList.Head, 8);
            LinkedList.Head = LinkedList.Append(LinkedList.Head, 5);
            LinkedList.Head = LinkedList.Append(LinkedList.Head, 10);
            LinkedList.Head = LinkedList.Append(LinkedList.Head, 2);
            LinkedList.Head = LinkedList.Append(LinkedList.Head, 1);

            Node tail = LinkedList.Head;
            Node collide = null;
            int counter = 0;

            while (tail.next!=null) {
                tail = tail.next;
                counter++;
                if (counter == 2)
                    collide = tail;
            }

            tail.next = collide;

            LinkedList.l1=LinkedList.Append(LinkedList.l1,1);
            LinkedList.l1=LinkedList.Append(LinkedList.l1, 2);
            LinkedList.l1=LinkedList.Append(LinkedList.l1, 3);
            LinkedList.l1 = LinkedList.Append(LinkedList.l1, 4);
            LinkedList.l1 = LinkedList.Append(LinkedList.l1, 5);
            LinkedList.l1 = LinkedList.Append(LinkedList.l1, 6);

            LinkedList.l2= LinkedList.Append(LinkedList.l2, 7);
            LinkedList.l2 = LinkedList.Append(LinkedList.l2, 8);
            LinkedList.l2 = LinkedList.Append(LinkedList.l2, 5);
            LinkedList.l2 = LinkedList.Append(LinkedList.l2, 6);
        }

        public static SumNode SumOfLinkedListReverse(Node l1,Node l2,int carry) {
            if (l1 == null && l2 == null && carry == 0) return null;
           
            SumNode resultNode = new SumNode();
            int value = 0;

            if (l1 != null)
                value += l1.data;
            if (l2 != null)
                value += l2.data;
            value += carry;           

            resultNode.result = new Node(value);
            resultNode.sum = value%10;            
           
            SumOfLinkedListReverse(l1 == null ? null : l1.next, l2 == null ? null : l2.next, value >= 10 ? 1 : 0);
            SumNode.resultList = LinkedList.Append(SumNode.resultList, resultNode.sum);            

            resultNode.result = SumNode.resultList;
            return resultNode;
        }

    }

    public class LinkedList
    {
        public static Node Head;
        public static Node l1;
        public static Node l2;

        public static Node Append(Node head,int data)
        {
            if (head == null)
            {
                head = new Node(data);
            }
            else
            {
                var currentNode = head;
                while (currentNode.next != null)
                {
                    currentNode = currentNode.next;
                }
                currentNode.next = new Node(data);
            }

            return head;
        }
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

    public class Result
    {
        public Node tail;
        public int length;
        public Result(Node tail, int length)
        {
            this.tail = tail;
            this.length = length;
        }
    }

    public class Intersection
    {
        public Node GetIntersection(Node l1, Node l2)
        {
            Result result1 = GetTailAndLength(l1);
            Result result2 = GetTailAndLength(l2);

            if (result1.tail.data != result2.tail.data) return null;

            Node shortest = result1.length > result2.length ? l2 : l1;
            Node longest = result1.length < result2.length ? l2 : l1;

           

            longest = GetNthNode(longest, Math.Abs(result1.length - result2.length));

            while (longest.data != shortest.data)
            {
                longest = longest.next;
                shortest = shortest.next;
        
            }

            return longest;
        }

        public Result GetTailAndLength(Node l1)
        {
            if (l1 == null) return new Result(null, 0);
            if (l1.next == null) return new Result(l1, 1);
            int length = 1;

            while (l1.next != null)
            {
                l1 = l1.next;
                length++;
            }

            return new Result(l1, length);
        }

        public Node GetNthNode(Node head, int n)
        {
            if (head == null) return null;
            int k = 1;
            while (k <= n)
            {
                head = head.next;
                k++;
            }

            return head;
        }

        public Node Collide(Node head)
        {
            Node slow = head;
            Node fast = head;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (fast == slow)
                    break;
            }

            if (fast == null || fast.next == null)
                return null;

            slow = head;
            while (slow != fast)
            {
                slow = slow.next;
                fast = fast.next;
            }

            return fast;
        }
    }
}
