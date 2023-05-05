namespace HackerRank.OneWeek
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    // https://www.hackerrank.com/challenges/one-week-preparation-kit-grid-challenge/problem
    // There's no algorithm trick for this, as we have to sort the rows
    // But we can reduce the number of sorts and checks by going row-by-row
    public partial class Result
    {
        /*
         * Complete the 'gridChallenge' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts STRING_ARRAY grid as parameter.
         */
        public static string gridChallenge(List<string> grid)
        {
            List<char[]> rows = new List<char[]>(grid.Count)
        {
            SortRow(grid[0]),
        };

            for (int row = 1; row < grid.Count; row++)
            {
                char[] currentRow = SortRow(grid[row]);
                char[] lastRow = rows[row - 1];

                for (int i = 0; i < currentRow.Length; i++)
                {
                    if (currentRow[i] < lastRow[i])
                    {
                        return "NO";
                    }
                }

                rows.Add(currentRow);
            }

            return "YES";
        }

        private static char[] SortRow(string input)
        {
            return input.OrderBy(c => c).ToArray();
        }
    }
}
