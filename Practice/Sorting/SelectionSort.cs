using System;

namespace DataStructuresAndAlgo.Practice.Sorting
{
    public class SelectionSort
    {
        public void main()
        {
            // int[] a = new int[5]{2,9,1,5,7};
            //int[] a = new int[5]{10,9,8,7,6};
            int[] a = new int[5]{-10,9,8,7,-66};
            Print(sort(a));
        }

        public int[] sort(int[] elements)
        {
            int i,j,k;
            for (i = 0; i < elements.Length; i++)
            {
                for (j=k=i; j < elements.Length; j++)
                {
                    if (elements[k] > elements[j])
                    {
                        k = j;
                    }
                }
                int min = elements[i];
                elements[i] = elements[k];
                elements[k] = min;
            }

            return elements;
        }

        public void Print(int[] a)
        {
            foreach(int i in a)
            {
                Console.Write(i + " ");
            }
        }


    }
}