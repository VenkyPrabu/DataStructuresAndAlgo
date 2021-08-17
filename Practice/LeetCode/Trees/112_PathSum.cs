namespace DataStructuresAndAlgo.Practice.LeetCode.Trees
{
    public class PathSum
    {
        //https://leetcode.com/problems/path-sum/submissions/
        //Variation : https://leetcode.com/problems/path-sum-ii/submissions/


        public bool HasPathSum(TreeNode root, int targetSum)
        {

            if (root == null) return false;

            targetSum -= root.val;

            //base case
            if (root.left == null && root.right == null)
            {
                if (targetSum == 0) return true;
            }

            if (HasPathSum(root.left, targetSum))
            {
                return true;
            }

            return HasPathSum(root.right, targetSum);

        }
    }
}