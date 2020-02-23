using System;

namespace CashlessRegistration.Shared
{
    /// <summary>
    /// General extentions to string
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Convert a string to a integer array
        /// 
        /// Complexity:
        ///     O(n) - "n" is source.Length
        /// </summary>
        /// <param name="source">source string</param>
        /// <returns>A integer array</returns>
        /// <exception cref="ArgumentNullException">source string is null or empty</exception>
        /// <exception cref="ArgumentException">source string does not contains only digits</exception>
        public static int[] ToIntArray(this string source)
        {
            if (string.IsNullOrWhiteSpace(source))
                throw new ArgumentNullException(nameof(source));

            var result = new int[source.Length];

            for (var i = 0; i <= source.Length-1; i++)
            {
                if (!char.IsDigit(source[i]))
                    throw new ArgumentException("source should contains only digits", nameof(source));

                result[i] = Convert.ToInt32(source[i].ToString());
            }

            return result;
        }
    }
}