using System;

namespace DataStructuresAndAlgo.Graph
{
    public class LCA
    {
         public void LCA_Main()
        {
            GraphDS myGraph = new GraphDS();
            myGraph.AddUnWeightedUndirectedEdge(0, 1);
            myGraph.AddUnWeightedUndirectedEdge(0, 2);
            myGraph.AddUnWeightedUndirectedEdge(1, 3);
            myGraph.AddUnWeightedUndirectedEdge(1, 4);
            myGraph.AddUnWeightedUndirectedEdge(2, 5);
            myGraph.AddUnWeightedUndirectedEdge(2, 6);
            myGraph.AddUnWeightedUndirectedEdge(2, 7);
            myGraph.AddUnWeightedUndirectedEdge(3, 8);
            myGraph.AddUnWeightedUndirectedEdge(3, 9);
            myGraph.AddUnWeightedUndirectedEdge(5, 10);
            myGraph.AddUnWeightedUndirectedEdge(5, 11);
            myGraph.AddUnWeightedUndirectedEdge(7, 12);
            myGraph.AddUnWeightedUndirectedEdge(7, 13);
            myGraph.AddUnWeightedUndirectedEdge(11, 14);
            myGraph.AddUnWeightedUndirectedEdge(11, 15);
            myGraph.AddUnWeightedUndirectedEdge(11, 16);
            TreeNode root = new TreeNode(0);
            root = root.BuildTree(myGraph.Graph, root);
            var lcaNode = FindLCA(root, 10, 15);
            Console.WriteLine("LCA is " + lcaNode.Id);
            lcaNode = FindLCA(root, 8, 13);
            Console.WriteLine("LCA is " + lcaNode.Id);
            lcaNode = FindLCA(root, 11, 12);
            Console.WriteLine("LCA is " + lcaNode.Id);
            lcaNode = FindLCA(root, 11, 11);
            Console.WriteLine("LCA is " + lcaNode.Id);
        }

        private TreeNode lcaNode;
        public TreeNode FindLCA(TreeNode root, int id1, int id2)
        {
            lcaNode = null;
            LCAHelper(root, id1, id2);
            return lcaNode;
        }

        public bool LCAHelper(TreeNode root, int id1, int id2)
        {
            if (root == null)
            {
                return false;
            }
            int count = 0;
            if (root.Id == id1)
                count++;
            if (root.Id == id2)
                count++;
            foreach (var child in root.ChildrenNodes)
            {
                if (LCAHelper(child, id1, id2))
                {
                    count++;
                }
            }
            if (count >= 2)
            {
                lcaNode = root;
            }

            return count > 0;

        }
    }
}
