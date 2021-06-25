using System;

namespace DataStructuresAndAlgo.Matrix
{
    public class Diagonal
    {
        static int n = 4;
        int[] array = new int[10];

        public void main()
        {
            set(array,1,1,5);
            set(array,2,2,8);
            set(array,3,3,9);
            set(array,4,4,12);
            Console.WriteLine(get(array,2,2));
            display(array);
        }

        public void set(int[] a, int i, int j, int value)
        {
            if (i == j)
            {
                a[i - 1] = value;
            }
        }

        public int get(int[] a, int i, int j)
        {
            if (i == j)
            {
                return a[i - 1];
            }
            return 0;
        }

        public void display(int[] a)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if(i == j)
                    Console.Write(" " + a[i]);
                    else
                        Console.Write(" 0");
                }
                Console.WriteLine();
            }

        }



    }
}