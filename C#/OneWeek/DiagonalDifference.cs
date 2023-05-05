namespace HackerRank.OneWeek
{
    using System;
    using System.Collections.Generic;

    // https://www.hackerrank.com/challenges/one-week-preparation-kit-diagonal-difference/problem
    // Can be done in a single loop actually, but this is more readable
    public partial class Result
    {
        /*
         * Complete the 'diagonalDifference' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts 2D_INTEGER_ARRAY arr as parameter.
         */
        public static int diagonalDifference(List<List<int>> arr)
        {
            // Input is always a square matrix
            int size = arr.Count;

            // Primary diagonal is top left -> bottom right
            // (0, 0) -> (size - 1, size - 1)
            int primaryDiagonal = 0;
            for (int n = 0; n < size; n++)
            {
                primaryDiagonal += arr[n][n];
            }

            // Secondary diagonal is bottom left -> top right,
            // (0, size - 1) -> (size - 1, 0)
            int secondaryDiagonal = 0;
            for (int col = 0; col < size; col++)
            {
                int row = size - col - 1;
                secondaryDiagonal += arr[row][col];
            }

            // Calculate absolute difference
            return Math.Abs(primaryDiagonal - secondaryDiagonal);
        }
    }
}
