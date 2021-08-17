using System.Collections.Generic;

namespace DataStructuresAndAlgo.Practice.LeetCode.Trees
{
    /**
    * Definition for a binary tree node. */
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class LevelOrderTraversal
    {
        //https://leetcode.com/problems/binary-tree-level-order-traversal/

        //Variations
        //LC: 429,103,199,107
        public void main()
        {

        }


        public List<List<int>> LOT(TreeNode root)
        {
            List<List<int>> result = new List<List<int>>();

            //edge case 
            if (root == null) return result;

            //Create a queue
            System.Collections.Generic.Queue<TreeNode> qq = new System.Collections.Generic.Queue<TreeNode>();
            //add root to queue
            qq.Enqueue(root);

            //for zigzag [Variation 2 - Zigzag]
            bool flip = false;

            while (qq.Count > 0)
            {
                List<int> resultInLevel = new List<int>();
                int sizeInLevel = qq.Count;

                for (int i = 0; i < sizeInLevel; i++)
                {
                    //remove the node 
                    var node = qq.Dequeue();
                    
                    //add it to the result in level
                    resultInLevel.Add(node.val);

                    //Add children 
                    //[Vairation 1 - N-Ary] (for N-Array just have a for loop here for number of children)
                    //https://leetcode.com/problems/n-ary-tree-level-order-traversal/submissions/
                    if (node.left != null) qq.Enqueue(node.left);

                    if (node.right != null) qq.Enqueue(node.right);
                }

                //for zigzag [Variation 2 - Zigzag] https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/
                //if(flip) resultInLevel.Reverse();

                result.Add(resultInLevel);

                //for zigzag [Variation 2 - Zigzag]
                //flip = !flip;
            }
            return new result;
        }
    }
}