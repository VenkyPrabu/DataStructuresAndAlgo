using System;

namespace DataStructuresAndAlgo.Practice.Sorting
{
    public class QuickSort
    {
        public void main()
        {
            int[] a = new int[10] { 3, 7, 9, 10, 6, 5, 12, 4, 11, 2};
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
                //FOLLOWING LOMATOS PARTITIONING
                //Green(bigger) and Yellow(smaller) 
                int rIndex = new Random().Next(l, h);
                swap(ref arr[l], ref arr[rIndex]);
                int pivot = arr[l];

                int smallPointer = l;
                int bigPointer = l;

                for (bigPointer = l + 1; bigPointer <= h; bigPointer++)
                {
                    if (arr[bigPointer] < pivot)
                    {
                        smallPointer++;
                        swap(ref arr[smallPointer], ref arr[bigPointer]);
                    }
                }

                swap(ref arr[l], ref arr[smallPointer]);

                QSort(arr, l, smallPointer - 1);
                QSort(arr, smallPointer + 1, h);
            }
        }

        public void swap(ref int x, ref int y)
        {
            int t = x;
            x = y;
            y = t;
        }


    }
}