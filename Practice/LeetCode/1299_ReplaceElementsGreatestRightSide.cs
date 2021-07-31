using System;

namespace DataStructuresAndAlgo.Practice.LeetCode
{
    public class ReplaceElementsGreatestRightSide
    {
        //https://leetcode.com/problems/replace-elements-with-greatest-element-on-right-side/

        //O(n^2)
        public int[] ReplaceElements(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {

                int max = 0;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] > max)
                    {
                        max = arr[j];
                    }
                }

                arr[i] = max;
            }

            arr[n - 1] = -1;

            return arr;
        }

        //O(n)
        public int[] ReplaceElements_Linear(int[] arr)
        {
            int n = arr.Length;
            int max = -1;
            int temp = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                temp = arr[i];
                arr[i] = max;
                max = Math.Max(max, temp);
            }
            return arr;
        }


    }
}