namespace DataStructuresAndAlgo.AVL
{
    public class AVLTree
    {
        public Node rootNode;

        public AVLTree()
        {
            rootNode = null;
        }

        public void main()
        {
            rootNode = RecursiveInsert(rootNode, 10);
            RecursiveInsert(rootNode, 5);
            RecursiveInsert(rootNode, 2);

            return;
        }
        public Node RecursiveInsert(Node root, int value)
        {
            if (root == null)
            {
                Node newNode = new Node(value);
                return newNode;
            }
            else if (value < root.value)
            {
                root.leftChild = RecursiveInsert(root.leftChild, value);
            }
            else
            {
                root.rightChild = RecursiveInsert(root.rightChild, value);
            }

            root.height = NodeHeight(root);

            if (BalanceFactor(root) == 2 && BalanceFactor(root.leftChild) == 1)
            {
                //LL ImBalance - Right rotation (or) LL Rotation (or) Clockwise
                return LLRotation(root);
            }
            else if (BalanceFactor(root) == 2 && BalanceFactor(root.leftChild) == -1)
            {
                //LR Rotation
                return LRRotation(root);
            }
            else if (BalanceFactor(root) == -2 && BalanceFactor(root.rightChild) == -1)
            {
                //RR ImBalance - Left rotation (or) RR Rotation (or) Counter Clockwise
                return RRRotation(root);
            }
            else if (BalanceFactor(root) == -2 && BalanceFactor(root.rightChild) == 1)
            {
                //RL Rotation
                return RLRotation(root);
            }

            return root;
        }
        public int NodeHeight(Node root)
        {
            if (root == null)
            {
                return 0;
            }
            int hl, hr;
            hl = (root != null && root.leftChild != null) ? root.leftChild.height : 0;
            hr = (root != null && root.rightChild != null) ? root.rightChild.height : 0;

            return hl > hr ? hl + 1 : hr + 1;
        }
        public int BalanceFactor(Node root)
        {
            if (root == null)
            {
                return 0;
            }
            int hl, hr;
            hl = (root != null && root.leftChild != null) ? root.leftChild.height : 0;
            hr = (root != null && root.rightChild != null) ? root.rightChild.height : 0;

            return hl - hr;
        }
        public Node LLRotation(Node root)
        {
            Node newRoot = root.leftChild;
            Node newRootRight = newRoot.rightChild;

            newRoot.rightChild = root;
            root.leftChild = newRootRight;

            root.height = NodeHeight(root);
            newRoot.height = NodeHeight(newRoot);

            if (root == rootNode)
            {
                rootNode = newRoot;
            }

            return newRoot;
        }
        public Node LRRotation(Node root)
        {
            Node rootLeft = root.leftChild;
            Node rootLeftRight = rootLeft.rightChild;

            rootLeft.rightChild = rootLeftRight.leftChild;
            root.leftChild = rootLeftRight.rightChild;
            rootLeftRight.rightChild = root;
            rootLeftRight.leftChild = rootLeft;

            rootLeft.height = NodeHeight(rootLeft);
            root.height = NodeHeight(root);
            rootLeftRight.height = NodeHeight(rootLeftRight);

            if (root == rootNode)
            {
                rootNode = rootLeftRight;
            }

            return rootLeftRight;
        }
        public Node RRRotation(Node root)
        {
            Node newRoot = root.rightChild;
            Node newRootLeft = newRoot.leftChild;

            newRoot.leftChild = root;
            root.rightChild = newRootLeft;

            root.height = NodeHeight(root);
            newRoot.height = NodeHeight(newRoot);

            if (root == rootNode)
            {
                rootNode = newRoot;
            }
            return newRoot;
        }
        public Node RLRotation(Node root)
        {
            Node rootRight = root.rightChild;
            Node rootRightLeft = rootRight.leftChild;

            root.rightChild = rootRightLeft.leftChild;
            rootRight.leftChild = rootRightLeft.rightChild;
            rootRightLeft.leftChild = root;
            rootRightLeft.rightChild = rootRight;

            root.height = NodeHeight(root);
            rootRight.height = NodeHeight(rootRight);
            rootRightLeft.height = NodeHeight(rootRightLeft);

            if (root == rootNode)
            {
                rootNode = rootRightLeft;
            }

            return rootRightLeft;
        }

        public Node inOrderPredecessor(Node root)
        {
            if (root == null)
            {
                return null;
            }
            Node prev = null;
            Node curr = root.leftChild;
            while (curr != null)
            {
                prev = curr;
                curr = curr.rightChild;
            }
            return prev;
        }
        public Node inOrderSuccessor(Node root)
        {
            if (root == null)
            {
                return null;
            }
            Node prev = null;
            Node curr = root.rightChild;
            while (curr != null)
            {
                prev = curr;
                curr = curr.leftChild;
            }
            return prev;
        }

        public Node Delete(Node root, int value)
        {
            if (root == null)
            {
                return null;
            }

             if(root.leftChild == null && root.rightChild ==null){
                    if(rootNode==root){
                        rootNode=null;
                    }
                    root = null;
                    return root;
            }

            if (value < root.value)
            {
                root.leftChild = Delete(root.leftChild, value);
            }
            else if (value > root.value)
            {
                root.rightChild = Delete(root.rightChild, value);
            }
            else if(value == root.value){
                if (NodeHeight(root.leftChild) > NodeHeight(root.rightChild)){
                    Node Pred = inOrderPredecessor(root);
                    root.value=Pred.value;
                    root.leftChild = Delete(root.leftChild,Pred.value);
                }else{
                    Node Succ = inOrderSuccessor(root);
                    root.value=Succ.value;
                    root.rightChild = Delete(root.rightChild,Succ.value);
                }
            }

            //Recaulculate height
            root.height= NodeHeight(root);

            //Delete
            if (BalanceFactor(root)==2 && BalanceFactor(root.leftChild)==1){
                //L1 Deletion do LL Rotation(right rotation)
                return LLRotation(root);
            }else if(BalanceFactor(root)==2 && BalanceFactor(root.leftChild)==-1){
                //L-1 Deletion do LR Rotation
                return LRRotation(root);
            }else if(BalanceFactor(root)==2 && BalanceFactor(root.leftChild)==0){ 
                //L0 Deletion do LL or LR rotation
                return LLRotation(root);
            }else if (BalanceFactor(root)==-2 && BalanceFactor(root.rightChild)==-1){
                //R-1 Deletion do RR Rotation(Left rotation)
                return RRRotation(root);
            }else if(BalanceFactor(root)==-2 && BalanceFactor(root.rightChild)==1){
                //R1 Deletion do RL Rotation
                return RLRotation(root);
            }else if(BalanceFactor(root)==-2 && BalanceFactor(root.rightChild)==0){ 
                //R0 Deletion do RR or RL rotation
                return RRRotation(root);
            }

            return root;
        }
    }
}