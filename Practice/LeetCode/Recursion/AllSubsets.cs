using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgo.Practice.LeetCode.Recursion
{
    public class AllSubsets
    {
        //input = [1,2,3]
        //output = [ [],[1],[2],[3],[1,2],[1,3],[2,3],[1,2,3]

        public void main()
        {
            var ip = new int[3] { 1, 2, 3 };

            AS(ip);
        }


        public List<List<int>> AS(int[] input)
        {

            List<List<int>> results = new List<List<int>>();

            helper(input, 0, new List<int>(), results);

            return results;

        }

        public void helper(int[] input, int idx, List<int> slate, List<List<int>> results)
        {
            if (idx >= input.Length)
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

            int n = input[idx];
            slate.Add(n);

            helper(input, idx + 1, slate, results);

            slate.RemoveAt(slate.Count - 1);

            helper(input, idx + 1, slate, results);

        }


    }
}