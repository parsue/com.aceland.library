using System;
using System.Linq;
using AceLand.Library.Extensions;
using AceLand.Library.Utils;
using UnityEngine;

namespace AceLand.Library.Services
{
    public interface IRegistryService
    {
        string Read(string key, string defaultValue);
        int Read(string key, int defaultValue);
        bool Read(string key, bool defaultValue);
        string[] Read(string key, string[] defaultValue);
        void Write(string key, string value);
        void Write(string key, int value);
        void Write(string key, bool value);
        void Write(string key, string[] values);
        void Remove(string key);
    }

    /// <summary>
    /// Registry Service will encrypt all values to Registry.
    /// Usually PlayerPref is good to record data in human-readable way.
    /// If you want to secure data from reading easily,
    ///     Read and Write your values by this service.
    /// </summary>
    internal sealed class RegistryService : IRegistryService
    {
        private RegistryService(IStringHelper stringHelper)
        {
            _stringHelper = stringHelper;
        }

        private readonly IStringHelper _stringHelper;

        public string Read(string key, string defaultValue = null)
        {
            if (!CheckKey(key)) return defaultValue ?? string.Empty;
            
            var enKey = _stringHelper.Encrypt(key);
            var encrypted = PlayerPrefs.GetString(enKey, defaultValue ?? string.Empty);
            
            return _stringHelper.Decrypt(encrypted) ?? defaultValue;
        }

        public int Read(string key, int defaultValue = 0)
        {
            if (!CheckKey(key)) return defaultValue;

            var enKey = _stringHelper.Encrypt(key);
            var encrypted = PlayerPrefs.GetString(enKey);
            if (encrypted.IsNullOrEmptyOrWhiteSpace()) return defaultValue;

            var decrypted = _stringHelper.Decrypt(encrypted);

            return !decrypted.IsNullOrEmptyOrWhiteSpace() && int.TryParse(decrypted, out var result)
                ? result
                : defaultValue;
        }

        public bool Read(string key, bool defaultValue = false)
        {
            if (!CheckKey(key)) return defaultValue;

            var enKey = _stringHelper.Encrypt(key);
            var encrypted = PlayerPrefs.GetString(enKey);
            if (encrypted.IsNullOrEmptyOrWhiteSpace()) return defaultValue;

            var decrypted = _stringHelper.Decrypt(encrypted);

            return !decrypted.IsNullOrEmptyOrWhiteSpace() && bool.TryParse(decrypted, out var result)
                ? result
                : defaultValue;
        }

        public string[] Read(string key, string[] defaultValue = null)
        {
            if (!CheckKey(key)) return defaultValue ?? Array.Empty<string>();

            var enKey = _stringHelper.Encrypt(key);
            var encrypted = PlayerPrefs.GetString(enKey);
            if (encrypted.IsNullOrEmptyOrWhiteSpace()) return defaultValue ?? Array.Empty<string>();

            var encList = encrypted.Split(',');
            var decList = encList.Select(v => _stringHelper.Encrypt(v))
                .Where(v => !v.IsNullOrEmptyOrWhiteSpace())
                .ToArray();

            return decList;
        }

        public void Write(string key, string value)
        {
            if (!CheckKey(key)) return;

            var enKey = _stringHelper.Encrypt(key);
            var encrypted = _stringHelper.Encrypt(value);
            
            PlayerPrefs.SetString(enKey, encrypted);
        }

        public void Write(string key, int value)
        {
            if (!CheckKey(key)) return;

            var enKey = _stringHelper.Encrypt(key);
            var encrypted = _stringHelper.Encrypt(value.ToString());
            
            PlayerPrefs.SetString(enKey, encrypted);
        }

        public void Write(string key, bool value)
        {
            if (!CheckKey(key)) return;

            var enKey = _stringHelper.Encrypt(key);
            var encrypted = _stringHelper.Encrypt(value.ToString());
            
            PlayerPrefs.SetString(enKey, encrypted);
        }

        public void Write(string key, string[] values)
        {
            if (!CheckKey(key)) return;

            var enKey = _stringHelper.Encrypt(key);
            var list = values.Select(v => _stringHelper.Encrypt(v)).ToList();
            var encrypted = string.Join(",", list);
            
            PlayerPrefs.SetString(enKey, encrypted);
        }

        public void Remove(string key)
        {
            if (!CheckKey(key)) return;
            
            var enKey = _stringHelper.Encrypt(key);
            if (!PlayerPrefs.HasKey(enKey)) return;

            PlayerPrefs.DeleteKey(enKey);
        }

        private static bool CheckKey(string key)
        {
            if (!key.IsNullOrEmptyOrWhiteSpace()) return true;
            
            Debug.LogWarning("Key cannot be null or empty.");
            return false;
        }
    }
}