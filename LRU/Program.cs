using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRU
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] pages = new int[3][] {
                new int[] { 1,1},
                new int[] { 2,4},
                new int[] { 3,5}
            };
           
            Dictionary<int, Node> dict = new Dictionary<int, Node>();
            Dictionary<string, int> hitsOrFailure = new Dictionary<string, int>();
            LRUCache cache = new LRUCache(3);

            for (int i = 0; i < pages.Length; i++)
            {
                cache.set(pages[i][0],pages[i][1]);
            }

            int value=cache.get(1);
            cache.set(4,9);
        }
    }

    public class Node
    {
        public int data;
        public int key;
        public Node next;
        public Node prev;

        public Node() { }
        public Node(int key,int data)
        {
            this.data = data;
            this.key = key;
        }
    }


    public class LRUCache
    {
        int capacity = 0, size;

        Node dummyHead, dummyTail;
        Dictionary<int, Node> dict = new Dictionary<int, Node>();

        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            this.dummyHead = new Node(0,0);
            this.dummyTail = new Node(0,0);
            dummyHead.next = dummyTail;
            dummyTail.prev = dummyHead;
        }

        public int get(int key)
        {
            if (!dict.ContainsKey(key))
                return -1;

            Node node = dict[key];
            remove(node);
            AddToLast(node);

            return node.data;
        }

        public void set(int key, int value)
        {
            if (dict.ContainsKey(key))
            {
                Node node = dict[key];
                node.data = value;
                remove(node);
                AddToLast(node);
            }
            else
            {
                if (size == capacity)
                {
                    dict.Remove(dummyHead.next.key);
                    remove(dummyHead.next);
                    --size;
                }

                Node node = new Node(key,value);
                dict.Add(key, node);
                AddToLast(node);
                ++size;
            }
        }


        public void remove(Node node)
        {
            node.prev.next = node.next;
            node.next.prev = node.prev;
        }

        public void AddToLast(Node node)
        {
            node.next = dummyTail;
            node.prev = dummyTail.prev;
            dummyTail.prev.next = node;
            dummyTail.prev = node;
        }

    }
}
