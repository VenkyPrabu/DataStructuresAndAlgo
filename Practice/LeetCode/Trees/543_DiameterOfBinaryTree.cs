using System;

namespace DataStructuresAndAlgo.Practice.LeetCode.Trees
{
    public class DiameterOfBinaryTree
    {
        //https://leetcode.com/problems/diameter-of-binary-tree/

        public int maxDiameter = 0;

        public int DiameterOfBT(TreeNode root)
        {

            if (root == null) return 0;

            helper(root);

            return maxDiameter;

        }

        private int helper(TreeNode root)
        {
            //base case
            if (root.left == null && root.right == null)
            {
                return 0;
            }

            //recursion
            int lmax = 0;
            int rmax = 0;

            if (root.left != null) lmax = helper(root.left) + 1;

            if (root.right != null) rmax = helper(root.right) + 1;

            maxDiameter = Math.Max(maxDiameter, lmax + rmax);

            return Math.Max(lmax, rmax);

        }
    }
}