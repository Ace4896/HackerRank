namespace HackerRank.OneWeek
{
    using System.Collections.Generic;
    using System.Linq;

    // https://www.hackerrank.com/challenges/one-week-preparation-kit-countingsort1/problem
    public partial class Result
    {
        /*
         * Complete the 'countingSort' function below.
         *
         * The function is expected to return an INTEGER_ARRAY.
         * The function accepts INTEGER_ARRAY arr as parameter.
         */
        public static List<int> countingSort(List<int> arr)
        {
            // 0 <= arr[i] < 100
            // So we can just use the numbers as the index and the value stored as the count
            List<int> frequency = Enumerable.Repeat(0, 100).ToList();

            foreach (int num in arr)
            {
                frequency[num]++;
            }

            return frequency;
        }
    }
}
