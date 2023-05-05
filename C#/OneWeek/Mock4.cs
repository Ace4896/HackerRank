namespace HackerRank.OneWeek
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // Mock Test 4 - 33mins Available
    // O(n^2) Runtime - Worst case is that we have to check all N starting points
    // O(n) Space - Only have to store the original list
    //
    // This doesn't timeout, but an O(n) solution is possible:
    //
    // startingPump = 0
    // cumulativePetrol = 0
    // cumulativeDistance = 0
    // for i in 0..n-1:
    //     cumulativePetrol += pumps[i][0]
    //     cumulativeDistance += pumps[i][1]
    //     if (cumulativePetrol < cumulativeDistance)   # Can't use current starting pump
    //         cumulativePetrol = 0
    //         cumulativeDistance = 0
    //         startingPump = i + 1                     # Start on the pump after this one
    //
    // The reasoning is that if we realise that starting at a particular pump doesn't work, then we can't use any pump along this sequence either
    // This is because we'll have less fuel than the cumulative sum we arrived with, since we've removed stations that would've increased total fuel
    public partial class Result
    {
        /*
         * Complete the 'truckTour' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts 2D_INTEGER_ARRAY petrolpumps as parameter.
         */
        public static int truckTour(List<List<int>> petrolpumps)
        {
            for (int startingPoint = 0; startingPoint < petrolpumps.Count;  startingPoint++)
            {
                List<int> startingPump = petrolpumps[startingPoint];
                int remainingPetrol = startingPump[0] - startingPump[1];

                if (remainingPetrol < 0)
                {
                    // This starting point isn't usable
                    continue;
                }

                // Check pumps along the circular path
                for (int currentPoint = (startingPoint + 1) % petrolpumps.Count;
                     currentPoint != startingPoint;
                     currentPoint = (currentPoint + 1) % petrolpumps.Count)
                {
                    List<int> currentPump = petrolpumps[currentPoint];
                    remainingPetrol += currentPump[0] - currentPump[1];

                    if (remainingPetrol < 0)
                    {
                        break;
                    }
                }

                // If we managed to finish the entire tour, then we can use this starting point
                if (remainingPetrol > 0)
                {
                    return startingPoint;
                }
            }

            throw new ArgumentException("No possible starting point");
        }
    }
}
