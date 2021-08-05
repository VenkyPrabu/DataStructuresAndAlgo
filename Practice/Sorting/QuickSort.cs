using System;

namespace DataStructuresAndAlgo.Practice.Sorting
{
    public class QuickSort
    {
        public void main()
        {
            int[] a = new int[10] { 3, 7, 9, 10, 6, 5, 12, 4, 11, 2 };
            Print(a);
            sort(a);
            Print(a);
        }

        public void sort(int[] arr)
        {

            QSort(arr, 0, arr.Length - 1);

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


        public void QSort(int[] arr, int l, int h)
        {
            if (l < h)
            {
                int pivot_Index = Partition(arr, l, h);
                QSort(arr, l, pivot_Index - 1);
                QSort(arr, pivot_Index + 1, h);
            }
        }

        public int Partition(int[] arr, int l, int h)
        {
            //FOLLOWING LOMATOS PARTITIONING
            //Green(bigger) and Yellow(smaller) 
            int rIndex = new Random().Next(l, h);
            int pivot = arr[rIndex];

            swap(ref arr[h], ref arr[rIndex]);//swap to the right most index

            int smallPointer = l;
            int bigPointer = l;

            for (bigPointer = l; bigPointer <= h; bigPointer++)
            {
                if (arr[bigPointer] < pivot)
                {
                    swap(ref arr[smallPointer], ref arr[bigPointer]);
                    smallPointer++;//if swapping the pivot element to the right this should be after the swap in above line.

                }
            }

            swap(ref arr[h], ref arr[smallPointer]);

            return smallPointer;
        }

        public void swap(ref int x, ref int y)
        {
            int t = x;
            x = y;
            y = t;
        }


    }
}