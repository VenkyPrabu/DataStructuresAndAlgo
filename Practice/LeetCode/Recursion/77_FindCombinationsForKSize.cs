using System.Collections.Generic;

namespace DataStructuresAndAlgo.Practice.LeetCode.Recursion
{
    public class FindCombinationsForKSize
    {
        public void main()
        {
            var s = find_combinations(5, 2);
        }

        public List<List<int>> find_combinations(int n, int k)
        {
            var results = new List<List<int>>();
            var combinations = new List<int>();
            //helper(results, combinations, n, k, 1);
            
            combind_helper(n,k,1, new List<int>(), results);
            return results;

        }

        //m1
        public void helper(List<List<int>> results, List<int> combinations, int n, int k, int index)
        {
            if (k == 0)
            {
                results.Add(new List<int>(combinations));
                return;
            }

            

            for (int i = index; i <= n; i++)
            {
                combinations.Add(i);
                helper(results, combinations, n, k - 1, i + 1);
                combinations.RemoveAt(combinations.Count - 1);
            }


        }


        //m2
        public void combind_helper(int n, int k, int subproblem, List<int> partial_solution, List<List<int>> result)
        {
            if (partial_solution.Count == k)
            {
                result.Add(new List<int>(partial_solution));
                return;
            }
            if (subproblem == n + 1)
                return;

            //exclude
            combind_helper(n, k, subproblem + 1, partial_solution, result);

            //include
            partial_solution.Add(subproblem);
            combind_helper(n, k, subproblem + 1, partial_solution, result);
            partial_solution.RemoveAt(partial_solution.Count - 1);


        }

    }
}