using System;
using System.Collections.Generic;

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
        //16. Check if LL is sorted - Done
        //17. Remove Duplicates from Sorted LL - Done
        //18. Reverse a Linked List (with array and with pointers) - Done
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
            //AddAtTail(1);
            // AddAtTail(3);
            // AddAtTail(7);
            // AddAtTail(9);
            // AddAtTail(15);
            // AddAtTail(20);
            // InsertInSortedLL2Pointer(21);
            // InsertInSortedLL2Pointer(1);
            // InsertInSortedLL2Pointer(0);
            // DeleteAtHead();
            // DeleteAtLast();
            // Display();
            // DeleteAtIndex(5);
            // Display();
            // Search(7);
            //AddAtTail(-1);
             //Display();
            // GetValueAtIndex(2);
            // GetValueAtIndex(4);
            // GetValueAtIndex(7);
            //isSorted();
            //deleteDuplicateInSorted();
            // ReverseLLWithArray();
            // Display();
            // ReverseLLWithPointers();
            // Display();
            // ReverseRecursive(null,Head);
            // Display();
            #endregion
            

            //SinglyLinkedList secondLL = new SinglyLinkedList();
            // secondLL.AddAtTail(0);
            // secondLL.AddAtTail(10);
            // secondLL.AddAtTail(500);
            //Concatenate(secondLL);
            // secondLL.Display();

            // Merge2SortedLL(secondLL);
            // Display();

            //to check LOOP
            AddAtTail(1);
            AddAtTail(2);
            AddAtTail(5);
            AddAtTail(8);
            AddAtTail(9);
            AddAtTailForLoop(11,0);// to enable the cirular or loop LL
            DisplayCLL(Head);
            Console.WriteLine("=========DisplayRecursive==========");
            DisplayRecursive(Head);
            IsLoop();
            
            



        }

        #region methods
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

            // Node newNode = new Node(value);
            // temp.next = newNode;
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
        #endregion
        public void isSorted()
        {
            Node temp = Head;

            if(Head == null)
            {
                Console.WriteLine("No elements");
                return;
            }
            int x = int.MinValue;
            while(temp != null)
            {
                if(temp.value < x)
                {
                    Console.WriteLine("NOT SORTED");
                    return;
                }
                x = temp.value;
                temp = temp.next;
            }
            Console.WriteLine("SORTED");

        }
    
        public void deleteDuplicateInSorted()
        {
            if(Head == null || Head.next == null)
            {
                Console.WriteLine("Not enough elements to check duplicates");
                return;
            }

            Node prev = Head;
            Node curr = Head.next;

            while(curr != null)
            {
                if(curr.value == prev.value)
                {
                    prev.next = curr.next;
                    curr = curr.next;
                }
                else
                {
                    prev = curr;
                    curr = curr.next;
                }
            }
        }
    
        public void ReverseLLWithArray()
        {
            if(Head == null || Head.next == null)
            {
                Console.WriteLine("Not enough elements");
                return;
            }

            List<int> list = new List<int>();

            Node curr = Head;
            
            while(curr != null)
            {
                list.Add(curr.value);
                curr = curr.next;
            }

            var a = list.ToArray();
            curr = Head;

            int i = list.Count;
            while(curr != null)
            {
                curr.value = a[i-1];
                curr = curr.next;
                i--;
            }
        }

        public void ReverseLLWithPointers()
        {
            if(Head == null || Head.next == null)
            {
                Console.WriteLine("Not enough elements");
                return;
            }

            Node prevPrev = null;
            Node prev = null;
            Node curr = Head;

            while(curr != null)
            {
                prevPrev = prev;
                prev = curr;
                curr = curr.next;
                prev.next = prevPrev;
            }
            Head = prev;
        }
    
        public void ReverseRecursive(Node prev, Node curr)
        {
            if(curr != null)
            {
                ReverseRecursive(curr, curr.next);
                curr.next = prev;
            }
            else
            {
                Head = prev;
            }
        }

        public void Concatenate(SinglyLinkedList secondll)
        {
            if(Head == null && secondll.Head == null)
            {
                return;
            }

            Node firstLLCurr =  Head;

            while(firstLLCurr.next != null)
            {
                firstLLCurr = firstLLCurr.next;
            }

            firstLLCurr.next = secondll.Head;
            secondll = null;
        }
    
        public void Merge2SortedLL(SinglyLinkedList secondll)
        {
            if(Head == null && secondll.Head == null)
            {
                return;
            }

            Node mergedHead = null;
            Node last = null;

            Node firstCurr = Head;
            Node SecondCurr = secondll.Head;

            if(firstCurr.value < SecondCurr.value)
            {
                mergedHead = firstCurr;
                last = firstCurr;
                firstCurr = firstCurr.next;
                last.next = null;
            }
            else
            {
                mergedHead = SecondCurr;
                last = SecondCurr;
                SecondCurr = SecondCurr.next;
                last.next = null;
            }

            while(firstCurr != null && SecondCurr != null)
            {
                if(firstCurr.value < SecondCurr.value)
                {
                    last.next = firstCurr;
                    last = firstCurr;
                    firstCurr = firstCurr.next;
                    last.next = null;
                }
                else
                {
                    last.next = SecondCurr;
                    last = SecondCurr;
                    SecondCurr = SecondCurr.next;
                    last.next = null;
                }
            }

            if(firstCurr != null)
            {
                last.next = firstCurr;
            }
            else if (SecondCurr != null)
            {
                last.next = SecondCurr;
            }

            Head = mergedHead;
            secondll = null;           
        }
    
         public void AddAtTailForLoop(int value, int index = -1)
        {
            if(Head == null)
            {
                Head = new Node(value);
                Tail = Head;
                return;
            }
            //O(n) - without Tail
            Node temp = Head;
            Node indexToLoop = null; // to setup a loop LL
            int i = 0;// to setup a loop LL
            while(temp.next != null)
            {
                if(i == index)// to setup a loop LL
                {
                    indexToLoop = temp;// to setup a loop LL
                }
                temp = temp.next;
                i++;// to setup a loop LL
            }

            Node newNode = new Node(value);
            temp.next = newNode;

            if(indexToLoop != null)// to setup a loop LL
            {
                newNode.next = indexToLoop;// to setup a loop LL
            }

            //O(1) - With Tail Node
            // Node newNode = new Node(value);
            // Tail.next = newNode;
            // Tail = newNode;

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
    }
}