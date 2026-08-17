#nullable enable
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using AceLand.Library.Modules;
using AceLand.Lifecycle;

namespace AceLand.Library.Utils
{
    public interface IStringHelper
    {
        string GetRandomString(int length, CharacterType type = CharacterType.Characters);
        string Base64Encode(string plainText, Encoding encoding);
        string Base64Decode(string base64EncodedData, Encoding encoding);
        string Encrypt(string plainText);
        string? Decrypt(object? encrypted);
    }
    
    public sealed class StringHelper : IStringHelper, IDisposable
    {
        internal StringHelper()
        {
            Disposable = ModuleRegistry.WhenReady<ALibSettingsModule>(m =>
            {
                var settings = m.Settings;
            
                key = Encoding.UTF8.GetBytes(settings.Key);
                iv = Encoding.UTF8.GetBytes(settings.IV);
            });
        }

        public void Dispose()
        {
            Disposable?.Dispose();
        }
        
        private const string FULL_CHARACTERS = @"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789`-=[]\;',./~!@#$%^&*()_+{}|:""<>?";
        private const string CHARACTERS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private const string LETTERS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string DIGITS = "0123456789";

        private IDisposable Disposable { get; }
        
        private byte[] key = Array.Empty<byte>();
        private byte[] iv = Array.Empty<byte>();

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
        
        public string Encrypt(string value)
        {
            using var aes = Aes.Create();
        
            aes.Key = key;
            aes.IV = iv;
        
            var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
        
            using var ms = new MemoryStream();
            using var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
            using (var sw = new StreamWriter(cs))
            {
                sw.Write(value);
            }
                
            return Convert.ToBase64String(ms.ToArray());
        }
        
        public string? Decrypt(object? encrypted)
        {
            if (encrypted == null) return null;
        
            var encryptedText = encrypted switch
            {
                byte[] bytes => Encoding.UTF8.GetString(bytes),
                string text => text,
                _ => null
            };
            if (string.IsNullOrEmpty(encryptedText)) return null;
        
            try
            {
                var cipherBytes = Convert.FromBase64String(encryptedText);
                using var aes = Aes.Create();
            
                aes.Key = key;
                aes.IV = iv;
                var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
        
                using var ms = new MemoryStream(cipherBytes);
                using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
                using var sr = new StreamReader(cs);
            
                return sr.ReadToEnd();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}