using System;
using System.Collections.Generic;

namespace FashionApp_Business_Logic
{
    public static class UserInputHelper
    {
        // Validates if a value is within the specified range
        public static bool IsValidChoice(int value, int minValue, int maxValue)
        {
            return value >= minValue && value <= maxValue;
        }

        // Attempts to parse a string to an integer and validates it's within range
        public static bool TryParseChoice(string input, int minValue, int maxValue, out int result)
        {
            if (int.TryParse(input, out result))
            {
                return IsValidChoice(result, minValue, maxValue);
            }
            result = 0;
            return false;
        }

        // Validate string input is not empty
        public static bool IsValidString(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }
    }
}