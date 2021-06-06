using System;

namespace DataStructuresAndAlgo.LinkedList
{
        #region ToDo
        //1. Add at head - Done
        //2. Add at tail - Done
        //3. Add at index - Done
        //4. Delete at head - Done
        //5. delete at tail - Done
        //6. delete at index - Done
        //7. print node - Done
        //8. print node Recursively - Done
        //9. Get value at an Index - Done
        //10. Count number of nodes - Done
        //11. Max value in LL - Done
        //12. Sum off all values - Done
        //13. Search - Done
        //14. Insert in a Sorted LL - Done
        //15. Insert in a Sorted LL - Two pointer Apporach - Done
        //16. Check if LL is sorted
        //17. Remove Duplicates from Sorted LL
        //18. Reverse a Linked List
        //19. Reverse a Linked List - Recursive
        //20. COncatenate
        //21. Merge sorted LL into a single Sorted LL - NOT IMPLEMENTED YET 
        //22. Detect Loop - SOlved it in another file DetectCycle.cs (Leetcode)


        //To DO :
        //1. Merge Two Sorted LL to One SOrted LL (Leet COde
        //2. LeetCode - LinkedList
        //3. Abdul Badri - STudent Challenges
        //4. Reverse a Doubly Linked List
        #endregion
    public class SinglyLinkedList
    {
        public Node Head;
        public Node Tail;
        public SinglyLinkedList()
        {
            Head = null;
        }

        public void main()
        {
            #region calls
            // AddAtHead(1);
            // AddAtTail(2);
            // AddAtHead(21);
            // AddAtTail(5);
            // AddAtTail(9);
            // AddAtTail(12);
            // Display();
            // DisplayRecursive(Head);
            //Count();
            //CountRecursive(Head,0);
            //Console.WriteLine("No of elements CountRecursive2 : {0}", CountRecursive2(Head));
            //Sum();
            //Console.WriteLine("Sum of all elements SumRecursive : {0}", SumRecursive(Head));
            //Max();
            //Display();
            //Search(2);
            //Display();

            // Node n = SearchRecursive(Head,99);
            // if(n != null)
            // {
            //     Console.WriteLine("The element found {0}", n.value);
            // }
            // else
            // {
            //     Console.WriteLine("The element NOT found");
            // }
            // AddAtIndex(1,0);
            // AddAtIndex(2,1);
            // AddAtIndex(3,2);
            // AddAtIndex(4,3);
            // AddAtIndex(5,4);

            // AddAtHead(1);
            // AddAtTail(2);
            // AddAtHead(21);
            // AddAtTail(5);
            // AddAtTail(9);
            // AddAtTail(12);
            // AddAtIndex(99,6);
            // AddAtTail(100);
            // Display();
            // Count();
            #endregion
            //AddAtTail(1);
            AddAtTail(3);
            AddAtTail(7);
            AddAtTail(9);
            AddAtTail(15);
            AddAtTail(20);
            InsertInSortedLL2Pointer(21);
            InsertInSortedLL2Pointer(1);
            InsertInSortedLL2Pointer(0);
            // DeleteAtHead();
            // DeleteAtLast();
            // Display();
            // DeleteAtIndex(5);
            // Display();
            // Search(7);
             Display();
            GetValueAtIndex(2);
            GetValueAtIndex(4);
            GetValueAtIndex(7);

        }


        public void AddAtHead(int value)
        {
            if(Head == null)
            {
                Head = new Node(value);
                Tail = Head;
                return;
            }
            Node newNode = new Node(value);
            newNode.next = Head;
            Head = newNode;
        }
        public void AddAtTail(int value)
        {
            if(Head == null)
            {
                Head = new Node(value);
                Tail = Head;
                return;
            }
            //O(n) - without Tail
            // Node temp = Head;
            // while(temp.next != null)
            // {
            //     temp = temp.next;
            // }
            //temp.next = new Node(value);

            //O(1) - With Tail Node
            Node newNode = new Node(value);
            Tail.next = newNode;
            Tail = newNode;

        }
        public void AddAtIndex(int value, int index)
        {
            if(index == 0)
            {
                AddAtHead(value);
                return;
            }
            else
            {
                Node temp = Head;
                for(int i = 0; i < index-1 && temp != null; i++)
                {
                    temp = temp.next;
                }

                if (temp == null)
                {
                    Console.WriteLine("Index greater than List size");
                    return;
                }
                Node newNode = new Node(value);
                newNode.next = temp.next;
                temp.next = newNode;

                if(Count()-1 == index)
                {
                    Tail.next = newNode;
                    Tail = newNode;
                }
            }
        }
        public void DeleteAtHead()
        {
            if(Head == null)
            {
                Console.WriteLine("No elements in LL");
                return;
            }
            Node nodeToDelete = Head;
            Head = Head.next;
            nodeToDelete = null;
        }
        public void DeleteAtLast()
        {
            if(Head == null)
            {
                Console.WriteLine("No elements in LL");
                return;
            }
            if(Head.next == null)
            {
                Head = null;
                return;
            }

            Node prev = Head;
            Node curr = Head.next;
            while(curr.next != null)
            {
                prev = curr;
                curr = curr.next;
            }

            prev.next = null;
        }
        public void DeleteAtIndex(int index)
        {
            if (index == 0)
            {
                this.DeleteAtHead();
                return;
            }
            Node prev = Head;
            Node curr = Head.next;
            for (int i = 0; i < index - 1 && curr != null; i++)
            {
                prev = curr;
                curr = curr.next;
            }
            if (curr == null)
            {
                Console.WriteLine("Index greater than List size");
                return;
            }
            prev.next = curr.next;
        }
        public void Display()
        {
            if(Head == null)
            {
                Console.WriteLine("No elements to display");
                return;
            }
            Node temp = Head;
            while(temp != null)
            {
                Console.Write(temp.value + "->");
                temp = temp.next;
            }
            Console.Write("null");
            Console.WriteLine();
        }
        public void DisplayRecursive(Node node)
        {
            if(node == Head && node == null)
            {
                Console.WriteLine("No elements to display");
                return;
            }

            if(node != null)
            {
                Console.Write(node.value + "->");
                DisplayRecursive(node.next);
            }

            if(node == null)
            {
                Console.Write("null");
                Console.WriteLine();
            }
        }
        public int Count()
        {
            int c = 0;
            Node temp = Head;

            while(temp != null)
            {
                c++;
                temp = temp.next;
            }

            Console.WriteLine("No of items : {0}", c);

            return c;
        }
        public void CountRecursive(Node node, int count)
        {
            if(node != null)
            {
               count++; 
               CountRecursive(node.next,count);
            }

            if(node == null)
            {
                Console.Write("No of elements: {0}",count);
                Console.WriteLine();
            }
        }
        public int CountRecursive2(Node node)
        {
            if(node == null)
            {
                return 0;
            }
            else
            {
                return CountRecursive2(node.next) + 1;
            }
        }
        public void Sum()
        {
            if(Head == null)
            {
                Console.WriteLine("No elements to add");
            }
            Node temp = Head;
            int sum = 0;
            while(temp != null)
            {
                sum += temp.value;
                temp = temp.next;
            }

            Console.WriteLine("The Sum of all the elements: {0}", sum);
        }
        public int SumRecursive(Node node)
        {
            if(node == null)
            {
                return 0;
            }
            else
            {
                return SumRecursive(node.next) + node.value;
            }
        }
        public void Max()
        {
            if(Head == null)
            {
                Console.WriteLine("No elements");
                return;
            }

            int max = 0;
            Node temp = Head;
            while(temp != null)
            {
                if(temp.value > max)
                    max = temp.value;

                temp = temp.next;
            }

            Console.WriteLine("The max of all elements : {0}", max);
        }
        public Node Search(int value)
        {
            if(Head == null)
            {
                Console.WriteLine("No elements in LL");
                return null;
            }

            Node temp = Head;
            Node q = null;
            while(temp != null)
            {
                if(temp.value == value)
                {
                    Console.WriteLine("The element found {0}", temp.value);
                    //to bring the search node to the head element (Move to head)
                    q.next = temp.next;
                    temp.next = Head;
                    Head = temp;

                    return temp;
                }
                q = temp;
                temp = temp.next;
            }

            return null;
        }
        public Node SearchRecursive(Node node,int value)
        {
            if(Head == null)
            {
                Console.WriteLine("No elements in LL");
                return null;
            }
            if(node == null)
            {
                return null;
            }
            else if(node.value == value)
            {
                return node;
            }

            return SearchRecursive(node.next, value);

        }
        
        public void InsertInSortedLL(int value)
        {
            if(Head == null || value < Head.value)
            {
                AddAtHead(value);
                return;
            }

            Node temp = Head;
            int index = 0;
            while(temp != null)
            {
                if(temp.value > value)
                {
                    AddAtIndex(value, index);
                    return;
                }

                temp = temp.next;
                index++;
            }
            AddAtTail(value);

        }
        
        public void InsertInSortedLL2Pointer(int value)
        {
            // 2 pointer approach
            //assuming there is a Sorted LL (not checking null)
            Node temp = Head;
            Node q = null;

            if((temp != null && temp.value > value) || Head == null)
            {
                AddAtHead(value);
                return;
            }
            while(temp != null && temp.value < value)
            {
                q = temp;
                temp = temp.next;
            }

            Node newNode = new Node(value);
            newNode.next = q.next;
            q.next = newNode;
        }
        public void GetValueAtIndex(int index)
        {
            if(Head == null)
            {
                Console.WriteLine("No elements in LL");
                return;
            }
            Node temp = Head;
            for(int i = 0; i < index; i++)
            {
                if(temp == null)
                {
                    break;
                }
                temp = temp.next;
            }
            if(temp == null)
            {
                Console.WriteLine("Index out of Range");
                return;
            }
            Console.WriteLine("Value at index {0} is {1}", index, temp.value);
        }
    }
}