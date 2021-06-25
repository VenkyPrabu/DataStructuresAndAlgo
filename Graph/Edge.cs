namespace DataStructuresAndAlgo.Graph
{
    public class Edge
    {
        public int From;
        public int To;
        public int Cost;

        public Edge(int from, int to, int cost)
        {
            From = from;
            To = to;
            Cost = cost;
        }
    }
}