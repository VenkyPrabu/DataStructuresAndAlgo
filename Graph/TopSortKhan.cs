using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgo.Graph
{
    public class TopSortKhan
    {
        public void TopSortKahn_Main()
        {
            //Cycle test
            GraphDS mygraph3 = new GraphDS();
            mygraph3.AddDirectedEdge(0, 1, 1);
            mygraph3.AddDirectedEdge(1, 2, 1);
            mygraph3.AddDirectedEdge(2, 3, 1);
            mygraph3.AddDirectedEdge(3, 0, 1);
            // int numOfNodes = 4;
            // var topSortOrder = DoTopSort(mygraph3.Graph, numOfNodes);
            // foreach (var item in topSortOrder)
            // {
            //     Console.Write(item);
            //     Console.Write("--->");
            // }
            // Console.WriteLine();

            //test 2
            GraphDS mygraph2 = new GraphDS();
            mygraph2.AddDirectedEdge(0, 1, 1);
            mygraph2.AddDirectedEdge(0, 2, 1);
            mygraph2.AddDirectedEdge(0, 5, 1);
            mygraph2.AddDirectedEdge(1, 2, 1);
            mygraph2.AddDirectedEdge(1, 3, 1);
            mygraph2.AddDirectedEdge(2, 3, 1);
            mygraph2.AddDirectedEdge(2, 4, 1);
            mygraph2.AddDirectedEdge(3, 4, 1);
            mygraph2.AddDirectedEdge(5, 4, 1);
            int numOfNodes = 6;
            var topSortOrder = DoTopSort(mygraph2.Graph, numOfNodes);
            foreach (var item in topSortOrder)
            {
                Console.Write(item);
                Console.Write("--->");
            }
        }

        public int[] DoTopSort(Dictionary<int, List<Edge>> graph, int numberOfNodes)
        {
            int[] degree = new int[numberOfNodes];
            int[] ordering = new int[numberOfNodes];
            System.Collections.Queue queue = new System.Collections.Queue();

            for (int i = 0; i < numberOfNodes; i++)
            {
                if (graph.ContainsKey(i))
                {
                    var edges = graph[i];
                    foreach (var edge in edges)
                    {
                        degree[edge.To] += 1;
                    }
                }
            }

            //enqueue all the initial nodes with degree 0 (no dependency) 
            for (int i = 0; i < numberOfNodes; i++)
            {
                if (degree[i] == 0)
                    queue.Enqueue(i);
            }

            int index = 0;
            while (queue.Count != 0)
            {
                int curr = (int)queue.Dequeue();
                ordering[index++] = curr;

                if (graph.ContainsKey(curr))
                {
                    var edges = graph[curr];

                    foreach (var edge in edges)
                    {
                        degree[edge.To] -= 1;
                        if (degree[edge.To] == 0)
                            queue.Enqueue(edge.To);
                    }
                }
            }
            if (index != numberOfNodes)
            {
                Console.WriteLine("There is a Cycle");
                //return null;
            }
            return ordering;



        }
    }
}