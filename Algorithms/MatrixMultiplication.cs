using System;

namespace DataStructuresAndAlgo.Algorithms
{
    public class MatrixMultiplication
    {
        public void main()
        {
            int[,] mA = new int[,]
            {
                {1,1,1,1},
                {2,2,2,2},
                {3,3,3,3},
                {4,4,4,4}
            };

            int[,] mB = new int[,]
            {
                {4,4,4,4},
                {3,3,3,3},
                {2,2,2,2},
                {1,1,1,1}
            };

            var mC = Multiply(mA, mB, 4);

            Print(mC,4);
        }

        public int[,] Multiply(int[,] mA, int[,] mB, int n)
        {
            int[,] mC = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    mC[i, j] = 0;
                    for (int k = 0; k < n; k++)
                    {
                        mC[i, j] = mC[i, j] + mA[i, k] + mB[k, j];
                    }
                }
            }



            return mC;
        }

        public void Print(int[,] A, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(A[i, j] + "  ");
                }
                Console.WriteLine();
            }
        }
    }
}