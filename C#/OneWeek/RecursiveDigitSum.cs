namespace HackerRank.OneWeek
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;

    // https://www.hackerrank.com/challenges/one-week-preparation-kit-recursive-digit-sum/problem
    // We have to calculate the super digit at least once (for n), so the large value isn't an issue
    // k can be reduced to 0 <= k <= 9, as multiples of 10 just add unnecessary zeroes
    //
    // When calculating the super digit:
    // - Division is way too slow - better to stick to strings and iterate over the input
    // - By iterating over the input, we can skip 0's as well
    public partial class Result
    {
        /*
         * Complete the 'superDigit' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. STRING n
         *  2. INTEGER k
         */
        public static int superDigit(string n, int k)
        {
            BigInteger superDigit = SuperDigit(n);

            // Find the repeated super digit
            // Multiples of 10 don't matter for k, since they just add unnecessary zeroes
            k %= 10;

            // Only 2 <= k <= 9 changes the input string
            if (k > 1)
            {
                superDigit *= k;
            }

            BigInteger ten = 10;
            while (superDigit > ten)
            {
                superDigit = SuperDigit(superDigit.ToString());
            }

            return (int)superDigit;
        }

        private static BigInteger SuperDigit(string num)
        {
            BigInteger superDigit = BigInteger.Zero;

            foreach (char digit in num)
            {
                if (digit != '0')
                {
                    superDigit += int.Parse(digit.ToString());
                }
            }

            return superDigit;
        }
    }
}
