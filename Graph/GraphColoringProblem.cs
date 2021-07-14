using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgo.Graph
{
    public class GraphColoringProblem
    {
        //TODO : https://www.youtube.com/watch?v=0ACfAqs8mm0&ab_channel=TECHDOSE
        //https://leetcode.com/problems/possible-bipartition/

        public void main()
        {
            int[][] dislikes = new int[3][];
            
            // [[1,2],[1,3],[2,4]];
            dislikes[0] = new int[2] {1,2};
            dislikes[1] = new int[2] {1,3};
            dislikes[2] = new int[2] {2,4};

            Console.WriteLine(isBipartite(4,dislikes));
            
        }


        public bool isBipartite(int N, int[][] dislikes)
        {
            if (dislikes == null || dislikes.Length == 0)
                return true;

            //populate dislikes of each node
            var dislikeGraph = new Dictionary<int, List<int>>();
            for (int i = 1; i <= N; i++)
            {
                dislikeGraph.Add(i, new List<int>());
            }

            foreach (var dislike in dislikes)
            {
                int one = dislike[0];
                int two = dislike[1];

                dislikeGraph[one].Add(two);
                dislikeGraph[two].Add(one);
            }

            //colors are in bool (T/F)
            var coloring = new Dictionary<int, bool>();
            for (int i = 1; i <= N; i++)
            {
                if (!coloring.ContainsKey(i))
                {
                    bool success = AssignColorFrom(i, dislikeGraph, coloring);
                    if (!success) return false;
                }
            }

            return true;
        }


        public bool AssignColorFrom(int startNode, Dictionary<int, List<int>> dislikeGraph, Dictionary<int, bool> colorAssigned)
        {
            var q = new Queue<int>();
            q.Enqueue(startNode);
            int itemInLevel = 1;
            bool color = true;

            while (q.Count > 0)
            {
                int node = q.Dequeue();
                colorAssigned[node] = color;
                itemInLevel--;

                foreach (int dislike in dislikeGraph[node])
                {
                    if (!colorAssigned.ContainsKey(dislike))
                    {
                        q.Enqueue(dislike);
                    }
                    else if (colorAssigned[dislike] == colorAssigned[node])
                    {
                        return false;
                    }
                }

                if (itemInLevel == 0)
                {
                    itemInLevel = q.Count;
                    color = !color;
                }
            }

            return true;
        }
    }
}