namespace AceLand.Library.Editor.InspectorButton.Utils
{
    using System;

    internal static class StringExtensions
    {
        public static string CapitalizeFirstChar(this string input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            char _firstChar = input[0];

            if (char.IsUpper(_firstChar))
                return input;

            var _chars = input.ToCharArray();
            _chars[0] = char.ToUpper(_firstChar);
            return new string(_chars);
        }
    }
}