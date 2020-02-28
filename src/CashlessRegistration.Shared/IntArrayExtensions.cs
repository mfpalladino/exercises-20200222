using System;
using System.Text;

namespace CashlessRegistration.Shared
{
    /// <summary>
    /// General extentions of arrays of int.
    /// </summary>
    public static class IntArrayExtensions
    {
        /// <summary>
        /// Execute a certain number of rotations to the right based on source array and eturns a NEW array
        /// rotated.
        /// 
        /// Complexity:
        ///     O(k*n) - "k" is numberOfRotations and "n" is source.Length
        /// </summary>
        /// <param name="source">Source array that must be rotated</param>
        /// <param name="numberOfRotations">Number of rotations that must be do</param>
        /// <returns>A new int[] that represents the rotated array</returns>
        /// <exception cref="ArgumentNullException">source is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">source.Length is less than 2</exception>
        /// <exception cref="ArgumentOutOfRangeException">numberOfRotations is less than or equal 0</exception>
        public static int[] RotateToRight(this int[] source, int numberOfRotations)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (source.Length < 2)
                throw new ArgumentOutOfRangeException(nameof(source), "must have at least two elements");

            if (numberOfRotations <= 0)
                throw new ArgumentOutOfRangeException(nameof(numberOfRotations), "must be greather than zero");

            var clonedSource = (int[])source.Clone();

            for (var currentRotation = 0; currentRotation < numberOfRotations; currentRotation++)
            {
                for (var sourceIndex = clonedSource.Length - 1; sourceIndex > 0; sourceIndex--)
                {
                    var leftElementIndex = sourceIndex - 1;
                    var rightElementIndex = sourceIndex;

                    var leftElementValue = clonedSource[leftElementIndex];
                    var rightElementValue = clonedSource[rightElementIndex];

                    clonedSource[leftElementIndex] = rightElementValue;
                    clonedSource[rightElementIndex] = leftElementValue;
                }
            }

            return clonedSource;
        }

        /// <summary>
        /// Find the array such that the absolute difference between any two of the chosen integers
        /// is less than or equal to a certain number.
        /// 
        /// Complexity:
        ///     O(n*n) - "n" is source.Length
        /// </summary>
        /// <param name="source">Source array</param>
        /// <param name="absoluteDifference">absoluteDifference that must be used to find the new array</param>
        /// <returns>A new int[] with only numbers that the absolute difference to any other number is less than or equal <code>absoluteDifference</code></returns>
        /// <exception cref="ArgumentNullException">source is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">source.Length is less than 2</exception>
        /// <exception cref="ArgumentOutOfRangeException">absoluteDifference is less than 0</exception>
        public static int[] FindByAbsoluteDifference(this int[] source, int absoluteDifference)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (source.Length < 2)
                throw new ArgumentOutOfRangeException(nameof(source), "must have at least two elements");

            if (absoluteDifference < 0)
                throw new ArgumentOutOfRangeException(nameof(absoluteDifference), "it must be greather than or equal zero");

            Array.Sort(source);

            var lastRightIndex = source.Length - 1;

            for (var currentLeftIndex = 0; currentLeftIndex < source.Length - 1; currentLeftIndex++)
            {
                for (var currentRightIndex = lastRightIndex; currentRightIndex >= 0; currentRightIndex--)
                {
                    var leftValue = source[currentLeftIndex];
                    var rightValue = source[currentRightIndex];

                    if (rightValue > leftValue && rightValue - leftValue > absoluteDifference)
                        lastRightIndex--;
                }
            }

            var result = new int[lastRightIndex + 1];
            for (var i = 0; i <= lastRightIndex; i++)
                result[i] = source[i];

            return result;
        }

        /// <summary>
        /// Convert a array of int to a long number
        /// </summary>
        /// <param name="source">array of int</param>
        /// <returns>Long number</returns>
        /// <exception cref="ArgumentNullException">source is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">source.Length is 0</exception>
        public static long ToLong(this int[] source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (source.Length == 0)
                throw new ArgumentOutOfRangeException(nameof(source), "must have at least one elements");

            var sb = new StringBuilder(source.Length);

            foreach (var c in source)
                sb.Append(c.ToString());

            return Convert.ToInt64(sb.ToString());
        }
    }
}
