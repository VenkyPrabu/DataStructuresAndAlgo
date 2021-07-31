using System;

namespace DataStructuresAndAlgo.Practice.LeetCode
{
    public class heightchecker
    {
        //https://leetcode.com/problems/height-checker/

        public void main()
        {

        }

        public int heightchecker1(int[] heights)
        {
            int[] expected = new int[heights.Length];

            for(int i = 0; i < heights.Length; i++)
            {
                expected[i] = heights[i];
            }

            System.Array.Sort(expected);

            int count = 0;

            for(int i = 0; i < heights.Length; i++)
            {
                if(heights[i] != expected[i])
                {
                    count++;
                }
            }

            return count;
        }
    }
}