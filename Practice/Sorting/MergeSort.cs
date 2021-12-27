using System;

namespace DataStructuresAndAlgo.Practice.Sorting
{
    public class MergeSort
    {
        public void main()
        {
            int[] a = new int[7] { 3, 2, 9, 11, 6, 5, -1 };
            Print(a);
            sort(a);
            Print(a);
        }


        public void sort(int[] arr)
        {
            MergeSortHelper(arr,0,arr.Length -1);
        }

        public void MergeSortHelper(int[] arr, int l, int h)
        {
            if (l >= h)
            {
                return;
            }

            int m = (l + h) / 2;
            MergeSortHelper(arr, l, m);
            MergeSortHelper(arr, m + 1, h);

            //Merge
            int i = l;
            int j = m + 1;
            int k = 0;
            int[] aux = new int[h-l+1];

        
            while (i <= m && j <= h)
            {
                if (arr[i] <= arr[j])
                {
                    aux[k++] = arr[i++];
                }
                else
                {
                    aux[k++] = arr[j++];
                }
            }

            while (i <= m)
            {
                aux[k++] = arr[i++];
            }

            while (j <= h)
            {
                aux[k++] = arr[j++];
            }

            for (int c = 0; c < aux.Length ; c++)
            {
                arr[l+c] = aux[c];
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