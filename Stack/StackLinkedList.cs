using System;
using System.Collections.Generic;
using DataStructuresAndAlgo.LinkedList;

namespace DataStructuresAndAlgo.Stack
{
    public class NodeChar 
    {
        public char value;
        public NodeChar next;

        public NodeChar(char c)
        {
            value = c;
            next = null;
        }

    }

    //todo: Infix to Postfix 
    
    public class StackLinkedList
    {
        public NodeChar top;

        public StackLinkedList()
        {
            top = null;
        }
        
        public void main()
        {
            // push('a');
            // push('b');
            // push('c');
            // push('d');
            // push('e');
            // Display();
            // pop();
            // peek(1);
            // Display();
            // peek(3);
            // peekTop();
            Console.WriteLine(isBracketsBalance("()"));
            Console.WriteLine(isBracketsBalance("({}[])"));
            Console.WriteLine(isBracketsBalance("{}()[]"));
            Console.WriteLine(isBracketsBalance("{[()]}"));
            Console.WriteLine(isBracketsBalance("{[({{{]})})]}"));
            Console.WriteLine(isBracketsBalance("{([a+b]}*[c-d])/e}"));

            
        }

        public void push(char value)
        {
            NodeChar newNode = new NodeChar(value);
            if(top == null)
            {
                top = newNode;
                return;
            }

            newNode.next = top;
            top = newNode;
        }

        public void pop()
        {
            if(top == null)
            {
                Console.WriteLine("Stack is empty");
                return;
            }

            NodeChar curr = top;
            Console.WriteLine("Poped element is :" + curr.value);
            top = curr.next;
            curr = null;
        }

        public void peek(int pos)
        {
            if(top == null)
            {
                Console.WriteLine("Stack is empty");
                return;
            }

            NodeChar curr = top;

            for(int i = 0; i < pos - 1 && curr != null; i++)
            {
                curr = curr.next;
            }

            if(curr != null)
            {
                Console.WriteLine("The element at position {0} is {1}", pos, curr.value);
                return;
            }

            Console.WriteLine("Invalid position");

        }

        public void Display()
        {
            if(top == null)
            {
                Console.WriteLine("No elements in Stack to DISPLAY");
                return;
            }

            Console.WriteLine("========DISPLAY========");
            NodeChar curr = top;

            while(curr != null)
            {
                Console.WriteLine(curr.value);
                curr = curr.next;
            }
        }

        public void peekTop()
        {
            if(top == null)
            {
                Console.WriteLine("Stack is empty");
                return;
            }

            Console.WriteLine("The element at top is :"+ top.value);
        }

        public bool isBracketsBalance(string exp)
        {
            //TODO : https://leetcode.com/problems/valid-parentheses/
            Dictionary<char,char> brackets = new Dictionary<char, char>();
            brackets.Add(')','(');
            brackets.Add('}','{');
            brackets.Add(']','[');
            
            var expArray = exp.ToCharArray();

            Stack<char> st = new Stack<char>();

            foreach(char c in expArray)
            {
                if(brackets.ContainsValue(c))
                {
                    st.Push(c);
                }
                else if(brackets.ContainsKey(c) && (st.Count == 0 || st.Pop() != brackets[c]))
                {
                   return false;
                }
            }

            return st.Count == 0;

        }
    }
}