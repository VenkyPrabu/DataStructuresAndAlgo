namespace DataStructuresAndAlgo.AVL
{
    public class Node
    {
        public int value;
        public int height;

        public Node leftChild;
        public Node rightChild;
        public Node(int value)
        {
            this.value = value;
            this.height = 1;
        }
    }
}