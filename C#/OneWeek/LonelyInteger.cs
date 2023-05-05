namespace HackerRank.OneWeek
{
    using System;
    using System.Collections.Generic;

    // https://www.hackerrank.com/challenges/one-week-preparation-kit-lonely-integer/problem
    public partial class Result
    {
        /*
         * Complete the 'lonelyinteger' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts INTEGER_ARRAY a as parameter.
         */
        public static int lonelyinteger(List<int> a)
        {
            Dictionary<int, int> numberCount = new Dictionary<int, int>();

            // Count occurrences of each number in a
            foreach (int num in a)
            {
                if (numberCount.TryGetValue(num, out int count))
                {
                    numberCount[num] = count + 1;
                }
                else
                {
                    numberCount[num] = 1;
                }
            }

            // Find the one that occurred once
            foreach (KeyValuePair<int, int> kvp in numberCount)
            {
                if (kvp.Value == 1)
                {
                    return kvp.Key;
                }
            }

            throw new ArgumentException("a doesn't contain an element that only appears once");
        }
    }
}
