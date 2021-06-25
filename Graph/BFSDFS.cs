using System;

namespace DataStructuresAndAlgo.Graph
{
    public class BFSDFS
    {
        //TODO
        //1. Prims
        //2. Kruskals
        int[] visitedD = new int[7]{0,0,0,0,0,0,0};
        public void main()
        {
            int[,] G = new int[7,7]{    {0,0,0,0,0,0,0},
                                        {0,0,1,1,0,0,0},
                                        {0,1,0,0,1,0,0},
                                        {0,1,0,0,1,0,0},
                                        {0,0,1,1,0,1,1},
                                        {0,0,0,0,1,0,0},
                                        {0,0,0,0,1,0,0}
                                    }; 

            //BFSearch(G,1,7);
            DFSearch(G,4,7);
        }

        public void BFSearch(int[,] G,int start, int n)
        {
            int i = start;
            System.Collections.Queue q = new System.Collections.Queue();
            int[] visited = new int[7]{0,0,0,0,0,0,0};

            Console.Write(i + " ");
            visited[i] = 1;
            q.Enqueue(i);

            while(q.Count != 0)
            {
                i = (int)q.Dequeue();
                for(int j = 1; j<n;j++)
                {   
                    if(G[i,j]==1 && visited[j] ==0)
                    {
                        Console.Write(j + " ");
                        visited[j] = 1;
                        q.Enqueue(j);
                    }
                }
            }

        }
    
        public void DFSearch(int[,] G,int start, int n)
        {
            if(visitedD[start] == 0)
            {
                Console.Write(start + " ");
                visitedD[start] = 1;
                for(int j = 1; j <n;j++)
                {
                    if(G[start,j] ==1 && visitedD[j]==0)
                    {
                        DFSearch(G,j,n);
                    }
                }
            }
        }
    }
}