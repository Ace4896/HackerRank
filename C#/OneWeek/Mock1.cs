namespace HackerRank.OneWeek
{
    using System.Collections.Generic;
    using System.Linq;

    // Mock Test 1 - 10mins Available
    // - O(n log n) Runtime - Due to sorting
    // - O(n) Space - Due to intermediate sorted array. Could sort in place, but we were given a list, which could be used elsewhere.
    public partial class Result
    {
        /*
         * Complete the 'findMedian' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts INTEGER_ARRAY arr as parameter.
         */
        public static int findMedian(List<int> arr)
        {
            // Sort array first
            List<int> sorted = arr.OrderBy(i => i).ToList();

            // Constraint indicates that there's always an odd number of values
            // So can just use the middle element
            // -1 because it's 0-based
            int middleIndex = (sorted.Count + 1) / 2 - 1;
            return sorted[middleIndex];
        }
    }
}
