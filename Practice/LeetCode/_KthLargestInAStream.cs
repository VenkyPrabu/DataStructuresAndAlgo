using System.Collections.Generic;

namespace DataStructuresAndAlgo.Practice.LeetCode
{
    public class _KthLargestInAStream
    {
        public void main()
        {
            var s = kth_largest(2, new List<int>{4,6}, new List<int>{5,2,20});
        }

        //brute force
        public static List<int> kth_largest(int k, List<int> initial_stream, List<int> append_stream)
        {
            List<int> res = new List<int>();

            foreach (var i in append_stream)
            {
                initial_stream.Add(i);
                initial_stream.Sort();

                res.Add(initial_stream[initial_stream.Count - k]);
            }

            return res;
        }

    }



}