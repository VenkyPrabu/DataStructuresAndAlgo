using System;

namespace DataStructuresAndAlgo.Sorting.BubbleSortAlgorithm
{
    public class BubbleSort
    {
        public void main()
        {
            int[] a = new int[10] { 3, 7, 9, 10, 6, 5, 12, 4, 11, 2 };
            Print(a);
            Bubble(a);
            Print(a);
        }

        public void Bubble(int[] a)
        {
            int n = a.Length;
            for (int i = 0; i < n - 1; i++)
            {
                bool flag = false;
                for(int j = 0; j < n-1-i; j++)
                {
                    if(a[j] > a[j+1])
                    {
                        int t = a[j+1];
                        a[j+1] = a[j];
                        a[j] = t;
                        flag = true;
                    }
                }
                if(!flag)
                {
                    return;
                }
            }
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
    }
}