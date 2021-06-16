using System;

namespace DataStructuresAndAlgo.Sorting.QuickSortAlgorithm
{
    public class QuickSort
    {
        public void main()
        {
            int[] a = new int[11] { 3, 7, 9, 10, 6, 5, 12, 4, 11, 2 , int.MaxValue};
            Print(a);
            QuickS(a, 0, a.Length -1);
            Print(a);
        }

        public void QuickS(int[] a, int l, int h)
        {
            int j = 0;

            if(l<h)
            {
                j = Partition(a,l,h);
                QuickS(a,l,j);
                QuickS(a,j+1,h);
            }
        }


        public int Partition(int[] a, int l, int h)
        {
            int pivot = a[l];
            int i = l, j = h;

            do
            {
                do { i++; } while(a[i] <= pivot);
                do { j--; } while(a[j] > pivot);
                if(i < j)
                {
                    swap(ref a[i],ref a[j]);
                }
            }
            while (i < j);

            swap(ref a[l],ref a[j]);
            
            return j;
        }

        public void swap(ref int x, ref int y)
        {
            int t = x;
            x = y;
            y = t;
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