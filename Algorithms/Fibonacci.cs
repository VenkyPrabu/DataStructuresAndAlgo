using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgo.Algorithms
{
    public class Fibonacci
    {

        Dictionary<int, double> memo = new Dictionary<int, double>();
        public void main()
        {
            Console.WriteLine("--------------Fibonnacci - Memoization---------");
            Console.WriteLine(FibMemo(0));
            Console.WriteLine("--------------Fibonnacci - Tabulation---------");
            Console.WriteLine(FibTabulation(0));
        }


        public double FibMemo(int n)
        {
            if (n <= 1)
            {
                return n;
            }

            else if (memo.ContainsKey(n))
            {
                return memo[n];
            }
            else
            {
                double value = FibMemo(n - 2) + FibMemo(n - 1);
                memo[n] = value;
                return value;
            }
        }

        public double FibTabulation(int n)
        {
            if(n <= 1)
            {
                return n;
            }
            double[] fib = new double[n + 1];

            fib[0] = 0;
            fib[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                fib[i] = fib[i - 2] + fib[i - 1];
            }

            return fib[n];
        }
    }
}