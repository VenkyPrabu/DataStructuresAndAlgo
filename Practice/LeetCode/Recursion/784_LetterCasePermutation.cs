using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgo.Practice.LeetCode.Recursion
{
    public class LetterCasePermutation
    {
        //https://leetcode.com/problems/letter-case-permutation/

        public void main()
        {
            string input = "a1z";

            LCP(input);
        }

        public List<string> results = new List<string>();

        public void LCP(string input)
        {
            StringBuilder slate = new StringBuilder();
            helper(input, 0, slate);
            //helperChar(input, 0, new char[input.Length]);
        }

        public void helper(string input, int idx, StringBuilder slate)
        {
            //dynamically building the char array (stringBuilder)
            //if anything is appended to the shared resource (slate)
            //the same thing has to be removed before going into another call of helper function
            //
            if (idx >= input.Length)
            {
                results.Add(slate.ToString());
                Console.WriteLine(slate.ToString());
                return;
            }

            if (Char.IsLetter(input[idx]))
            {
                slate.Append(Char.ToLower(input[idx]));
                helper(input, idx + 1, slate);
                slate.Remove(slate.Length - 1, 1);

                slate.Append(Char.ToUpper(input[idx]));
                helper(input, idx + 1, slate);
                slate.Remove(slate.Length - 1, 1);
            }
            else
            {
                slate.Append(input[idx]);
                helper(input, idx + 1, slate);
                slate.Remove(slate.Length - 1, 1);
            }
        }

        public void helperChar(string input, int idx, char[] slate)
        {
            if (input.Length == idx)
            {
                results.Add(string.Join("", slate));
                Console.WriteLine(string.Join("", slate));
                return;
            }

            char ch = input[idx];

            if (Char.IsLetter(ch))
            {
                slate[idx] = Char.ToLower(ch);
                helperChar(input, idx + 1, slate);
                slate[idx] = Char.ToUpper(ch);
                helperChar(input, idx + 1, slate);
            }
            else
            {
                slate[idx] = ch;
                helperChar(input, idx + 1, slate);

            }
        }

    }
}