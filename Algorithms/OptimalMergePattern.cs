using System;

namespace DataStructuresAndAlgo.Algorithms
{
    public class OptimalMergePattern
    {
        //https://www.geeksforgeeks.org/optimal-file-merge-patterns/
        public void main()
        {
            int size = 6;
            int[] files = new int[] { 2, 3, 4, 5, 6, 7 };
            var output = OMP(files, size);
            Console.WriteLine(output);
        }

        public int OMP(int[] list, int size)
        {
            MinHeap minHeap = new MinHeap(size);

            foreach (var item in list)
            {
                minHeap.Insert(item);
            }

            int count = 0;

            while (minHeap.heapsize > 0)
            {
                int temp = minHeap.Extract() + minHeap.Extract();
                minHeap.Insert(temp);
                count += temp;
            }

            return count;
        }
    }


}