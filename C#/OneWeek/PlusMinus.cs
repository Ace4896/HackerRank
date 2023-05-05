namespace HackerRank.OneWeek
{
    using System;
    using System.Collections.Generic;

    // https://www.hackerrank.com/challenges/one-week-preparation-kit-plus-minus/problem
    public partial class Result
    {
        /*
         * Complete the 'plusMinus' function below.
         *
         * The function accepts INTEGER_ARRAY arr as parameter.
         */
        public static void plusMinus(List<int> arr)
        {
            // Count number of positive, negative and zero numbers
            int positive = 0;
            int negative = 0;
            int zero = 0;

            foreach (int value in arr)
            {
                if (value > 0)
                {
                    positive++;
                }
                else if (value < 0)
                {
                    negative++;
                }
                else
                {
                    zero++;
                }
            }

            // Calculate the ratio of each number
            int total = positive + negative + zero;
            decimal positiveRatio = (decimal)positive / total;
            decimal negativeRatio = (decimal)negative / total;
            decimal zeroRatio = (decimal)zero / total;

            // Print out positive, negative and zero in this order
            Console.WriteLine($"{positiveRatio:F6}");
            Console.WriteLine($"{negativeRatio:F6}");
            Console.WriteLine($"{zeroRatio:F6}");
        }
    }
}
