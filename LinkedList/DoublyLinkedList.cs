using System;

namespace DataStructuresAndAlgo.LinkedList
{
    public class DoublyLinkedList
    {
        public Node Head;
        public DoublyLinkedList()
        {
            Head = null;
        }

        //TODO:
        //1. Circular Doubly Linked List - All operations
        //2. Student challenges

        public void main()
        {
            insertAtTail(1);
            insertAtTail(2);
            insertAtIndex2Pointer(3, 2);
            insertAtTail(4);
            insertAtHead(0);
            Display();
            Console.WriteLine("Length :" + Length());
            deleteAtHead();
            Display();
            Console.WriteLine("Length :" + Length());
            deleteAtTail();
            Display();
            Console.WriteLine("Length :" + Length());
            // deleteAtIndex(1);
            // Display();
            // deleteAtIndex(1);
            // Display();
            // deleteAtIndex(1);
            Display();
            reverse();
            Display();
        }


        public void insertAtHead(int value)
        {
            Node newNode = new Node(value);

            if (Head == null)
            {
                Head = newNode;
                return;
            }

            newNode.next = Head;
            Head.prev = newNode;
            Head = newNode;
        }
        public void insertAtIndex2Pointer(int value, int index)
        {
            Node newNode = new Node(value);

            if (index < 0 || index > Length())
            {
                Console.WriteLine("Index is not in range");
                return;
            }

            if (index == 0)
            {
                insertAtHead(value);
                return;
            }
            else if (index == Length())
            {
                insertAtTail(value);
                return;
            }

            Node curr = Head;
            Node prev = null;
            for (int i = 0; i < index; i++)
            {
                prev = curr;
                curr = curr.next;
            }

            newNode.next = curr;
            curr.prev = newNode;

            prev.next = newNode;
            newNode.prev = prev;

        }
        public void insertAtIndex1Pointer(int value, int index)
        {
            Node newNode = new Node(value);

            if (index < 0 || index > Length())
            {
                Console.WriteLine("Index is not in range");
                return;
            }

            if (index == 0)
            {
                insertAtHead(value);
                return;
            }
            else if (index == Length())
            {
                insertAtTail(value);
                return;
            }

            Node curr = Head;
            for (int i = 0; i < index - 1; i++)
            {
                curr = curr.next;
            }

            newNode.next = curr.next;
            newNode.prev = curr;

            if (curr.next != null)
            {
                curr.next.prev = newNode;
            }
            curr.next = newNode;
        }
        public void insertAtTail(int value)
        {
            Node newNode = new Node(value);
            if (Head == null)
            {
                Head = newNode;
                return;
            }

            Node curr = Head;

            while (curr.next != null)
            {
                curr = curr.next;
            }

            newNode.prev = curr;
            curr.next = newNode;
        }
        public void Display()
        {
            if (Head == null)
            {
                Console.WriteLine("No elements to display");
                return;
            }
            Node temp = Head;
            while (temp != null)
            {
                Console.Write(temp.value + "->");
                temp = temp.next;
            }
            Console.Write("null");
            Console.WriteLine();
        }
        public int Length()
        {
            if (Head == null)
            {
                return 0;
            }

            Node curr = Head;
            int i = 1;
            while (curr.next != null)
            {
                i++;
                curr = curr.next;
            }

            return i;
        }
    
        public void deleteAtHead()
        {
            if(Head == null)
            {
                Console.WriteLine("No elements");
                return;
            }

            Node curr = Head;

            if(curr.next != null)
            {
                curr = curr.next;
                curr.prev = null;
                Head = curr;
                return;
            }

            Head = null;
        }

        public void deleteAtTail()
        {
             if(Head == null)
            {
                Console.WriteLine("No elements");
                return;
            }

            Node curr = Head;
            Node prev = null;

            while(curr.next != null)
            {
                prev = curr;
                curr = curr.next;
            }

            prev.next = null;
            curr = null;


        }

        public void deleteAtIndex(int index)
        {
            if (index < 0 || index >= Length())
            {
                Console.WriteLine("Index is not in range");
                return;
            }

            if (index == 0)
            {
                deleteAtHead();
                return;
            }
            else if (index + 1 == Length())
            {
                deleteAtTail();
                return;
            }

            Node curr = Head;
            Node prev = null;
            for(int i = 0; i < index; i++)
            {
                prev = curr;
                curr = curr.next;
            }

            prev.next = curr.next;
            curr.next.prev = prev;
        }
    
        public void reverse()
        {
            Node curr = Head;
            Node temp = null;
            while(curr != null)
            {
                temp = curr.next;
                curr.next = curr.prev;
                curr.prev = temp;

                curr = curr.prev;

                if(curr != null && curr.next == null)
                {
                    Head = curr;
                }
            }
        }
    }
}