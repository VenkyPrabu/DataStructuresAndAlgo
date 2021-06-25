using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgo.Graph
{
    public class ShortestPath
    {
        public void main()
        {
            GraphDS mygraph2 = new GraphDS();
            mygraph2.AddDirectedEdge(0, 1, 2);
            mygraph2.AddDirectedEdge(0, 2, 3);
            mygraph2.AddDirectedEdge(0, 5, 5);
            mygraph2.AddDirectedEdge(1, 2, 2);
            mygraph2.AddDirectedEdge(1, 3, 11);
            mygraph2.AddDirectedEdge(2, 3, -5);
            mygraph2.AddDirectedEdge(2, 4, 8);
            mygraph2.AddDirectedEdge(3, 4, 6);
            mygraph2.AddDirectedEdge(5, 4, 1);
            int numOfNodes = 6;
            int startNode = 0;

            var d = shortestPath(mygraph2.Graph, startNode, numOfNodes);

            for (int i = 0; i < d.Length; i++)
            {
                Console.WriteLine("Node [" + startNode+ " to " + i + "] Distance [" + d[i] + "]");
            }
        }


        public int[] shortestPath(Dictionary<int, List<Edge>> graph, int start, int numberOfNodes)
        {
            TopSortKhan ts = new TopSortKhan();
            int[] topsort = ts.DoTopSort(graph, numberOfNodes);
            int[] dist = new int[numberOfNodes];

            for (int i = 0; i < numberOfNodes; i++)
            {
                dist[i] = int.MaxValue;
            }
            dist[start] = 0;

            for (int i = 0; i < numberOfNodes; i++)
            {
                int index = topsort[i];

                if (graph.ContainsKey(index))
                {
                    var edges = graph[index];

                    foreach (var edge in edges)
                    {
                        int newdist = dist[index] + edge.Cost;
                        dist[edge.To] = Math.Min(dist[edge.To], newdist);
                    }
                }
            }

            return dist;
        }
    }
}