using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgo.Practice.LeetCode
{
    public class OnlineMedian
    {

        public void main()
        {
            var s = new List<int>();
            s.Add(3);
            s.Add(8);
            s.Add(5);
            s.Add(2);

            var r = online_median(s);

        }

        //Brute force 1 Solution
        public static List<int> online_median(List<int> stream)
        {
            List<int> op = new List<int>();
            List<int> ss = new List<int>();

            
            ss.Add(stream[0]);
            op.Add(stream[0]);

            for (int i = 1; i < stream.Count; i++)
            {
                ss.Add(stream[i]);
                ss.Sort();
                int n = ss.Count;
                if (n % 2 == 1)
                {
                    op.Add(ss[(n / 2)]);
                }
                else
                {
                    int a = (ss[n / 2] + ss[(n / 2) - 1]) / 2;
                    op.Add(a);
                }
            }

            return op;
        }

        //Brute force 2 solution (insertion sort) TODO

        //heap solution

        public static List<int> onlineMedianHead(List<int> stream)
        {
            MinHeap rh = new MinHeap();
            MaxHeap lh = new MaxHeap();
            List<int> res = new List<int>();

            foreach(var n in stream)
            {
                if(lh.heap.Count == 0)
                {
                    lh.Add(n);
                    res.Add(n);
                    continue;
                }

                if(n > lh.GetMax())
                {
                    rh.Add(n);
                }
                else
                {
                    lh.Add(n);
                }

                int lc = lh.heap.Count;
                int rc = rh.heap.Count;

                if(lc > rc && lc - rc > 1)
                {
                    int lMax = lh.GetMax();
                    rh.Add(lMax);
                    lh.Poll();
                }
                else if(rc > lc && rc - lc > 1)
                {
                    int rMin = rh.GetMin();
                    lh.Add(rMin);
                    rh.Poll();
                }

                lc = lh.heap.Count;
                rc = rh.heap.Count;

                if(lc == rc)
                {
                    res.Add((lh.GetMax() + rh.GetMin())/2);
                }
                else if( lc > rc)
                {
                    res.Add(lh.GetMax());
                }
                else
                {
                    res.Add(rh.GetMin());
                }
            }

            return res;
        }

        public class MinHeap : Heap<int>
        {
            public override bool Compare(int idx1, int idx2) => heap[idx1] < heap[idx2];
            public int GetMin() => heap[0];
        }
        public class MaxHeap : Heap<int>
        {
            public override bool Compare(int idx1, int idx2) => heap[idx1] > heap[idx2];
            public int GetMax() => heap[0];
        }

        public class Heap<T>
        {
            public List<T> heap = null;

            public Heap()
            {
                heap = new List<T>();
            }

            public void Add(T value)
            {
                heap.Add(value);
                Heapifyup();
            }

            public T Peek()
            {
                if (heap.Count == 0)
                    throw new Exception("The heap is Empty");
                return heap[0];
            }

            public void Poll()
            {
                if (heap.Count == 0)
                    throw new Exception("The heap is Empty");

                var last = heap[heap.Count - 1];
                heap[0] = last;
                heap.RemoveAt(heap.Count - 1);
                HeapifyDown();
            }


            private void Heapifyup()
            {
                int currIdx = heap.Count - 1;

                while (currIdx > 0)
                {
                    int parentIdx = currIdx - 1 / 2;
                    if (Compare(currIdx, parentIdx))
                    {
                        swap(currIdx, parentIdx);
                        currIdx = parentIdx;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            private void HeapifyDown()
            {
                int currIdx = 0;

                while (currIdx < heap.Count - 1)
                {
                    int leftChild = HasLeftChild(currIdx) ? currIdx * 2 + 1 : -1;
                    int rightChild = HasRightChild(currIdx) ? currIdx * 2 + 2 : -1;

                    if (leftChild == -1)
                        break;

                    var compareIdx = leftChild;

                    if (rightChild != -1 && Compare(rightChild, compareIdx))
                        compareIdx = rightChild;

                    if (Compare(compareIdx, currIdx))
                    {
                        swap(compareIdx, currIdx);
                        currIdx = compareIdx;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            private bool HasLeftChild(int idx)
            {
                return idx * 2 + 1 <= heap.Count - 1;
            }

            private bool HasRightChild(int idx)
            {
                return idx * 2 + 2 <= heap.Count - 1;
            }


            public virtual bool Compare(int idx1, int idx2)
            {
                int first = Convert.ToInt32(heap[idx1]);
                int second = Convert.ToInt32(heap[idx2]);
                return first < second;
            }

            private void swap(int idx1, int idx2)
            {
                var x = heap[idx1];
                heap[idx1] = heap[idx2];
                heap[idx2] = x;
            }


        }


    }
}