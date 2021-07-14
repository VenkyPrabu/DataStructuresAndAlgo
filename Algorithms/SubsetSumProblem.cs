using System;

namespace DataStructuresAndAlgo.Algorithms
{
    public class SubsetSumProblem
    {
        //https://www.youtube.com/watch?v=34l1kTIQCIA&ab_channel=TECHDOSE
        //https://drive.google.com/file/d/1qs4BIS8lSMdYICkS-QNxP_WDDU2I1HNn/view
        //https://www.geeksforgeeks.org/subset-sum-problem-dp-25/
        //TODO : https://www.geeksforgeeks.org/subset-sum-backtracking-4/
        public int[] arr = { 1, 2, 2, 3 };
        public int sum = 6;

        public void main()
        {
            Console.WriteLine("========Using Iss=======");
            Console.WriteLine(isSSRecursive(arr, arr.Length, sum));

            Console.WriteLine("========Dynamic Programming=======");
            Console.WriteLine(isSubsetSumDP(arr, arr.Length, sum));
            
        }

        public bool isSSRecursive(int[] set, int n, int sum)
        {
            if (sum != 0 && n == 0)
                return false;

            if (sum == 0)
                return true;

            //if last element is greater than sum
            //ignore the element (do not reduce it from the sum)
            if (set[n - 1] > sum)
            {
                return isSSRecursive(set, n - 1, sum);
            }

            //else check if the sum can be obtained by 
            //a) by excluding the current element OR (||)
            //b) by including the current element
            return isSSRecursive(set, n - 1, sum) || isSSRecursive(set, n - 1, sum - set[n - 1]);
        }

        public bool isSubsetSumDP(int[] set, int n, int sum)
        {

            bool[,] dp = new bool[n + 1, sum + 1];

            //If sum is 0 the ans is T
            //to fill up the all rows and 0th column to T
            for (int i = 0; i <= n; i++)
            {
                dp[i, 0] = true;
            }

            //If elements is empty and Sum != 0, then it cannot be filled
            //so it's always false
            for (int i = 1; i <= sum; i++)
            {
                dp[0, i] = false;
            }

            //fill the remaining subset
            for (int i = 1; i <= n; i++)
            {
                for (int s = 1; s <= sum; s++)
                {
                    if (s < set[i - 1])
                    {
                        dp[i,s] = dp[i-1,s];
                    }
                    
                    if(s >= set[i-1])
                    {
                        dp[i,s] = dp[i-1,s] || dp[i-1, s - set[i-1]];
                    }
                }
            }

            for(int i=0; i <=n; i++)
            {
                for(int s = 0; s <=sum; s++)
                {
                    Console.Write(dp[i,s] + " ");
                }
                Console.WriteLine();
            }

            return dp[n,sum];
        }


    }
}