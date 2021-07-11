namespace DataStructuresAndAlgo.Algorithms
{
    public class MergeSort
    {
        public void main()
        {

        }

        public int[] MSIterative(int[] A, int[] B)
        {
            int i = 0, j = 0, k = 0;
            int[] C = new int[A.Length + B.Length];

            while (i < A.Length && j < B.Length)
            {
                if (A[i] < B[j])
                {
                    C[k++] = A[i++];
                }
                else
                {
                    C[k++] = B[j++];
                }
            }

            for (; i < A.Length; i++)
            {
                C[k++] = A[i];
            }

            for (; j < B.Length; j++)
            {
                C[k++] = B[j];
            }

            return C;

        }
    }

}