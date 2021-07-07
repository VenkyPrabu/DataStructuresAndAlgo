using System;
using static DataStructuresAndAlgo.Utilities.Utilities;

namespace DataStructuresAndAlgo.Algorithms
{
    public class MinHeap
    {
        public int heapsize;
        public int heapCapacity;
        public int[] heaplist;

        public MinHeap(int size)
        {
            heaplist = new int[size];
            heapCapacity = size;
            heapsize = 0;
        }

        public MinHeap()
        {

        }

        public void main()
        {
            MinHeap myHeap = new MinHeap(7);
            myHeap.Insert(10);
            myHeap.Insert(20);
            myHeap.Insert(15);
            myHeap.Insert(30);
            myHeap.Insert(40);
            myHeap.Insert(5);
            myHeap.Insert(60);
            PrintArray(myHeap.heaplist);
            Console.WriteLine(myHeap.Extract());
            PrintArray(myHeap.heaplist);
        }

        public int GetParent(int index)
        {
            return (index - 1) / 2;
        }

        public int GetLeftChild(int index)
        {
            return 2 * index + 1;
        }

        public int GetRightChild(int index)
        {
            return 2 * index + 2;
        }

        public void Insert(int value)
        {
            if (heapsize >= heapCapacity)
            {
                Console.WriteLine("Heap is full");
                return;
            }

            heaplist[heapsize] = value;
            HeapifyBottomToTop(heapsize);
            heapsize++;
        }

        public void HeapifyBottomToTop(int index)
        {
            if (index < 1)
            {
                return;
            }
            int parent = GetParent(index);

            if (heaplist[index] < heaplist[parent])
            {
                int temp = heaplist[index];
                heaplist[index] = heaplist[parent];
                heaplist[parent] = temp;
                HeapifyBottomToTop(parent);
            }
        }

        public int Extract()
        {
            if (heapsize == 0)
            {
                Console.WriteLine("Heap is empty");
                return -1;
            }

            int extratedvalue = heaplist[0];
            heaplist[0] = heaplist[heapsize - 1];
            heapsize--;
            HeapifyTopToBottom(0);
            heaplist[heapsize] = extratedvalue;
            return extratedvalue;
        }

        public void HeapifyTopToBottom(int index)
        {
            int left = GetLeftChild(index);
            int right = GetRightChild(index);

            if (left > heapsize)
            {
                // no child
                return;
            }
            else if (left == heapsize)
            {
                //has only left child
                if (heaplist[left] < heaplist[index])
                {
                    int temp = heaplist[index];
                    heaplist[index] = heaplist[left];
                    heaplist[left] = temp;
                    return;
                }
            }
            else
            {
                //if both child are available
                int smallest = 0;
                smallest = heaplist[left] < heaplist[right] ? left : right;
                if (heaplist[smallest] < heaplist[index])
                {
                    int temp = heaplist[index];
                    heaplist[index] = heaplist[smallest];
                    heaplist[smallest] = temp;
                    HeapifyTopToBottom(smallest);
                }
            }
        }
    }
}