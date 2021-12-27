using System;

namespace DataStructuresAndAlgo.Practice.LeetCode
{
    public static class MaximumLengthofRepeatedSubarray
    {
        public static int maxSubArray(int[] A, int[] B)
        {
            int result = 0;
            for (int i = 0; i < A.Length + B.Length - 1; ++i) {
                // The current overlapping window is A[aStart, Math.min(A.Length, B.Length)] and B[bStart, Math.min(A.Length, B.Length)].
                int aStart = Math.Max(0, A.Length - 1 - i);  
                int bStart = Math.Max(0, i - (A.Length - 1));
                int numConsecutiveMatches = 0;
                for (int aIdx = aStart, bIdx = bStart; aIdx < A.Length && bIdx < B.Length; ++aIdx, ++bIdx) {
                    // Maintain number of equal consecutive elements in the current window (overlap) and the max number ever computed.
                    numConsecutiveMatches = A[aIdx] == B[bIdx] ? numConsecutiveMatches + 1 : 0;
                    result = Math.Max(result, numConsecutiveMatches);
                }
            }
            return result;

        }
    }
}