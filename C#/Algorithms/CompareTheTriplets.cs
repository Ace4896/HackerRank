namespace HackerRank.Algorithms
{
    using System.Collections.Generic;
    using System.Linq;

    // https://www.hackerrank.com/challenges/compare-the-triplets/problem
    public partial class Result
    {
        /*
         * Complete the 'compareTriplets' function below.
         *
         * The function is expected to return an INTEGER_ARRAY.
         * The function accepts following parameters:
         *  1. INTEGER_ARRAY a
         *  2. INTEGER_ARRAY b
         */
        public static List<int> compareTriplets(List<int> a, List<int> b)
        {
            List<int> points = new() { 0, 0 };

            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] > b[i])
                {
                    points[0]++;
                }
                else if (b[i] > a[i])
                {
                    points[1]++;
                }
            }

            return points;
        }
    }
}
