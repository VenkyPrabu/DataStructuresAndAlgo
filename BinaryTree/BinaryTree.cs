using System;

namespace DataStructuresAndAlgo.BinaryTree
{
    public class BinaryTree
    {
        public Node rootNode;
        public System.Collections.Queue queue;

        public BinaryTree()
        {
            rootNode = null;
            queue = new System.Collections.Queue();
        }

        public void main()
        {
            Create();
            Console.Write("PreOrder:");
            PreOrder(rootNode);
            Console.WriteLine();

            Console.Write("PreOrderIterative:");
            PreOrderIterative(rootNode);
            Console.WriteLine();

            // Console.Write("InOrder:");
            // InOrder(rootNode);
            // Console.WriteLine();
            // Console.Write("PostOrder:");
            // PostOrder(rootNode);
            // Console.WriteLine();

            Console.Write("LevelOrder:");
            LevelOrder(rootNode);
            Console.WriteLine();

            Console.WriteLine("Total No of Nodes :" + Count(rootNode));
            Console.WriteLine("Total No of Leaf Nodes :" + CountLeaf(rootNode));
            Console.WriteLine("Height :" + Height(rootNode));
            

        }

        public void Create()
        {
            Console.WriteLine("Enter the root node");
            int value = Convert.ToInt32(Console.ReadLine());
            rootNode = new Node(value);
            queue.Enqueue(rootNode);

            while (queue.Count != 0)
            {
                Node currParent = (Node)queue.Dequeue();

                Console.WriteLine("Enter the left node for Parent:" + currParent.value);
                int lvalue = Convert.ToInt32(Console.ReadLine());
                if (lvalue != -1)
                {
                    Node lNode = new Node(lvalue);
                    currParent.leftChild = lNode;
                    queue.Enqueue(lNode);
                }

                Console.WriteLine("Enter the right node for Parent:" + currParent.value);
                int rvalue = Convert.ToInt32(Console.ReadLine());
                if (rvalue != -1)
                {
                    Node rNode = new Node(rvalue);
                    currParent.rightChild = rNode;
                    queue.Enqueue(rNode);
                }
            }
        }

        public void PreOrder(Node root)
        {
            if (root != null)
            {
                Console.Write(root.value);
                PreOrder(root.leftChild);
                PreOrder(root.rightChild);
            }
        }

        public void InOrder(Node root)
        {
            if (root != null)
            {
                InOrder(root.leftChild);
                Console.Write(root.value);
                InOrder(root.rightChild);

            }
        }

        public void PostOrder(Node root) 
        {
            if (root != null)
            {
                PostOrder(root.leftChild);
                PostOrder(root.rightChild);
                Console.Write(root.value);
            }
        }

        public void PreOrderIterative(Node root)
        {
            System.Collections.Stack stack = new System.Collections.Stack();
            while (root != null || stack.Count != 0)
            {
                if (root != null)
                {
                    Console.Write(root.value);
                    stack.Push(root);
                    root = root.leftChild;
                }
                else
                {
                    root = (Node)stack.Pop();
                    root = root.rightChild;
                }
            }
        }

        public void InOrderIterative(Node root)
        {
            System.Collections.Stack stack = new System.Collections.Stack();
            while (root != null || stack.Count != 0)
            {
                if (root != null)
                {
                    stack.Push(root);
                    root = root.leftChild;
                }
                else
                {
                    root = (Node)stack.Pop();
                    Console.Write(root.value);
                    root = root.rightChild;
                }
            }
        }

        public void PostOrderIterative(Node root)
        {

        }

        public void LevelOrder(Node root)
        {
            if (root == null)
                return;

            System.Collections.Queue queue = new System.Collections.Queue();
            Console.Write(root.value);
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                Node curr = (Node)queue.Dequeue();

                if(curr.leftChild != null)
                {
                    Console.Write(curr.leftChild.value);
                    queue.Enqueue(curr.leftChild);
                }

                if(curr.rightChild != null)
                {
                    Console.Write(curr.rightChild.value);
                    queue.Enqueue(curr.rightChild);
                }

            }

        }
    
        public int Count(Node root)
        {
            int x, y;
            if(root!= null)
            {
                x = Count(root.leftChild);
                y = Count(root.rightChild);
                return x + y + 1;
            }
            return 0;
        }

        public int CountLeaf(Node root)
        {
            int x, y;
            if(root!= null)
            {
                x = CountLeaf(root.leftChild);
                y = CountLeaf(root.rightChild);

                if(root.leftChild == null && root.rightChild == null)
                {
                    return x + y + 1;
                }
                else
                {
                    return x + y;
                }
            }
            return 0;
        }

        public int CountNonLeaf(Node root)
        {
            int x, y;
            if(root!= null)
            {
                x = CountNonLeaf(root.leftChild);
                y = CountNonLeaf(root.rightChild);

                if(root.leftChild == null || root.rightChild == null)
                {
                    return x + y + 1;
                }
                else
                {
                    return x + y;
                }
            }
            return 0;
        }
    
        public int Height(Node root){
            if(root == null){
                return 0;
            }
            int x= Height(root.leftChild);
            int y= Height(root.rightChild);
            if (x >y){
                return x+1;
            }else{
                return y+1;
            }         
        }
    }
}