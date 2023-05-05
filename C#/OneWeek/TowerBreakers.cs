namespace HackerRank.OneWeek
{
    using System;
    using System.Collections.Generic;

    // https://www.hackerrank.com/challenges/one-week-preparation-kit-tower-breakers-1/problem
    // I managed to guess this solution LOL
    // The winner is based on the number of moves available to each player
    //
    // If there's an even number of towers, P2 can always make a move that leaves an odd number of moves for P1
    // If there's an odd number of towers, P1 can always make a move that leaves an even number of moves for P2
    //
    // In either case, the player stuck with the odd/even difference between moves and towers ends up with all towers at height 1
    public partial class Result
    {
        /*
         * Complete the 'towerBreakers' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER n
         *  2. INTEGER m
         */
        public static int towerBreakers(int n, int m)
        {
            // Base Case: If initial number of towers is 1, then P1 automatically wins
            if (n == 1)
            {
                return 1;
            }

            // Base Case: If initial height of all towers is 1, then P2 automatically wins
            if (m == 1)
            {
                return 2;
            }

            // Pretty sure that if both are playing optimally, the winner is determined right from the beginning
            // If there's an even number of towers, P2 wins, as P1 is eventually left with all towers at height 1
            // If there's an odd number of towers, P1 wins, as P2 is eventually left with all towers at height 1
            return n % 2 == 0 ? 2 : 1;
        }
    }
}
