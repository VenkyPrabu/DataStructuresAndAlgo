namespace DataStructuresAndAlgo.Practice.LeetCode
{
    public static class OutputContestMatches
    {
        public static string findContestMatch(int n)
        {
            string[] m = new string[n];
            for(int i = 0; i < n ;i++)
            {
                m[i] = (i+1).ToString();
            }

            while(n > 1)
            {
                for(int i = 0; i < n /2; i++)
                {
                    m[i] = "(" + m[i] + "," + m[n -1 - i] + ")";
                }
                n /= 2;
            }

            return m[0];
        }
    }
}