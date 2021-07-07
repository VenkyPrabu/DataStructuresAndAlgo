using System;
using System.Collections.Generic;
using DataStructuresAndAlgo.PriorityQueue;

namespace DataStructuresAndAlgo.Graph
{
    public class Node
    {
        public int Id;
        public int Value;

        public Node(int id, int value)
        {
            Id = id;
            Value = value;
        }
    }
    public class Dijkstra
    {
        public int[] Dijkstra_SSSP(Dictionary<int, List<Edge>> mygraph, int source, int numberOfNodes)
        {
            int n = numberOfNodes;

            int[] distance = new int[n];
            bool[] visited = new bool[n];

            for (int i = 0; i < n; i++)
            {
                distance[i] = int.MaxValue;
                visited[i] = false;
            }

            distance[source] = 0;

            PriorityQueue<Node> pq = new PriorityQueue<Node>(true);
            Node sourceNode = new Node(source, 0);
            pq.Enqueue(source, sourceNode);

            while (pq.Count != 0)
            {
                Node currNode = pq.Dequeue();
                visited[currNode.Id] = true;
                if(mygraph.ContainsKey(currNode.Id))
                {
                    var edges = mygraph[currNode.Id];
                    if(distance[currNode.Id] < currNode.Value)
                    {
                        continue;
                    }
                    foreach(var edge in edges)
                    {
                        if(visited[edge.To])
                        {
                            continue;
                        }

                        int newDistance = currNode.Value + edge.Cost;
                        if(newDistance < distance[edge.To])
                        {
                            distance[edge.To] = newDistance;
                            pq.Enqueue(newDistance, new Node(edge.To,newDistance));
                        }
                    }
                }
            }

            return distance;
        }



        public void Dijkstra_Main()
        {
            GraphDS myGraph = new GraphDS();
            myGraph.AddDirectedEdge(0, 1, 4);
            myGraph.AddDirectedEdge(0, 2, 1);
            myGraph.AddDirectedEdge(2, 1, 2);
            myGraph.AddDirectedEdge(1, 3, 1);
            myGraph.AddDirectedEdge(2, 3, 5);
            myGraph.AddDirectedEdge(3, 4, 3);
            var output = Dijkstra_SSSP(myGraph.Graph, 0, 5);
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("The Distance from source to {0} is {1}", i, output[i]);
            }
        }

    }
}