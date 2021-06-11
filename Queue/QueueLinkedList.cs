using System;

namespace DataStructuresAndAlgo.Queue
{
    public class Node
    {
        public int value;
        public Node next;

        public Node(int value)
        {
            this.value = value;
            this.next = null;
        }
    }
    public class QueueLinkedList
    {
        public Node Head;
        public Node Tail;
        public QueueLinkedList()
        {
            Head = null;
            Tail = null;
        }
        public void main()
        {
            enqueue(1);
            enqueue(2);
            enqueue(3);
            display();
            dequeue();
            display();
            enqueue(4);
            dequeue();
            display();
            enqueue(5);
            display();
            enqueue(6);
            display();
            dequeue();
            display();
        }
        public void enqueue(int value)
        {
            Node newNode = new Node(value);

            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
                return;
            }

            Tail.next = newNode;
            Tail = newNode;
        }
        public void dequeue()
        {
            if (Head == null)
            {
                Console.WriteLine("Queue is empty");
                return;
            }

            if (Head == Tail)
            {
                Console.WriteLine("Dequeued element is :" + Head.value);
                Head = null;
                Tail = null;
                return;
            }

            Console.WriteLine("Dequeued element is :" + Head.value);
            Node temp = Head;
            Head = Head.next;
            temp = null;
        }
        public void display()
        {
            Console.WriteLine("=============Display===========");
            if(Head == null)
            {
                Console.WriteLine("Queue is empty");
            }

            Node curr = Head;

            while(curr != null)
            {
                Console.Write(curr.value + "-->");
                curr = curr.next;
            }
            Console.Write("null");
            Console.WriteLine();
        }
    }
}