using System;

namespace DataStructuresAndAlgo.Queue
{
    public class QueueArray
    {
        public static int size = 10;
        public int first;
        public int last;
        public int[] qArray = new int[size];

        public QueueArray()
        {
            first = -1;
            last = -1;
        }

        public void main()
        {
            enqueue(1);
            enqueue(2);
            enqueue(3);
            display();
            dequeue();
            display();
        }

        public void enqueue(int value)
        {
            if(last == size -1)
            {
                Console.WriteLine("Queue is full");
                return;
            }

            last++;
            qArray[last] = value;
        }

        public void dequeue()
        {
            if(first == last)
            {
                Console.WriteLine("Queue is empty");
                return;
            }
            first++;
            Console.WriteLine("Element dequeued is :" + qArray[first]);
        }
    
        public void display()
        {
            Console.WriteLine("=========Display========== [First] " + first + " |[Last] " + last);
            if(first == last)
            {
                Console.WriteLine("Queue is empty");
                return;
            }

            int curr = first + 1;

            while(curr <= last)
            {
                Console.Write(qArray[curr] + "-->");
                curr++;
            }

            Console.Write("null");
            Console.WriteLine();
        }
    }
}