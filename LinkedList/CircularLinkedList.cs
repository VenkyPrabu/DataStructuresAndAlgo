using System;

namespace DataStructuresAndAlgo.LinkedList
{
    public class CircularLinkedList
    {
        public Node Head;
        int flag = 0;
        public CircularLinkedList()
        {
            Head = null;
        }

        public void main()
        {
            AddAtTail(1);
            AddAtTail(2);
            AddAtTail(5);
            AddAtTail(8);
            AddAtTail(9);

            AddAtHead(0);
            AddAtIndex(100,2);

            deleteAtHead();
            deleteAtTail();
            deleteAtIndex(0);
            deleteAtIndex(2);
            DisplayCLL(Head);


            // Console.WriteLine("=========DisplayRecursive==========");
            // DisplayRecursive(Head);
            //IsLoop();
        }

       

        public void DisplayCLL(Node head)
        {
            if(head == null)
            {
                Console.WriteLine("No elements to display");
                return;
            }
            Node temp = head;
            do
            {
                Console.Write(temp.value + "-->");
                temp = temp.next;
            }
            while(temp != head);
            Console.Write("Head [" + Head.value + "]");
            Console.WriteLine();
        }

        public void DisplayRecursive(Node node)
        {
            if(node != Head || flag == 0)
            {
                flag = 1;
                Console.Write(node.value + "-->");
                DisplayRecursive(node.next);
            }
            if(flag == 1)
                Console.Write("Head [" + Head.value + "]");
            
            flag = 0;
        }

        public void IsLoop()
        {
            Node fast = Head;
            Node slow = Head;
            Console.WriteLine("");
            while(fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;

                if(fast == slow)
                {
                    Console.WriteLine("Loop");
                    return;
                }
            }

            Console.WriteLine("Not a Loop");
                    
        }

        public void AddAtHead(int value)
        {
            Node newNode = new Node(value);
            if(Head == null)
            {
                Head = newNode;
                Head.next = Head;
                return;
            }
                Node curr = Head;
                while(curr.next != Head)
                {
                    curr = curr.next;
                }

                curr.next = newNode;
                newNode.next = Head;
                Head = newNode;
        }

        public void AddAtTail(int value)
        {
            Node newNode = new Node(value);
            if(Head == null)
            {
                Head = newNode;
                Head.next = Head;
                return;
            }
                Node curr = Head;
                while(curr.next != Head)
                {
                    curr = curr.next;
                }

                curr.next = newNode;
                newNode.next = Head;
        }



        public void AddAtIndex(int value, int index)
        {
            if(index < 0 || index > Length())
                return;

            if(index == 0)
            {
                AddAtHead(value);
            }
            else
            {
                Node curr = Head;
                for(int i = 0; i < index -1;  i++)
                {
                    curr = curr.next;
                }

                Node newNode = new Node(value);
                newNode.next = curr.next;
                curr.next = newNode;
            }
        }

        public int Length()
        {
            int i = 0;
            Node curr = Head;

            if(curr != null)
            {
                do
                {
                    i++;
                    curr = curr.next;
                }while(curr != Head);
            }

            return i;
        }

        public void deleteAtIndex(int index)
        {
           
            if (Head == null){                
               Console.WriteLine("No elements in list");
               return;
            }

            if(index < 0 || index > Length())
            {
                Console.WriteLine("Cannot delete at given index");
            }

            if(index == 0)
            {
                deleteAtHead();
                return;
            }

            Node curr = Head;
            for(int i = 0; i < index - 1; i++)
            {
                curr = curr.next;
            }
            //now aft the for loop the Curr node will point to the previous node to which we have to delete

            Node nodeToDelete = curr.next;

            curr.next = nodeToDelete.next;

            nodeToDelete = null;
        }

        public void deleteAtHead()
        {
            if (Head == null){                
               Console.WriteLine("No elements in list");
               return;
            }

            Node curr = Head;
            while(curr.next != Head)
            {
                curr = curr.next;
            }

            curr.next = Head.next;
            Head = curr.next;
        }

        public void deleteAtTail()
        {
            if (Head == null){                
               Console.WriteLine("No elements in list");
               return;
            }
            
            if(Head.next == Head)
            {
                Head = null;
                return;
            }

            Node prev = Head;
            Node curr = Head.next;

            while(curr.next != Head)
            {
                prev = curr;
                curr = curr.next;
            }

            prev.next = curr.next;
            curr.next = null;
            curr = null;

        }

    }
}