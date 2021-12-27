using System;

namespace DataStructuresAndAlgo.Practice.LeetCode
{
    public static class AddStrings
    {
        public static string Add2String(string num1, string num2)
        {
        int carry = 0;
        char[] sum = new char[Math.Max(num1.Length,num2.Length) + 1];
        
        int p1 = num1.Length -1;
        int p2 = num2.Length -1;
        int position = 0;
        
        while(p1 >= 0 || p2 >=0)
        {
            int x1 = p1 >=0 ? num1[p1] -'0' : 0;
            int x2 = p2 >=0 ? num2[p2] -'0' : 0;
            
            int val = (x1 + x2 + carry) % 10;
            carry = (x1 + x2 + carry) / 10;
            sum[sum.Length-1 - position++] = (char)val;
            p1--;
            p2--;
            
        }
        
        if(carry != 0)
            sum[0] = (char)carry;
        
        return sum.ToString();
        }
        
    }
}