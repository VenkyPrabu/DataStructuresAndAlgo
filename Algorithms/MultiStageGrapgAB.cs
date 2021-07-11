using System;

namespace DataStructuresAndAlgo.Algorithms
{
    public class MultiStageGrapgAB
    {
        //https://www.youtube.com/watch?v=FcScLYJI42E&list=PLDN4rrl48XKpZkf03iYFl-O29szjTrs_O&index=48&ab_channel=AbdulBari

        public void main()
        {
            int stages = 5;
            int vertices = 12;
            int[,] graph = new int[13, 13]{
                {0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,9,7,3,2,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,4,2,1,0,0,0,0},
                {0,0,0,0,0,0,2,7,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,11,0,0,0,0},
                {0,0,0,0,0,0,0,11,8,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,6,5,0,0},
                {0,0,0,0,0,0,0,0,0,4,3,0,0},
                {0,0,0,0,0,0,0,0,0,0,5,6,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,4},
                {0,0,0,0,0,0,0,0,0,0,0,0,2},
                {0,0,0,0,0,0,0,0,0,0,0,0,5},
                {0,0,0,0,0,0,0,0,0,0,0,0,0}
            };

            int[] cost = new int[vertices + 1];
            int[] distance = new int[vertices + 1];
            int[] path = new int[vertices + 1];
            cost[vertices] = 0;
            distance[vertices] = vertices;

            for (int i = vertices - 1; i >= 1; i--)
            {
                int min = int.MaxValue;
                for (int k = i + 1; k <= vertices; k++)
                {
                    if(graph[i,k] != 0 && graph[i,k] + cost[k] < min)
                    {
                        min = graph[i,k] + cost[k];
                        distance[i] = k;
                    }
                }

                cost[i] = min;
            }
            path[1] = 1;
            path[stages] = vertices;

            for(int i = 2; i < stages; i++)
            {
                path[i] = distance[path[i-1]];
            }

            for(int i = 1; i <=stages; i++)
            {
                Console.Write(path[i] + "-->");
            }
        }
    }
}