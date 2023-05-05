namespace HackerRank.OneWeek
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // Mock Test 5 - 25mins Available
    // O(n log n) Runtime - Need to sort values
    // O(n) Space - Only need to store original array (assuming in-place sort)
    //
    // Originally thought that a HashSet implementation was viable, but realised that it doesn't work when a number is used in multiple pairs
    // So decided to use this sorting-based approach, which is still decently fast
    public partial class Result
    {
        /*
         * Complete the 'pairs' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER k
         *  2. INTEGER_ARRAY arr
         */
        public static int pairs(int k, List<int> arr)
        {
            // Sort the array in ascending order
            arr.Sort();

            // Then scan the array for pairs
            int pairs = 0;
            int first = 0;
            int second = 1;

            while (second < arr.Count)
            {
                int diff = arr[second] - arr[first];

                if (diff == k)
                {
                    // Found a pair
                    pairs++;
                    first++;
                    second = first + 1;
                }
                else if (diff < k)
                {
                    // Not a pair, increase the second value to hopefully find one
                    second++;
                }
                else if (diff > k)
                {
                    // Not a pair, diff is already too large, so need to get next first value
                    first++;
                    second = first + 1;
                }
            }

            return pairs;
        }
    }
}
