using System;

namespace DataStructuresAndAlgo.Practice.Sorting
{
    public class HeapSort
    {
        public void main()
        {
            int[] list = { 23, 12, 2, 87, 54, 21, 98, 31, 44, 10 };
            Console.WriteLine("----------Heap Sort-------------");
            Console.WriteLine("----------Heapify-------------");
            Console.WriteLine("Before ->");
            Print(list);
            sort(list);
            Console.WriteLine("After ->");
            Print(list);
        }

        public void sort(int[] arr)
        {
            int n = arr.Length;

            //build head - O(n)
            //start with parent of the last child => n/2 -1
            for (int i = (n / 2) - 1; i >= 0; i--)
            {
                Heapify(arr, n, i);
            }

            //extract - O (n log n) for n elements and do heapify
            for (int i = n - 1; i >= 0; i--)
            {
                int x = arr[0];
                arr[0] = arr[i];
                arr[i] = x;
                Heapify(arr, i, 0);//i is the n here as we have to reduce the size of the heap once we extract
            }

        }


        public void Heapify(int[] arr, int n, int i)
        {
            //max heap
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            int largest = i;

            if (left < n && arr[left] > arr[largest])
            {
                largest = left;
            }

            if (right < n && arr[right] > arr[largest])
            {
                largest = right;
            }

            //when the parent index (i) has been changed from any1 of the above if statements
            if (largest != i)
            {
                int x = arr[i];
                arr[i] = arr[largest];
                arr[largest] = x;
                Heapify(arr, n, largest);
            }

        }


        public void Print(int[] a)
        {
            Console.WriteLine("=============PRINT============");
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }

            Console.WriteLine();
        }
    }
}