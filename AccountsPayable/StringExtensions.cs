using System.Text.RegularExpressions;

namespace AccountsPayable
{
    public static class StringExtensions
    {
        public static bool Matches (this string val, string regex)
        {
            return Regex.IsMatch(val, regex);

        }
    }
}