using System;
using System.Text;

namespace AceLand.Library.Utils
{
    public static partial class Helper
    {
        private const string FULL_CHARACTERS = @"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789`-=[]\;',./~!@#$%^&*()_+{}|:""<>?";
        private const string CHARACTERS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private const string LETTERS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string DIGITS = "0123456789";
        private const char SLASH = '\\';

        public static string GetRandomString(int length, CharacterType type = CharacterType.Characters)
        {
            var rnd = new Random();
            Span<char> newChars = stackalloc char[length];
            for (var i = 0; i < length; i++)
            {
                newChars[i] = type switch
                {
                    CharacterType.FullCharacters => FULL_CHARACTERS[rnd.Next(FULL_CHARACTERS.Length)],
                    CharacterType.Characters => CHARACTERS[rnd.Next(CHARACTERS.Length)],
                    CharacterType.Letters => LETTERS[rnd.Next(LETTERS.Length)],
                    CharacterType.Digits => DIGITS[rnd.Next(DIGITS.Length)],
                    _ => FULL_CHARACTERS[rnd.Next(FULL_CHARACTERS.Length)],
                };
            }
            return new string(newChars);
        }

        public static string Base64Encode(string plainText, Encoding encoding)
        {
            ReadOnlySpan<byte> plainTextBytes = encoding.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes)
                .Replace("/", "-")
                .Replace("+", "_")
                .Replace("=", string.Empty);
        }

        public static string Base64Decode(string base64EncodedData, Encoding encoding)
        {
            ReadOnlySpan<byte> base64EncodedBytes = Convert.FromBase64String(base64EncodedData
                .Replace("-", "/")
                .Replace("_", "+") + "==");
            return encoding.GetString(base64EncodedBytes);
        }

        public static void SplitPathAndFilename(string fullPath, out string path, out string filename)
        {
            filename = fullPath.Split(SLASH)[^1];
            path = fullPath.Replace(filename, "");
        }
    }
}