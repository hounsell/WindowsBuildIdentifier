using System.Text.RegularExpressions;

namespace WindowsBuildIdentifier
{
    public static class Utilities
    {
        /// <summary>
        /// Converts a 'standard' wildcard file/path specification into a regular expression.
        /// </summary>
        /// <param name="pattern">The wildcard pattern to convert.</param>
        /// <returns>The resultant regular expression.</returns>
        /// <remarks>
        /// The wildcard * (star) matches zero or more characters (including '.'), and ?
        /// (question mark) matches precisely one character (except '.').
        /// </remarks>
        public static Regex ConvertWildcardsToRegEx(string pattern)
        {
            if (pattern == null)
            {
                return new Regex(".*", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
            }

            if (!pattern.Contains("."))
            {
                pattern += ".";
            }

            string query = "^" + Regex.Escape(pattern).Replace(@"\*", ".*").Replace(@"\?", "[^.]") + "$";
            return new Regex(query, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
        }
    }
}
