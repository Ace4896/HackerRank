namespace HackerRank.OneWeek
{
    using System;
    using System.Collections.Generic;

    // https://www.hackerrank.com/challenges/one-week-preparation-kit-balanced-brackets/problem
    public partial class Result
    {
        /*
         * Complete the 'isBalanced' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts STRING s as parameter.
         */
        public static string isBalanced(string s)
        {
            Stack<char> openBrackets = new Stack<char>();
            char openBracket;

            foreach (char bracket in s)
            {
                switch (bracket)
                {
                    case '(':
                    case '[':
                    case '{':
                        openBrackets.Push(bracket);
                        break;

                    case ')':
                        if (!openBrackets.TryPop(out openBracket) || openBracket != '(')
                        {
                            return "NO";
                        }

                        break;

                    case ']':
                        if (!openBrackets.TryPop(out openBracket) || openBracket != '[')
                        {
                            return "NO";
                        }

                        break;

                    case '}':
                        if (!openBrackets.TryPop(out openBracket) || openBracket != '{')
                        {
                            return "NO";
                        }

                        break;
                }
            }

            return openBrackets.Count == 0 ? "YES" : "NO";
        }
    }
}
