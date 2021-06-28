using System;

namespace DataStructuresAndAlgo.Hashing
{
    public class Chaining
    {
        public class Node
        {
            public int value;
            public Node next;
            public Node prev;

            public Node(int value)
            {
                this.value = value;
            }
        }

        public class HashTable
        {
            public Node[] HTable;
            public int Hsize;

            public void main()
            {
                Console.WriteLine("------Chaining---------");
                HashTable newHT = new HashTable(10);
                newHT.Insert(0);
                newHT.Insert(1);
                newHT.Insert(2);
                newHT.Insert(3);
                newHT.Insert(4);
                newHT.Insert(55);
                newHT.Insert(6);
                newHT.Insert(7);
                newHT.Insert(8);
                newHT.Insert(9);
                newHT.Insert(15);
                newHT.Insert(35);
                newHT.Insert(25);
                newHT.Insert(95);
                newHT.Insert(45);
                newHT.Insert(5);
                Console.WriteLine(newHT.Search(0));
                Console.WriteLine(newHT.Search(99));
                Console.WriteLine(newHT.Search(5));
                Console.WriteLine(newHT.Search(25));
                Console.WriteLine(newHT.Search(95));
                Console.WriteLine(newHT.Search(100));
            }

            public HashTable(int size)
            {
                Hsize = size;
                HTable = new Node[size];
            }

            public int HashFunction(int value)
            {
                return value % Hsize;
            }

            public bool Search(int value)
            {
                int key = HashFunction(value);
                var currNode = HTable[key];
                while (currNode != null)
                {
                    if (currNode.value == value)
                    {
                        return true;
                    }
                    currNode = currNode.next;
                }
                return false;
            }

            public void Insert(int value)
            {
                int key = HashFunction(value);

                if (HTable[key] == null)
                {
                    //Insert at head
                    Node newNode = new Node(value);
                    HTable[key] = newNode;
                    return;
                }

                //Insert in a sorted way
                var currNode = HTable[key];
                HTable[key] = InsertSort(currNode, value);
            }


            public Node InsertSort(Node head, int value)
            {
                Node newNode = new Node(value);

                if (head.value < value)
                {
                    //insert at head
                    newNode.next = head;
                    head.prev = newNode;
                    return newNode;
                }

                Node Prev = head;
                Node Curr = head.next;

                while (Curr != null && Curr.value < value)
                {
                    Prev = Curr;
                    Curr = Curr.next;
                }

                Prev.next = newNode;
                newNode.prev = Prev;
                newNode.next = Curr;
                if (Curr != null)
                {
                    //This check is needed if inserting at tail
                    Curr.prev = newNode;
                }
                return head;

            }

        }
    }
}