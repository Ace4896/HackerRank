namespace HackerRank.OneWeek
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // Mock Test 2 - 24mins Available
    // O(n^2) Runtime - Need to process n^2 elements
    // O(n) Space - Only need space for the input array and intermediate sums
    public partial class Result
    {
        /*
         * Complete the 'flippingMatrix' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts 2D_INTEGER_ARRAY matrix as parameter.
         */
        public static int flippingMatrix(List<List<int>> matrix)
        {
            // To get the maximum quadrant values, we need to know the maximum possible values in each quadrant square
            // With an infinite number of moves, it's possible to move all the maximum values for each quadrant square to the upper left quadrant
            //
            // In a 4x4 matrix:
            //
            // 1 5 9 4
            // 2 6 1 5
            // 3 7 2 6
            // 4 8 3 7
            //
            // We're looking for:
            //
            // a b ? ?
            // c d ? ?
            // ? ? ? ?
            // ? ? ? ?
            //
            // By mirroring the indexes, we can find the maximum value
            //
            // a = max(1, 4, 4, 7) = 7
            // b = max(5, 9, 8, 3) = 9
            // c = max(2, 5, 3, 6) = 6
            // d = max(6, 1, 7, 2) = 7
            //
            // Maximal Sum = 7 + 9 + 6 + 7 = 29

            // Deterimine n, the size of the quadrant
            int fullSize = matrix.Count;
            int quadrantSize = matrix.Count / 2;

            // Base case: n = 1
            // Means we just need the maximum value in the matrix
            if (quadrantSize == 1)
            {
                return matrix.SelectMany(col => col).Max();
            }

            // Main case
            // Determine the maximum values for each quadrant square
            int sum = 0;
            for (int row = 0; row < quadrantSize; row++)
            {
                for (int col = 0; col < quadrantSize; col++)
                {
                    int topLeft = matrix[row][col];
                    int topRight = matrix[row][fullSize - col - 1];
                    int bottomLeft = matrix[fullSize - row - 1][col];
                    int bottomRight = matrix[fullSize - row - 1][fullSize - col - 1];

                    int max = Math.Max(topLeft, Math.Max(topRight, Math.Max(bottomLeft, bottomRight)));
                    sum += max;
                }
            }

            return sum;
        }
    }
}
