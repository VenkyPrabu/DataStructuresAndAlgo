namespace DataStructuresAndAlgo.BinaryTree
{
    public class Node
    {
        public int value;
        public Node leftChild;
        public Node rightChild;
        public Node(int value){
            this.value = value;            
            this.leftChild = null;
            this.rightChild = null;
        }
    }
}