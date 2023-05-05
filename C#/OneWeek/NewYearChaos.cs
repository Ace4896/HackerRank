namespace HackerRank.OneWeek
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Runtime.ExceptionServices;
    using System.Text;

    // https://www.hackerrank.com/challenges/one-week-preparation-kit-new-year-chaos/problem
    public partial class Result
    {
        /*
         * Complete the 'minimumBribes' function below.
         *
         * The function accepts INTEGER_ARRAY q as parameter.
         */
        public static void minimumBribes(List<int> q)
        {
            // TODO: Come up with new implementation that doesn't time out

            // Overall idea is:
            // - Loop through each queue position
            //   - Check if it's 'Too chaotic' - maximum queue value at any position in this model is original value + 2
            //   - Check how many people this person has bribed - count how many people smaller values are behind them
            //
            // Works, but is too slow due to extra loops for counting the number of bribes made
            const int maxBribes = 2;
            long totalBribes = 0;

            for (int i = 0; i < q.Count - 1; i++)
            {
                int originalQueueValue = i + 1;
                int newQueueValue = q[i];

                if (newQueueValue > originalQueueValue + maxBribes)
                {
                    Console.WriteLine("Too chaotic");
                    return;
                }

                int bribes = 0;
                for (int j = i; j < q.Count; j++)
                {
                    if (newQueueValue > q[j])
                    {
                        bribes++;

                        if (bribes == maxBribes)
                        {
                            break;
                        }
                    }
                }

                totalBribes += bribes;
            }

            Console.WriteLine(totalBribes);
        }
    }
}
