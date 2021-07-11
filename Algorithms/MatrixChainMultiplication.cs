using System;

namespace DataStructuresAndAlgo.Algorithms
{
    public class MatrixChainMultiplication
    {

        public int[,] dp = new int[100, 100];
        public void main()
        {
            int[] arr = new int[] { 5, 4, 6, 2, 7 };

            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    dp[i, j] = -1;
                }
            }

            Console.WriteLine("----Iterative---------");
            Console.WriteLine(Iterative(arr));

            Console.WriteLine("----Recursive---------");
            Console.WriteLine(Recursive(arr, 1, arr.Length - 1));

            
            Console.WriteLine("----Memoization---------");
            Console.WriteLine(Memoization(arr, 1, arr.Length - 1));
        }

        public int Iterative(int[] arr)
        {
            int n = arr.Length;

            int[,] m = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                m[i, i] = 0;
            }

            int j = 0;
            int min = 0;
            int count = 0;
            for (int d = 1; d < n - 1; d++)
            {
                for (int i = 1; i < n - d; i++)
                {
                    j = i + d;
                    min = int.MaxValue;
                    for (int k = i; k <= j - 1; k++)
                    {
                        count = m[i, k] + m[k + 1, j] + (arr[i - 1] * arr[k] * arr[j]);
                        if (count < min)
                        {
                            min = count;
                        }
                    }
                    m[i, j] = min;
                }
            }

            return m[1, n - 1];
        }

        public int Recursive(int[] arr, int l, int r)
        {   //https://www.youtube.com/watch?v=zQrR8t7urEE&ab_channel=TECHDOSE
            if (l == r)
            {
                return 0;
            }

            int min = int.MaxValue;
            for (int k = l; k < r; k++)
            {
                int count = Recursive(arr, l, k) + Recursive(arr, k + 1, r) + (arr[l - 1] * arr[k] * arr[r]);
                if (count < min)
                {
                    min = count;
                }
            }

            return min;
        }

        public int Memoization(int[] arr, int l, int r)
        {
            if (l == r)
            {
                return 0;
            }
            else if (dp[l, r] != -1)
            {
                return dp[l, r];
            }
            else
            {
                dp[l,r] = int.MaxValue;

                for(int k = l; k < r; k++)
                {
                    dp[l,r] = Math.Min(dp[l,r],
                                        Memoization(arr,l,k) + Memoization(arr,k+1,r) + (arr[l-1] * arr[k] * arr[r]));
                }
            }

            return dp[l,r];
        }

    }
}