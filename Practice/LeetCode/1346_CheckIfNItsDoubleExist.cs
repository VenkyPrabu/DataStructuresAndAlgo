using System.Collections.Generic;

namespace DataStructuresAndAlgo.Practice.LeetCode
{
    public class CheckIfNItsDoubleExist
    {
        public bool CheckIfExist(int[] arr)
        {
            int n = arr.Length;
            for(int i = 0; i < n-1; i++)
            {
                for(int j = 0; j < n-1; j++)
                {
                    if(arr[i] == 2 * arr[j])
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        //O(n)
        public bool CheckIfExist_hash(int[] arr)
        {
            int n = arr.Length;
            HashSet<int> myHash = new HashSet<int>();
            for (int i = 0; i < n; i++)
            {
                if (myHash.Contains(2 * arr[i]) || (arr[i] % 2 == 0 && myHash.Contains(arr[i] / 2)))
                {
                    return true;
                }
                myHash.Add(arr[i]);
            }
            return false;
        }


    }
}