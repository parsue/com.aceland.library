#nullable enable
using System;
using System.Text;
#if UNITY_6000_5_OR_NEWER
using Unity.Scripting.LifecycleManagement;
#endif

namespace AceLand.Library.Utils
{
    public sealed class StringHelper : IDisposable
    {
        public static StringHelper Get()
        {
            _instance ??= new StringHelper();
            return _instance;
        }
        
#if UNITY_6000_5_OR_NEWER
        [AutoStaticsCleanup]
#endif
        private static StringHelper? _instance;

        private StringHelper() { }
        ~StringHelper() => Dispose();

        public void Dispose()
        {
            _key = null;
            _iv = null;
            _instance = null;
        }
        
        private const string FULL_CHARACTERS = @"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789`-=[]\;',./~!@#$%^&*()_+{}|:""<>?";
        private const string CHARACTERS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private const string LETTERS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string DIGITS = "0123456789";

        private byte[]? _key;
        private byte[]? _iv;

        public string GetRandomString(int length, CharacterType type = CharacterType.Characters)
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

        public string Base64Encode(string plainText, Encoding encoding)
        {
            ReadOnlySpan<byte> plainTextBytes = encoding.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes)
                .Replace("/", "-")
                .Replace("+", "_")
                .Replace("=", string.Empty);
        }

        public string Base64Decode(string base64EncodedData, Encoding encoding)
        {
            ReadOnlySpan<byte> base64EncodedBytes = Convert.FromBase64String(base64EncodedData
                .Replace("-", "/")
                .Replace("_", "+") + "==");
            return encoding.GetString(base64EncodedBytes);
        }
    }
}