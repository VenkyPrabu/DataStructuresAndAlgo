using System;

namespace DataStructuresAndAlgo.Algorithms
{
    //https://www.geeksforgeeks.org/floyd-warshall-algorithm-dp-16/
    public class AllPairShortestPath
    {
        public int INF = 99999, V = 4;
        public void main()
        {
            int[,] graph = { {0, 5, INF, 10},
                        {INF, 0, 3, INF},
                        {INF, INF, 0, 1},
                        {INF, INF, INF, 0}
                        };

            AllPairShortestPath a = new AllPairShortestPath();

            a.floydWarshall(graph);
        }

        public void floydWarshall(int[,] graph)
        {
            int[,] dist = new int[V, V];

            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    dist[i, j] = graph[i, j];
                }
            }

            for (int k = 0; k < V; k++)
            {
                // Pick all vertices as source
                // one by one
                for (int i = 0; i < V; i++)
                {
                    // Pick all vertices as destination
                    // for the above picked source
                    for (int j = 0; j < V; j++)
                    {
                        // If vertex k is on the shortest
                        // path from i to j, then update
                        // the value of graph[i][j]
                        if (dist[i, k] + dist[k, j] < dist[i, j])
                        {
                            dist[i, j] = dist[i, k] + dist[k, j];
                        }

                        //dist[i, j] = Math.Min(dist[i, j],dist[i, k] + dist[k, j]);
                    }
                }
            }

            printSolution(dist);
        }

        public void printSolution(int[,] dist)
        {

            
            Console.WriteLine("Following matrix shows the shortest " +
                            "distances between every pair of vertices");
            for (int i = 0; i < V; ++i)
            {
                for (int j = 0; j < V; ++j)
                {
                    if (dist[i, j] == INF)
                    {
                        Console.Write("INF ");
                    }
                    else
                    {
                        Console.Write(dist[i, j] + " ");
                    }
                }

                Console.WriteLine();
            }
        }

    }
}