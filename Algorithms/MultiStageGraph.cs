using System;

namespace DataStructuresAndAlgo.Algorithms
{
    //https://www.geeksforgeeks.org/multistage-graph-shortest-path/
    public class MultiStageGraph
    {
        public int N = 8;
        public int INF = int.MaxValue;
        public void main()
        {
            int[,] graph = new int[,]
          {{INF, 1, 2, 5, INF, INF, INF, INF},
           {INF, INF, INF, INF, 4, 11, INF, INF},
           {INF, INF, INF, INF, 9, 5, 16, INF},
           {INF, INF, INF, INF, INF, INF, 2, INF},
           {INF, INF, INF, INF, INF, INF, INF, 18},
           {INF, INF, INF, INF, INF, INF, INF, 13},
           {INF, INF, INF, INF, INF, INF, INF, 2}};

            Console.Write(shortestDist(graph));
        }

        public int shortestDist(int[,] graph)
        {
            int[] dist = new int[N];

            dist[N - 1] = 0;

            for (int i = N - 2; i >= 0; i--)
            {
                dist[i] = INF;

                for (int j = i; j < N; j++)
                {
                    if (graph[i, j] == INF)
                    {
                        continue;
                    }

                    dist[i] = Math.Min(dist[i], graph[i, j] + dist[j]);
                }
            }

            return dist[0];
        }
    }
}