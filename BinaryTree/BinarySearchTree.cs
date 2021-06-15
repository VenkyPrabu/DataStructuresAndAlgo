using System;

namespace DataStructuresAndAlgo.BinaryTree
{
    public class BinarySearchTree
    {

        public Node rootNode;

        public BinarySearchTree()
        {
            rootNode = null;
        }

        //1. Search Iterative
        //2. Search Recursion
        //3. Insert Iterative
        //4. Insert Recursion
        //5. Inorder Traversal
        //6. Inorder Predecessor
        //7. Inorder Successor
        //8. Delete Recursive
        //9. Height
        //10. 

        //To DO :
        //1. Delete Recursive (Redo)
        //2. Create from Pre Order (Done) - Post Order
        //3. AB - Quiz
        public void main()
        {
            // rootNode = RecursiveInsert(rootNode, 10);
            // IterativeInsert(5);
            // RecursiveInsert(rootNode, 20);
            // RecursiveInsert(rootNode, 8);
            // RecursiveInsert(rootNode, 30);


            // InOrder(rootNode);
            // Console.WriteLine();
            // // RSearch(rootNode, 22);
            // // IterativeSearch(22);
            // // IterativeSearch(20);

            // Delete(rootNode, 20);

            CreateBSTFromPreOrder(new int[]{ 30,20,10,15,40}); //,50,45
            InOrder(rootNode);
        }

        public void RSearch(Node root, int value)
        {
            if (root == null)
            {
                Console.WriteLine("ELement Not Found");
                return;
            }

            if (value == root.value)
            {
                Console.WriteLine("Found the value :" + value);
                return;
            }
            else if (value < root.value)
            {
                RSearch(root.leftChild, value);
            }
            else
            {
                RSearch(root.rightChild, value);
            }
        }

        public void IterativeSearch(int value)
        {
            Node curr = rootNode;

            while (curr != null)
            {
                if (curr.value == value)
                {
                    Console.WriteLine("Found the value :" + value);
                    return;
                }
                else if (value < curr.value)
                {
                    curr = curr.leftChild;
                }
                else
                {
                    curr = curr.rightChild;
                }
            }

            Console.WriteLine("value NOT Found :" + value);
        }

        public void IterativeInsert(int value)
        {
            Node newNode = new Node(value);
            if (rootNode == null)
            {
                rootNode = newNode;
                return;
            }
            Node prev = null;
            Node curr = rootNode;

            while (curr != null)
            {
                prev = curr;
                if (value == curr.value)
                {
                    return;
                }
                else if (value < curr.value)
                {
                    curr = curr.leftChild;
                }
                else
                {
                    curr = curr.rightChild;
                }
            }


            if (newNode.value < prev.value)
            {
                prev.leftChild = newNode;
            }
            else
            {
                prev.rightChild = newNode;
            }
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
            return root;
        }

        public void InOrder(Node root)
        {
            if (root != null)
            {
                InOrder(root.leftChild);
                Console.Write(root.value + ",");
                InOrder(root.rightChild);
            }
        }

        public Node Delete(Node root, int value)
        {
            if (root == null)
            {
                return null;
            }
            if (root.rightChild == null && root.leftChild == null)
            {
                if (root == rootNode)
                {
                    rootNode = null;
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
            else
            {
                if (Height(root.leftChild) > Height(root.rightChild))
                {
                    Node q = InOrderPredecesor(root.leftChild);
                    root.value = q.value;
                    root.leftChild = Delete(root.leftChild, q.value);
                }
                else
                {
                    Node q = InOrderSuccessor(root.rightChild);
                    root.value = q.value;
                    root.rightChild = Delete(root.rightChild, q.value);
                }
            }
            return root;
        }


        public int Height(Node root)
        {
            if (root == null)
            {
                return 0;
            }
            int x, y;
            x = Height(root.leftChild);
            y = Height(root.rightChild);
            return x > y ? x + 1 : y + 1;
        }
        public Node InOrderPredecesor(Node root)
        {
            while (root != null && root.rightChild != null)
            {
                root = root.rightChild;
            }
            return root;
        }

        public Node InOrderSuccessor(Node root)
        {
            while (root != null && root.leftChild != null)
            {
                root = root.leftChild;
            }
            return root;
        }

        public void CreateBSTFromPreOrder(int[] preOrder)
        {
            System.Collections.Stack st = new System.Collections.Stack();
            Node curr;
            Node temp;
            int i = 0;
            rootNode = new Node(preOrder[i++]);
            curr = rootNode;

            while (i < preOrder.Length)
            {
                if (preOrder[i] < curr.value)
                {
                    temp = new Node(preOrder[i++]);
                    curr.leftChild = temp;
                    st.Push(curr);
                    curr = temp;
                }
                else
                {
                    if (preOrder[i] > curr.value &&  preOrder[i] <  ((st.Count == 0) ? int.MaxValue :  ((Node)st.Peek()).value))
                    {
                        temp = new Node(preOrder[i++]);
                        curr.rightChild = temp;
                        curr = temp;
                    }
                    else
                    {
                        curr = (Node)st.Pop();
                    }


                }
            }

        }


    }
}