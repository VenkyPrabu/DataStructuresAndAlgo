using System;

namespace DataStructuresAndAlgo.Sorting
{
    public class SelectionSort
    {
        public void main()
        {
            int[] a = new int[10] { 3, 7, 9, 10, 6, 5, 12, 4, 11, 2 };
            Print(a);
            SelectSort(a);
            Print(a);
        }

        public void Print(int[] a)
        {
            Console.WriteLine("=============PRINT============");
            for(int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }

            Console.WriteLine();
        }

        public void SelectSort(int[] a)
        {
            int i , j, k;
            for(i  = 0; i < a.Length - 1; i++)
            {
                 for(j=k=i; j< a.Length; j++)
                 {
                     if(a[j] < a[k])
                     {
                         k = j;
                     }
                 }
                 int x = a[i];
                 a[i] = a[k];
                 a[k] = x;
            }
        }
    }
}