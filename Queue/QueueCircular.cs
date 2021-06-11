using System;

namespace DataStructuresAndAlgo.Queue
{
    public class QueueCircular
    {
        public static int size = 5;
        public int first;
        public int last;
        public int[] qArray = new int[size];

        public QueueCircular()
        {
            first = 0;
            last = 0;
        }


        public void main()
        {
            enqueue(1);
            enqueue(2);
            enqueue(3);
            display();
            dequeue();
            display();
            enqueue(4);
            dequeue();
            display();
            enqueue(5);
            display();
            enqueue(6);
            display();
            dequeue();
            display();
        }

        public void enqueue(int value)
        {
            if ((last + 1) % size == first)
            {
                Console.WriteLine("Queue is full");
                return;
            }

            last = (last + 1) % size;
            qArray[last] = value;
        }

        public void dequeue()
        {
            if (first == last)
            {
                Console.WriteLine("Queue is empty");
                return;
            }
            first = (first + 1) % size;
            Console.WriteLine("Dequeued element is :" + qArray[first]);
            qArray[first] = -100;

        }

        public void display()
        {
            Console.WriteLine("=========Display========== [First] " + first + " |[Last] " + last);
            if (first == last)
            {
                Console.WriteLine("Queue is empty");
                return;
            }

            int curr = (first + 1) % size;

            if (last > first)
            {
                while (curr <= last)
                {
                    Console.Write(qArray[curr] + "-->");
                    curr++;
                }
            }
            else
            {
                for(int i = curr; i < size ; i++)
                {
                    Console.Write(qArray[i] + "-->");
                }

                for(int i = 0; i <= last; i++)
                {
                    Console.Write(qArray[i] + "-->");
                }
            }

            Console.Write("null");
            Console.WriteLine();

        }
    }
}