using DataStructuresAndAlgo.UnionFind;
using System;

namespace DataStructuresAndAlgo.Graph
{
    public class Kruskal
    {
        public int minTotalCost;
        public Edge[] mstEdges;

        public void main()
        {
            Edge[] edges = new Edge[]{
                new Edge(0,1,5),
                new Edge(1, 2, 4),
                new Edge(2, 9, 2),
                new Edge(0, 4, 1),
                new Edge(0, 3, 4),
                new Edge(1, 3, 2),
                new Edge(2, 7, 4),
                new Edge(2, 8, 1),
                new Edge(9, 8, 0),
                new Edge(4, 5, 1),
                new Edge(5, 6, 7),
                new Edge(6, 8, 4),
                new Edge(4, 3, 2),
                new Edge(5, 3, 5),
                new Edge(3, 6, 11),
                new Edge(6, 7, 1),
                new Edge(3, 7, 2),
                new Edge(7, 8, 6),
                };
            int numberOfNodes = 10;

            KruskalMST(edges, numberOfNodes);
            Console.WriteLine(minTotalCost);
            foreach (var Edge in mstEdges)
            {
                Console.WriteLine("Edge From {0} - To {1} with cost {2}", Edge.From, Edge.To, Edge.Cost);
            }
        }

        public void KruskalMST(Edge[] edges, int numberOfNodes)
        {
            int m = numberOfNodes - 1;
            minTotalCost = 0;
            mstEdges = new Edge[m];
            UnionFindDS uf = new UnionFindDS(numberOfNodes);
            System.Array.Sort(edges, (a, b) => a.Cost.CompareTo(b.Cost));

            int i = 0;
            foreach (var edge in edges)
            {
                if (uf.IsConnected(edge.From, edge.To))
                {
                    continue;
                }

                uf.Union(edge.From, edge.To);
                minTotalCost += edge.Cost;
                mstEdges[i++] = edge;

                if (uf.ComponentSize(0) == numberOfNodes)
                {
                    break;
                }

            }


        }
    }
}