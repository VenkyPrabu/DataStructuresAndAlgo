namespace DataStructuresAndAlgo.Graph
{
    public class RootingTree : GraphDS
    {

        public void main(){
        GraphDS myGraph = new GraphDS();
        myGraph.AddUnWeightedUndirectedEdge(0,1);
        myGraph.AddUnWeightedUndirectedEdge(2,1);
        myGraph.AddUnWeightedUndirectedEdge(2,3);
        myGraph.AddUnWeightedUndirectedEdge(3,4);
        myGraph.AddUnWeightedUndirectedEdge(5,3);
        myGraph.AddUnWeightedUndirectedEdge(2,6);
        myGraph.AddUnWeightedUndirectedEdge(6,7);
        myGraph.AddUnWeightedUndirectedEdge(6,8);
        // Rooted at 6 the tree should look like:
        //           6
        //      2    7     8
        //    1   3
        //  0    4 5
        TreeNode root = new TreeNode(6);
        root = root.BuildTree(myGraph.Graph, root);

        // Rooted at 3 the tree should look like:
        //               3
        //     2         4        5
        //  6     1
        // 7 8    0
        TreeNode root1 = new TreeNode(3);
        root1 =root1.BuildTree(myGraph.Graph, root1);
        //TO DO - Not printing the values - Checing the result using debugger

        }
    }
}