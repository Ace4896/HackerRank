namespace HackerRank.OneWeek
{
    using System;
    using System.Text.RegularExpressions;

    // https://www.hackerrank.com/challenges/one-week-preparation-kit-time-conversion/problem
    // I spent a lot of time on this, because:
    // - I didn't realise that the 0th group was the input string; useful groups only start from index 1
    // - ValueSpan comparison for AM was failing
    public partial class Result
    {
        /*
         * Complete the 'timeConversion' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts STRING s as parameter.
         */
        public static string timeConversion(string s)
        {
            // Use regex to capture each part of the input string
            // Technically, we don't need validation, as constraints state that all inputs are valid
            Regex inputRegex = new Regex(@"^(\d\d):(\d\d):(\d\d)(AM|PM)$");
            Match match = inputRegex.Match(s);

            if (!match.Success)
            {
                throw new FormatException("Input string is not a valid AM/PM time");
            }

            // NOTE: Group 0 = input string
            // The useful groups start at index 1
            GroupCollection groups = match.Groups;
            int hours = int.Parse(groups[1].Value);
            string mins = groups[2].Value;
            string secs = groups[3].Value;
            string timeOfDay = groups[4].Value;

            // Handle cases where hours needs adjusting
            // AM - Check for 12:00:00AM -> 00:00:00
            // PM - Add 12 hours (unless it's 12:00:00PM -> 12:00:00)
            if (timeOfDay == "AM" && hours == 12)
            {
                hours = 0;
            }
            else if (timeOfDay == "PM" && hours != 12)
            {
                hours += 12;
            }

            return $"{hours:D2}:{mins}:{secs}";
        }
    }
}
