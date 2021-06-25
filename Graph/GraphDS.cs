using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgo.Graph
{
    public class GraphDS
    {
        public Dictionary<int, List<Edge>> Graph;

        public GraphDS()
        {
            Graph = new Dictionary<int, List<Edge>>();
        }

        public void AddDirectedEdge(int from, int to, int cost)
        {
            var list = new List<Edge>();
            if (!Graph.ContainsKey(from))
            {
                Graph[from] = list;
            }
            else
            {
                list = Graph[from];
            }
            list.Add(new Edge(from, to, cost));
        }

        public void AddUndirectedEdge(int from, int to, int cost)
        {
            AddDirectedEdge(from, to, cost);
            AddDirectedEdge(to, from, cost);
        }

        public void AddUnWeightedUndirectedEdge(int from, int to)
        {
            AddUndirectedEdge(from, to, 1);
        }

        //DFS Recursive
        public int DFSRecursive(int start, bool[] visited)
        {
            if (visited[start])
            {
                return 0;
            }
            Console.Write(start);
            Console.Write("--->");
            visited[start] = true;
            int count = 1;
            if (Graph.ContainsKey(start))
            {
                var edges = Graph[start];
                foreach (var edge in edges)
                {
                    count += DFSRecursive(edge.To, visited);
                }
            }
            return count;

        }

        //DFS Iterative
        public int DFSIterative(int start, bool[] visited)
        {
            System.Collections.Stack myStack = new System.Collections.Stack();
            int count = 0;

            Console.Write(start);
            Console.Write("--->");
            myStack.Push(start);
            visited[start] = true;

            while (myStack.Count != 0)
            {
                int currKey = (int)myStack.Pop();
                count += 1;
                if (Graph.ContainsKey(currKey))
                {
                    var edges = Graph[currKey];
                    foreach (var edge in edges)
                    {
                        if (!visited[edge.To])
                        {
                            Console.Write(edge.To);
                            Console.Write("--->");
                            myStack.Push(edge.To);
                            visited[edge.To] = true;
                        }
                    }
                }
            }
            return count;

        }

        //BFS Iterative
        public int BFSIterative(int start, bool[] visited)
        {
            System.Collections.Queue myQueue = new System.Collections.Queue();
            int count = 0;

            Console.Write(start);
            Console.Write("--->");
            myQueue.Enqueue(start);
            visited[start] = true;

            while (myQueue.Count != 0)
            {
                int currKey = (int)myQueue.Dequeue();
                count += 1;
                if (Graph.ContainsKey(currKey))
                {
                    var edges = Graph[currKey];
                    foreach (var edge in edges)
                    {
                        if (!visited[edge.To])
                        {
                            Console.Write(edge.To);
                            Console.Write("--->");
                            myQueue.Enqueue(edge.To);
                            visited[edge.To] = true;
                        }
                    }
                }
            }
            return count;

        }

        //BFS Recursive
        public int BFSRecursive(int start, bool[] visited)
        {
            if (visited[start])
            {
                return 0;
            }
            Console.Write(start);
            Console.Write("--->");
            visited[start] = true;
            int count = 1;
            if (Graph.ContainsKey(start))
            {
                var edges = Graph[start];
                foreach (var edge in edges)
                {
                    count += BFSRecursive(edge.To, visited);
                }
            }
            return count;

        }
    }
}