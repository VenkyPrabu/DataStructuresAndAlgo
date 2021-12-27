using System;

namespace DataStructuresAndAlgo.Sorting
{
    public class InsertionSort
    {
        public void main()
        {
            int[] a = new int[10] { 3, 7, 9, 10, 6, 5, 12, 4, 11, 2 };
            Print(a);
            InsertSort(a);
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

        //https://www.youtube.com/watch?v=yCxV0kBpA6M       
        public void InsertSort(int[] a)
        {
            int n = a.Length;
            
            for(int i = 1; i < n ; i++)
            {
                int x = a[i];    
                int j = i-1;

                while(j > -1 && a[j] > x)
                {
                    a[j+1]=a[j];
                    j--;
                }
                a[j+1] = x;
            }
        }

        
    }
}