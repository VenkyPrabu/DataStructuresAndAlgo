using DataStructuresAndAlgo.PriorityQueue;

namespace DataStructuresAndAlgo.Graph
{
    public class LazyPrims
    {
        GraphDS myGraph;
        public bool[] visited;
        public PriorityQueue<Edge> pq = new PriorityQueue<Edge>(true);
        public Edge[] mstEdges;
        public int totalMincost = 0;

        public void main()
        {
            int numberOfNodes = 10;
            myGraph = new GraphDS();
            myGraph.AddUndirectedEdge(0, 1, 5);
            myGraph.AddUndirectedEdge(1, 2, 4);
            myGraph.AddUndirectedEdge(2, 9, 2);
            myGraph.AddUndirectedEdge(0, 4, 1);
            myGraph.AddUndirectedEdge(0, 3, 4);
            myGraph.AddUndirectedEdge(1, 3, 2);
            myGraph.AddUndirectedEdge(2, 7, 4);
            myGraph.AddUndirectedEdge(2, 8, 1);
            myGraph.AddUndirectedEdge(9, 8, 0);
            myGraph.AddUndirectedEdge(4, 5, 1);
            myGraph.AddUndirectedEdge(5, 6, 7);
            myGraph.AddUndirectedEdge(6, 8, 4);
            myGraph.AddUndirectedEdge(4, 3, 2);
            myGraph.AddUndirectedEdge(5, 3, 5);
            myGraph.AddUndirectedEdge(3, 6, 11);
            myGraph.AddUndirectedEdge(6, 7, 1);
            myGraph.AddUndirectedEdge(3, 7, 2);
            myGraph.AddUndirectedEdge(7, 8, 6);
        }

        public void PrimsMST(int numberOfNodes)
        {
            int m = numberOfNodes - 1;
            int edgeCount = 0;
            visited = new bool[numberOfNodes];
            mstEdges = new Edge[m];
            pq = new PriorityQueue<Edge>(true);

            //Add the first edge to PQ
            AddEdges(0);

            while(pq.Count != 0 && edgeCount != m)
            {
                Edge edge = pq.Dequeue();
                int idx = edge.To;

                if(visited[idx])
                {
                    continue;
                }

                mstEdges[edgeCount++] = edge;
                totalMincost += edge.Cost;
                AddEdges(idx);
            }

        }


        public void AddEdges(int index)
        {
            visited[index] = true;

            if(myGraph.Graph.ContainsKey(index))
            {
                var edges = myGraph.Graph[index];
                foreach(var edge in edges)
                {
                    if(!visited[edge.To])
                    {
                        pq.Enqueue(edge.Cost, edge);
                    }
                }
            }
        }
    }
}