// <copyright file="NumberParser.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Text.RegularExpressions;

namespace Task2
{
    /// <summary>
    /// Parse numbers of type string to Int32.
    /// </summary>
    public class NumberParser : INumberParser
    {
        /// <summary>
        /// Parse string value to integer value.
        /// </summary>
        /// <param name="stringValue">String value to be parsed into integer.</param>
        /// <returns>Return integer value of the given string value.</returns>
        /// <exception cref="ArgumentNullException">Throws ArgumentNullException if the string value is null.</exception>
        /// <exception cref="FormatException">Throws FormatException if the stringValue is not in valid format.</exception>
        /// <exception cref="OverflowException">Throws OverflowException if the string value is bigger than the max value and smaller than the min value.</exception>
        public int Parse(string stringValue)
        {
            // Null check
            if (stringValue is null)
            {
                throw new ArgumentNullException($"{nameof(stringValue)} is null.");
            }

            // Format - Empty checks
            stringValue = stringValue.Trim();
            if (stringValue == string.Empty)
            {
                throw new FormatException($"{nameof(stringValue)} is empty.");
            }

            int result = 0;
            int index = 0;
            int sign = 1;

            // Get sign
            if (stringValue[0] == '-')
            {
                index++;
                sign = -1;
            }
            else if (stringValue[0] == '+')
            {
                index++;
            }

            // Parse
            // ASCII -> 0 = 48, 9 = 57, " " = 32
            for (; index < stringValue.Length; index++)
            {
                char digit = stringValue[index];

                // (digit >= 48 && digit <= 57)
                if (digit >= '0' && digit <= '9')
                {
                    int number = digit - '0'; // digit - 48;
                    int tempResult = result * sign;
                    if (tempResult > int.MaxValue / 10 || (tempResult == int.MaxValue / 10 && number > int.MaxValue % 10) ||
                        tempResult < int.MinValue / 10 || (tempResult == int.MinValue / 10 && number * sign < int.MinValue % 10))
                    {
                        throw new OverflowException($"Input out of range of Int32. The value should be between '{int.MinValue}' and '{int.MaxValue}'.");
                    }

                    result = (result * 10) + number;
                }
                else
                {
                    throw new FormatException("Input contains non-digit characters.");
                }
            }

            return result * sign;
        }

        /// <summary>
        /// Parse string value to integer value. Checks format by using Regex.
        /// </summary>
        /// <param name="stringValue">String value to be parsed into integer.</param>
        /// <returns>Return integer value of the given string value.</returns>
        /// <exception cref="ArgumentNullException">Throws ArgumentNullException if the string value is null.</exception>
        /// <exception cref="FormatException">Throws FormatException if the stringValue is not in valid format.</exception>
        /// <exception cref="OverflowException">Throws OverflowException if the string value is bigger than the max value and smaller than the min value.</exception>
        public int Parse2(string stringValue)
        {
            // Null check
            if (stringValue is null)
            {
                throw new ArgumentNullException($"{nameof(stringValue)} can't be null.");
            }

            // Format check
            stringValue = stringValue.Trim();

            /* ^[-+]?[0-9]\\d*(\\.\\d+)?$
             * (?) Can be
             * (^[-+]) start with '- or +'
             * ([0-9]) Contains number between 0 and 9
             * \\d any digit character same as [0-9]
             * d+ any number of digits
             * $ ends with
            */
            var regex = new Regex("^[-+]?\\d+$");
            if (!regex.IsMatch(stringValue))
            {
                throw new FormatException("Input format is not valid.");
            }

            // Parse
            int result = 0;
            int index = 0;
            int sign = 1;

            if (stringValue.StartsWith('-'))
            {
                index++;
                sign = -1;
            }
            else if (stringValue.StartsWith("+"))
            {
                index++;
            }

            for (; index < stringValue.Length; index++)
            {
                // ASCII 0 = 48 , 9 = 57
                var digit = stringValue[index] - 48; // stringValue - '0'

                // Range check
                var tempResult = result * sign;
                if (tempResult > int.MaxValue / 10 || (tempResult == int.MaxValue / 10 && digit > int.MaxValue % 10) ||
                    tempResult < int.MinValue / 10 || (tempResult == int.MinValue / 10 && digit * sign < int.MinValue % 10))
                {
                    throw new OverflowException($"Input out of range. The value should be between '{int.MinValue}' and '{int.MaxValue}'.");
                }

                result = (result * 10) + digit; // If calculated result exceeds the Int32 range, it assigns int.MinValue.
            }

            return result * sign;
        }
    }
}