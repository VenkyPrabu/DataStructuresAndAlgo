using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgo.Graph
{
    public class IsomorphicTree: TreeCenter
    {

        public void Isomorphic_Main()
        {
            GraphDS myGraph = new GraphDS();
            myGraph.AddUnWeightedUndirectedEdge(0, 2);
            myGraph.AddUnWeightedUndirectedEdge(0, 1);
            myGraph.AddUnWeightedUndirectedEdge(0, 3);
            myGraph.AddUnWeightedUndirectedEdge(2, 6);
            myGraph.AddUnWeightedUndirectedEdge(2, 7);
            myGraph.AddUnWeightedUndirectedEdge(1, 4);
            myGraph.AddUnWeightedUndirectedEdge(1, 5);
            myGraph.AddUnWeightedUndirectedEdge(5, 9);
            myGraph.AddUnWeightedUndirectedEdge(3, 8);
            TreeNode root = new TreeNode(0);
            root = root.BuildTree(myGraph.Graph, root);
            if (root.Encode(root).Equals("(((())())(()())(()))"))
            {
                Console.WriteLine("The Encoding Matches");
            }

            GraphDS myGraph1 = new GraphDS();
            myGraph1.AddUnWeightedUndirectedEdge(2, 0);
            myGraph1.AddUnWeightedUndirectedEdge(3, 4);
            myGraph1.AddUnWeightedUndirectedEdge(2, 1);
            myGraph1.AddUnWeightedUndirectedEdge(2, 3);

            GraphDS myGraph2 = new GraphDS();
            myGraph2.AddUnWeightedUndirectedEdge(1, 0);
            myGraph2.AddUnWeightedUndirectedEdge(2, 4);
            myGraph2.AddUnWeightedUndirectedEdge(1, 3);
            myGraph2.AddUnWeightedUndirectedEdge(1, 2);

            if (IsIsomorphic(myGraph1.Graph, myGraph2.Graph))
            {
                Console.WriteLine("The Graphs are Isomorphic");
            }
        }
        public bool IsIsomorphic(Dictionary<int, List<Edge>> graph1, Dictionary<int, List<Edge>> graph2)
        {

            if (graph1 == null || graph2 == null)
            {
                return false;
            }
            //find center for graphs
            List<int> graph1_center = FindCenter(graph1);
            List<int> graph2_center = FindCenter(graph2);

            //rooting graph1 at center
            TreeNode graph1_root = new TreeNode(graph1_center[0]);
            graph1_root = graph1_root.BuildTree(graph1, graph1_root);
            //Encode graph1
            string graph1_encode = graph1_root.Encode(graph1_root);

            // We are looping in this graph to account if there is 2 centers 
            foreach (var g2Center in graph2_center)
            {
                TreeNode graph2_root = new TreeNode(g2Center);
                graph2_root = graph2_root.BuildTree(graph2, graph2_root);
                string graph2_encode = graph2_root.Encode(graph2_root);
                if (graph1_encode == graph2_encode)
                    return true;
            }
            return false;
        }
    }
}