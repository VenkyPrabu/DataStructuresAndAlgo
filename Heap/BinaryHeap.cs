using System;

namespace DataStructuresAndAlgo.Heap
{
    public class BinaryHeap
    {
        //1. Insert in Heap
        //2. Delete in Heap
        //3. Create Heap
        //4. Heapify Top/Down


        //To DO - 
        //1. Heap Sort
        //2. Priority Queue
        public int Heapsize;
        public int[] Heaparray;

        public BinaryHeap(int size)
        {
            Heaparray = new int[size + 1];
            Heapsize = 0;
        }

        public void main()
        {
            Insert(10);
            Insert(20);
            Insert(30);
            Insert(25);
            Insert(5);
            Insert(40);
            Insert(35);
            PrintHeap();
            Delete();
            PrintHeap();

            //PrintAll();
            Delete();
            PrintHeap();
            Delete();
            PrintHeap();
            Delete();
            PrintHeap();
            Delete();
            PrintHeap();
            Delete();
            PrintHeap();
            Delete();
            PrintHeap();
            PrintAll();
        }


        public void Insert(int value)
        {
            if (Heapsize + 1 == Heaparray.Length)
            {
                Console.WriteLine("Heap is full");
                return;
            }

            //Iterative
            // int i = Heapsize + 1, temp = 0;
            // temp = value;
            // Heapsize++;

            // while (i > 1 && temp > Heaparray[(i / 2)])
            // {
            //     Heaparray[i] = Heaparray[i / 2];
            //     i = i / 2;
            // }
            // Heaparray[i] = temp;

            //Recursive
            Heapsize++;
            //Console.WriteLine(Heapsize);
            Heaparray[Heapsize] = value;
            HeapifyBottomToTop(Heapsize);

        }

        public void HeapifyBottomToTop(int index)
        {
            if (index <= 1)
            {
                return;
            }

            int parentIndex = index / 2;
            if (Heaparray[parentIndex] < Heaparray[index])
            {
                int temp = Heaparray[parentIndex];
                Heaparray[parentIndex] = Heaparray[index];
                Heaparray[index] = temp;
            }
            HeapifyBottomToTop(parentIndex);
        }

        public void PrintHeap()
        {
            Console.WriteLine("========PRINT==========");
            for (int i = 1; i <= Heapsize; i++)
            {
                Console.Write(Heaparray[i] + " ");
            }

            Console.WriteLine();
        }

        public void Delete()
        {
            if (Heapsize < 1)
            {
                Console.WriteLine("No element in Heap");
                return;
            }


            int deleted = Heaparray[1];
            Console.WriteLine(Heapsize + "|" + Heaparray[Heapsize] + " deleted |" + deleted);
            Heaparray[1] = Heaparray[Heapsize];
            ////to maintain all the elements outside of Heap size
            Heaparray[Heapsize] = deleted;
            Heapsize--;

            int i = 1, j = i * 2;
            while (j < Heapsize)
            {
                if (Heaparray[j + 1] > Heaparray[j])
                    j = j + 1;

                if (Heaparray[i] < Heaparray[j])
                {
                    int temp = Heaparray[i];
                    Heaparray[i] = Heaparray[j];
                    Heaparray[j] = temp;
                    i = j;
                    j = j * 2;
                }
                else
                {
                    break;
                }
            }
        }

        public void DeleteR()
        {
            if (Heapsize == 0)
            {
                Console.WriteLine("Heap is Empty");
                return;
            }

            int deleteValue = Heaparray[1];
            Heaparray[1] = Heaparray[Heapsize];
            Heaparray[Heapsize] = deleteValue;
            Heapsize--;
            HeapifyTopToBottom(1);
        }

        public void HeapifyTopToBottom(int index)
        {
            int leftChildIndex = 2 * index;
            int rightChildIndex = leftChildIndex + 1;
            int bigChild = 0;

            if (Heapsize < leftChildIndex)
            {
                //reached end of heap
                return;
            }

            if (Heapsize == leftChildIndex)
            {
                //means only lefy child is available
                if (Heaparray[index] < Heaparray[leftChildIndex])
                {
                    int temp = Heaparray[index];
                    Heaparray[index] = Heaparray[leftChildIndex];
                    Heaparray[leftChildIndex] = temp;

                }
                return;
            }
            else
            {
                //this means that current index has both left and right child
                //Find which child has max value
                bigChild = Heaparray[leftChildIndex] > Heaparray[rightChildIndex] ? leftChildIndex : rightChildIndex;

                //compare the max child with index, if child is bigger than index, then swap
                if (Heaparray[index] < Heaparray[bigChild])
                {
                    int temp = Heaparray[index];
                    Heaparray[index] = Heaparray[bigChild];
                    Heaparray[bigChild] = temp;
                }
            }

            HeapifyTopToBottom(bigChild);


        }

        public void PrintAll()
        {
            Console.WriteLine("========PRINT ALL==========");
            for (int i = 1; i < Heaparray.Length; i++)
            {
                Console.Write(Heaparray[i] + " ");
            }

            Console.WriteLine();
        }



        // int root = Heaparray[i];


        // int leftChild = Heaparray[i * 2];
        // int rightChild = Heaparray[(i * 2) + 1];
        //         if (i* 2 < Heapsize)
        //         {
        //             if (root > leftChild && root > rightChild)
        //             {
        //                 return;
        //             }
        //             else if (leftChild > rightChild && leftChild > root)
        //             {
        //                 Heaparray[i] = leftChild;
        //                 Heaparray[i * 2] = root;
        //                 i = i* 2;
        //             }
        //             else if (rightChild > leftChild && rightChild > root)
        //             {
        //                 Heaparray[i] = rightChild;
        //                 Heaparray[(i * 2) + 1] = root;
        //                 i = i* 2 + 1;
        //             }
        //         }
    }
}