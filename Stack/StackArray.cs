using System;

namespace DataStructuresAndAlgo.Stack
{
    public class StackArray
    {
        public static int size = 10;
        public int top;
        public int[] array;

        public StackArray()
        {
            top = -1;
            array = new int[size];
        }

        public void main()
        {
            push(1);
            push(2);
            push(3);
            push(4);
            display();
            pop();
            display();
            peek(-1);
            peekTop();
        }

        public void push(int value)
        {
            if(isFull())
            {   
                Console.WriteLine("Stack is full");
                return;
            }

            array[++top] = value;
        }

        public void pop()
        {
            if(isEmpty())
            {
                Console.WriteLine("No elements in Stack");
                return;
            }

            Console.WriteLine("Poped element is :" + array[top]);
            array[top] = -1;
            top--;
        }

        public void peek(int pos)
        {
            if(top - pos +1 < 0 || pos <= 0)
            {
                Console.WriteLine("Invalid position");
                return;
            }

            Console.WriteLine("The element at position {0} is {1}", pos, array[top - pos + 1]);
        }

        public void peekTop()
        {
            if(isEmpty())
            {
                Console.WriteLine("No elements in Stack");
                return;
            }

            Console.WriteLine("The top element is : " + array[top]);
        }
        public void display()
        {
            Console.WriteLine("=========Display========");
            if(isEmpty())
            {
                Console.WriteLine("No elements to display");
                return;
            }
            
            int x = top;
            while(x > -1)
            {
                Console.WriteLine(array[x]);
                x--;
            }
        }

        public bool isEmpty()
        {
            if(top == -1)
                return true;

            return false;
        }

        public bool isFull()
        {
            if(top  == size - 1)
                return true;

            return false;
        }
    }
}