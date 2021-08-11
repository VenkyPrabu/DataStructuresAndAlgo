using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgo.Practice.LeetCode.Recursion
{
    public class AllPermutations
    {
        public void main()
        {
            var ip = new int[3] { 1, 2, 3 };

            AP(ip);
        }

        List<List<int>> results = new List<List<int>>();

        public void AP(int[] nums)
        {
            List<int> input = new List<int>();

            foreach (int i in nums)
            {
                input.Add(i);
            }

            helper(input, 0);
        }

        public void helper(List<int> slate, int idx)
        {
            if (idx >= slate.Count)
            {
                results.Add(new List<int>(slate));
                Console.Write("[");

                for (int i = 0; i < slate.Count; i++)
                {
                    Console.Write(slate[i].ToString());
                }

                Console.Write("]");
                return;
            }

            for (int i = idx; i < slate.Count; i++)
            {
                Swap(slate, i, idx);
                helper(slate, idx + 1);
                Swap(slate, idx, i);
            }
        }

        public void Swap(List<int> slate, int i, int j)
        {
            int x = slate[i];
            slate[i] = slate[j];
            slate[j] = x;
        }
    }
}