using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

namespace AceLand.Library.CSV
{
    public static class CsvExtension
    {
        private const string CVS_LINE_REGEX = @"(?<=^|,)(?:""(?<x>([^""]|"""")*)""|(?<x>[^,""\r\n]*))";

        public static IEnumerable<string[]> ReadAsCsvFile(this string fullPath, bool hasHeader = false)
        {
            var lines = hasHeader switch
            {
                true => File.ReadAllLines(fullPath)[1..^0],
                false => File.ReadAllLines(fullPath),
            };
            if (!File.Exists(fullPath))
            {
                Debug.LogError($"File is not exist - {fullPath}");
                yield break;
            }
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line.Trim())) continue;
                var fields = ReadCsvLine(line);
                yield return fields;
            }
        }

        public static IEnumerable<string[]> ReadAsCsv(this string cvsText, bool hasHeader = false)
        {
            var lines = hasHeader switch
            {
                true => cvsText.Split('\n')[1..^0],
                false => cvsText.Split('\n'),
            };
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line.Trim())) continue;
                var fields = ReadCsvLine(line);
                yield return fields;
            }
        }

        public static IEnumerable<string[]> ReadAsCsv(this TextAsset cvsText, bool hasHeader = false)
        {
            var lines = hasHeader switch
            {
                true => cvsText.text.Split('\n')[1..^0],
                false => cvsText.text.Split('\n'),
            };
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line.Trim())) continue;
                var fields = ReadCsvLine(line);
                yield return fields;
            }
        }

        public static string[] ReadCsvLine(this string line)
        {
            return (from Match m in Regex.Matches(line, CVS_LINE_REGEX, RegexOptions.ExplicitCapture) 
                select m.Groups[1].Value).ToArray();
        }
    }
}