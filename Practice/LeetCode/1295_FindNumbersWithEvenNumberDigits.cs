namespace DataStructuresAndAlgo.Practice.LeetCode
{
    public class FindNumbersWithEvenNumberDigits
    {
        //https://leetcode.com/problems/find-numbers-with-even-number-of-digits/

        public int FindNumbers(int[] nums)
        {
            int count = 0;

            for(int i = 0; i < nums.Length; i++)
            {
                int num = nums[i];
                int digitCount = 0;
                while(num > 0)
                {
                    num = num/10;
                    digitCount++;
                }

                if(digitCount % 2 == 0)
                {
                    count++;
                }
            }

            return count;
        }


    }
}