using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgo.Graph
{
    public class TopSort
    {
        public void TopSort_Main()
        {
            GraphDS mygraph = new GraphDS();
            mygraph.AddDirectedEdge(0, 1, 3);
            mygraph.AddDirectedEdge(0, 2, 2);
            mygraph.AddDirectedEdge(0, 5, 3);
            mygraph.AddDirectedEdge(1, 3, 1);
            mygraph.AddDirectedEdge(1, 2, 6);
            mygraph.AddDirectedEdge(2, 3, 1);
            mygraph.AddDirectedEdge(2, 4, 10);
            mygraph.AddDirectedEdge(3, 4, 5);
            mygraph.AddDirectedEdge(5, 4, 7);
            int numOfNodes = 6;
            var topSortOrder = DoTopSort(mygraph.Graph, numOfNodes);
            foreach (var item in topSortOrder)
            {
                Console.Write(item);
                Console.Write("--->");
            }
            Console.WriteLine();

        }

        public int[] DoTopSort(Dictionary<int, List<Edge>> graph, int numOfNodes)
        {
            bool[] visited = new bool[numOfNodes];
            int[] ordering = new int[numOfNodes];
            int i = numOfNodes - 1;

            for (int at = 0; at < numOfNodes; at++)
            {
                if (!visited[at])
                {
                    i = bfs(i, at, visited, ordering, graph);
                }
            }
            return ordering;
        }
        public int bfs(int i, int idx, bool[] visited, int[] ordering, Dictionary<int, List<Edge>> graph)
        {
            visited[idx] = true;
            if (graph.ContainsKey(idx))
            {
                List<Edge> edges = graph[idx];
                foreach (var edge in edges)
                {
                    if (!visited[edge.To])
                    {
                        i = bfs(i, edge.To, visited, ordering, graph);
                    }
                }
            }
            ordering[i] = idx;
            i = i - 1;
            return i;
        }
    }
}