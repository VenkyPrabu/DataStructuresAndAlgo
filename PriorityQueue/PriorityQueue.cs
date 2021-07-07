using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgo.PriorityQueue
{
    public class PriorityQueue<T>
    {
        public class Node
        {
            public int Priority { get; set; }
            public T Object { get; set; }
        }

        public List<Node> queue = new List<Node>();
        public int heapSize = -1;
        public bool isMinHeap = false;
        public int Count { get { return queue.Count; } }

        public PriorityQueue(bool isMinPriorityQueue = false)
        {
            isMinHeap = isMinPriorityQueue;
        }

        public void Enqueue(int priority, T obj)
        {
            Node newNode = new Node() { Object = obj, Priority = priority };
            queue.Add(newNode);
            heapSize++;

            if (isMinHeap)
            {
                MinHeapifyBottomToTop(heapSize);
            }
            else
            {
                MaxHeapifyBottomToTop(heapSize);
            }
        }

        public void MinHeapifyBottomToTop(int index)
        {
            if (index < 1)
            {
                return;
            }

            int parent = GetParent(index);

            if (queue[index].Priority < queue[parent].Priority)
            {
                Swap(index, parent);
                MinHeapifyBottomToTop(parent);
            }
        }

        public void MaxHeapifyBottomToTop(int index)
        {
            if (index < 1)
            {
                return;
            }

            int parent = GetParent(index);

            if (queue[index].Priority > queue[parent].Priority)
            {
                Swap(index, parent);
                MaxHeapifyBottomToTop(parent);
            }
        }

        public T Dequeue()
        {
            var returnObj = queue[0];

            queue[0] = queue[heapSize];
            queue.RemoveAt(heapSize);
            heapSize--;

            if (isMinHeap)
            {
                MinHeapifyTopToBottom(0);
            }
            else
            {
                MaxHeapifyTopToBottom(0);
            }

            return returnObj.Object;
        }

        public void MinHeapifyTopToBottom(int index)
        {
            int left = GetLeftChild(index);
            int right = GetRighChild(index);

            int smallest = 0;

            if (left > heapSize)
            {
                return;
            }

            if (left == heapSize)
            {
                //if only had left child
                if (queue[left].Priority < queue[index].Priority)
                {
                    Swap(index, left);
                    return;
                }
            }
            else
            {
                //has two childs
                //if both child are there
                smallest = queue[left].Priority < queue[right].Priority ? left : right;
                if (queue[smallest].Priority < queue[index].Priority)
                {
                    Swap(index, smallest);
                    MinHeapifyTopToBottom(smallest);
                }
            }
        }

        public void MaxHeapifyTopToBottom(int index)
        {
            int left = GetLeftChild(index);
            int right = GetRighChild(index);

            int largest = 0;

            if (left > heapSize)
            {
                return;
            }

            if (left == heapSize)
            {
                //if only had left child
                if (queue[left].Priority > queue[index].Priority)
                {
                    Swap(index, left);
                    return;
                }
            }
            else
            {
                //has two childs
                //if both child are there
                largest = queue[left].Priority > queue[right].Priority ? left : right;
                if (queue[largest].Priority > queue[index].Priority)
                {
                    Swap(index, largest);
                    MaxHeapifyTopToBottom(largest);
                }
            }
        }

        public void Swap(int i, int j)
        {
            Node temp = queue[i];
            queue[i] = queue[j];
            queue[j] = temp;
        }

        public int GetParent(int index)
        {
            return (index - 1) / 2;
        }

        public int GetLeftChild(int index)
        {
            return 2 * index + 1;
        }

        public int GetRighChild(int index)
        {
            return 2 * index + 2;
        }

        public void main()
        {
            PriorityQueue<int> pq = new PriorityQueue<int>(true);
            pq.Enqueue(10, 10);
            pq.Enqueue(20, 20);
            pq.Enqueue(15, 15);
            pq.Enqueue(30, 30);
            pq.Enqueue(40, 40);
            pq.Enqueue(5, 5);
            pq.Enqueue(60, 60);
            Console.WriteLine(pq.Dequeue());

        }
    }
}