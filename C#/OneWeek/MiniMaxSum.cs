namespace HackerRank.OneWeek
{
    using System;
    using System.Collections.Generic;

    // https://www.hackerrank.com/challenges/one-week-preparation-kit-mini-max-sum/problem
    public partial class Result
    {
        /*
         * Complete the 'miniMaxSum' function below.
         *
         * The function accepts INTEGER_ARRAY arr as parameter.
         */
        public static void miniMaxSum(List<int> arr)
        {
            // Find the indexes of the minimum and maximum values in the array
            int min = arr[0];
            int max = arr[0];

            int minIndex = 0;
            int maxIndex = 0;

            for (int i = 1; i < arr.Count; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                    minIndex = i;
                }
                else if (arr[i] > max)
                {
                    max = arr[i];
                    maxIndex = i;
                }
            }

            // Calculate the smallest and largest sums
            // Smallest sum skips the largest value
            // Largest sum skips the smallest value
            long smallestSum = 0;
            long largestSum = 0;

            for (int i = 0; i < arr.Count; i++)
            {
                if (i != minIndex)
                {
                    largestSum += arr[i];
                }

                if (i != maxIndex)
                {
                    smallestSum += arr[i];
                }
            }

            // Output the smallest and largest sum in this order
            Console.WriteLine($"{smallestSum} {largestSum}");
        }
    }
}
