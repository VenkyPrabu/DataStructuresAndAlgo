using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgo.Practice.LeetCode.Recursion
{
    public class PalindromeOfGivenString
    {
        public void main()
        {
            //abracadabra
            generate_palindromic_decompositions("abracad");
        }

        public static string[] generate_palindromic_decompositions(string s)
        {
            List<string> result = new List<string>();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            palindromeHelper(s, sb, 0, result);
            return result.ToArray();
        }

        public static void palindromeHelper(string s, System.Text.StringBuilder sb, int index, List<string> collection)
        {
            if (index == s.Length)
            {
                Console.WriteLine(sb.ToString());
                collection.Add(sb.ToString());
            }

            for (int i = index; i < s.Length; i++)
            {
                string temp = s.Substring(index, i - index + 1);

                if (IsPalindrome(temp))
                {
                    if (index == 0)
                    {
                        sb.Append(temp);
                        palindromeHelper(s, sb, i + 1, collection);
                        sb.Length = sb.Length - temp.Length;
                    }
                    else
                    {
                        sb.Append("|");
                        sb.Append(temp);
                        palindromeHelper(s, sb, i + 1, collection);
                        sb.Length = sb.Length - temp.Length - 1;
                    }
                }
            }
        }

        public static bool IsPalindrome(string currStr)
        {
            if (currStr.Length == 1) { return true; }
            int l = 0;
            int r = currStr.Length - 1;
            while (l < r)
            {
                if (currStr[l] != currStr[r]) return false;
                l++;
                r--;
            }
            return true;
        }
    }
}