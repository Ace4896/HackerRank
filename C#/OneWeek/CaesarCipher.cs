namespace HackerRank.OneWeek
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    // https://www.hackerrank.com/challenges/one-week-preparation-kit-caesar-cipher-1/problem
    public partial class Result
    {
        /*
         * Complete the 'caesarCipher' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts following parameters:
         *  1. STRING s
         *  2. INTEGER k
         */
        public static string caesarCipher(string s, int k)
        {
            const int lowercaseZ = (int)'z';
            const int uppercaseZ = (int)'Z';

            StringBuilder sb = new StringBuilder(s.Length);

            foreach (char c in s)
            {
                if (!char.IsAscii(c) || !char.IsLetter(c))
                {
                    sb.Append(c);
                }
                else
                {
                    int newValue = (int)c + (k % 26);
                    if ((char.IsLower(c) && newValue > lowercaseZ) ||
                        (char.IsUpper(c) && newValue > uppercaseZ))
                    {
                        newValue -= 26;
                    }

                    sb.Append((char)newValue);
                }
            }

            return sb.ToString();
        }
    }
}
