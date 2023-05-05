namespace HackerRank.OneWeek
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // Mock Test 3 - 22mins Available
    // O(n^2) Runtime - Ended up checking all indexes in the string...
    // O(n) Space - Have to copy to intermediate arrays each time...
    //
    // Couldn't immediately see a fast solution... this timed out in several tests and returned the wrong answer in others.
    public partial class Result
    {
        /*
         * Complete the 'palindromeIndex' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts STRING s as parameter.
         */
        //public static int palindromeIndex(string s)
        //{
        //    // Check if it's already a palindrome; return -1 in this scenario
        //    if (IsPalindrome(s.ToCharArray()))
        //    {
        //        return -1;
        //    }

        //    for (int indexToSkip = 0; indexToSkip < s.Length; indexToSkip++)
        //    {
        //        char[] modifiedChars = new char[s.Length - 1];

        //        for (int index = 0; index < s.Length; index++)
        //        {
        //            if (index < indexToSkip)
        //            {
        //                modifiedChars[index] = s[index];
        //            }
        //            else if (index > indexToSkip)
        //            {
        //                modifiedChars[index - 1] = s[index];
        //            }
        //        }

        //        if (IsPalindrome(modifiedChars))
        //        {
        //            return indexToSkip;
        //        }
        //    }

        //    return -1;
        //}

        //private static bool IsPalindrome(char[] chars)
        //{
        //    for (int start = 0; start < chars.Length / 2; start++)
        //    {
        //        // NOTE: -1 for 0-based indexing
        //        int end = chars.Length - start - 1;

        //        if (chars[start] != chars[end])
        //        {
        //            return false;
        //        }
        //    }

        //    return true;
        //}
    }
}
