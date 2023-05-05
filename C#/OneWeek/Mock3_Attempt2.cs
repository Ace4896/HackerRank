namespace HackerRank.OneWeek
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // Mock Test 3 - 22mins Available
    // O(n) Runtime - Maximum number of times we need to loop is < 3n
    // O(n) Space - Only have to store the original string
    //
    // Idea is that we check either end of the string to see if the values match
    // If they match, then we move to the next two inner characters and repeat the check
    // As soon as we find non-matching characters, see if we get a palindrome after removing either of them
    public partial class Result
    {
        /*
         * Complete the 'palindromeIndex' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts STRING s as parameter.
         */
        public static int palindromeIndex(string s)
        {
            int nonMatchingStart = -1;
            int nonMatchingEnd = -1;

            int start = 0;
            int end = s.Length - 1;

            while (start < end)
            {
                if (s[start] != s[end])
                {
                    nonMatchingStart = start;
                    nonMatchingEnd = end;
                    break;
                }

                start++;
                end--;
            }

            // If we manage to get through the entire loop without a mismatched character, it's a palindrome already
            if (nonMatchingStart == -1 || nonMatchingEnd == -1)
            {
                return -1;
            }

            // See if it's a palindrome if we remove the starting character
            start = nonMatchingStart + 1;
            end = nonMatchingEnd;

            while (start < end)
            {
                if (s[start] != s[end])
                {
                    break;
                }

                start++;
                end--;
            }

            // If this loop completed fully, then we have a palindrome after removing the starting character
            if (start >= end)
            {
                return nonMatchingStart;
            }

            // Otherwise, see if it's a palindrome if we remove the ending character
            start = nonMatchingStart;
            end = nonMatchingEnd - 1;

            while (start < end)
            {
                if (s[start] != s[end])
                {
                    break;
                }

                start++;
                end--;
            }
            
            // Again, if this loop completed fully, then we have a palindrome after removing the ending character
            if (start >= end)
            {
                return nonMatchingEnd;
            }

            // Otherwise, we can't get a palindrome by removing 1 character
            return -1;
        }
    }
}
