using System;

namespace DataStructuresAndAlgo.LinkedList
{
        #region ToDo
        //1. Add at head - Done
        //2. Add at tail - Done
        //3. Add at index - Done
        //4. Delete at head
        //5. delete at tail
        //6. delete at index
        //7. print node - Done
        //8. print node Recursively - Done
        //9. Get value at an Index
        //10. Count number of nodes - Done
        //11. Max value in LL
        //12. Sum off all values - Done
        //13. Search
        //14. Insert in a Sorted LL
        //15. Insert in a Sorted LL - Two pointer Apporach
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
            AddAtHead(1);
            AddAtTail(2);
            AddAtHead(21);
            AddAtTail(5);
            AddAtTail(9);
            AddAtTail(12);
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
            #endregion
            // AddAtIndex(1,0);
            // AddAtIndex(2,1);
            // AddAtIndex(3,2);
            // AddAtIndex(4,3);
            // AddAtIndex(5,4);
             AddAtIndex(99,6);
             AddAtTail(100);
            Display();
            Count();

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

    }
}