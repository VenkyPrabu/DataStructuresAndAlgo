using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgo.Graph
{
    public class TreeCenter : GraphDS
    {

        public void main()
        {
            GraphDS myGraph = new GraphDS();
            myGraph.AddUnWeightedUndirectedEdge(0, 1);
            myGraph.AddUnWeightedUndirectedEdge(2, 1);
            myGraph.AddUnWeightedUndirectedEdge(2, 3);
            myGraph.AddUnWeightedUndirectedEdge(3, 4);
            myGraph.AddUnWeightedUndirectedEdge(5, 3);
            myGraph.AddUnWeightedUndirectedEdge(2, 6);
            myGraph.AddUnWeightedUndirectedEdge(6, 7);
            myGraph.AddUnWeightedUndirectedEdge(6, 8);
            //var list = FindCenter(myGraph.Graph);
            //list.ForEach(Console.WriteLine);

            // Centers are 0
            Console.WriteLine("The center should be 0-------");
            GraphDS myGraph2 = new GraphDS();
            //myGraph2.AddUnWeightedUndirectedEdge(0, 0);
            var list = FindCenter(myGraph2.Graph);
            list.ForEach(Console.WriteLine);

            // // Centers are 0,1
            // Console.WriteLine("The center should be 0,1 -------");
            // GraphDS myGraph3 = new GraphDS();
            // myGraph3.AddUnWeightedUndirectedEdge(0, 1);
            // list = FindCenter(myGraph3.Graph);
            // list.ForEach(Console.WriteLine);
        }

        public List<int> FindCenter(Dictionary<int, List<Edge>> Graph)
        {
            int n = Graph.Count;
            int[] degree = new int[n];
            List<int> leaves = new List<int>();

            foreach (var item in Graph)
            {
                degree[item.Key] = Graph[item.Key].Count;
                if (degree[item.Key] == 1 || degree[item.Key] == 0)
                {
                    leaves.Add(item.Key);
                    degree[item.Key] = 0;
                }
            }

            int count = leaves.Count;

            if(count == 0)
            {
                leaves.Add(0);
                return leaves;
            }
            while (count < n)
            {
                List<int> new_leaves = new List<int>();
                foreach (var item in leaves)
                {
                    var neighbours = Graph[item];
                    foreach (var node in neighbours)
                    {
                        degree[node.To] = degree[node.To] - 1;
                        if (degree[node.To] == 1)
                        {
                            new_leaves.Add(node.To);
                        }
                    }
                    degree[item] = 0;
                }
                count += new_leaves.Count;
                leaves = new_leaves;
            }

            return leaves;
        }

    }
}