using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

namespace AceLand.Library.CSV
{
    public static class CsvReader
    {
        private const string CVS_LINE_REGEX = @"(((?<x>(?=[,\r\n]+))|""(?<x>([^""]|"""")+)""|(?<x>[^,\r\n]+)),?)";

        public static IEnumerable<string[]> ReadFile(string fullPath, bool hasHeader = false)
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
                string[] fields = ReadLine(line);
                yield return fields;
            }
        }

        public static string[] ReadLine(string line)
        {
            return (from Match m in Regex.Matches(line, CVS_LINE_REGEX, RegexOptions.ExplicitCapture) 
                select m.Groups[1].Value).ToArray();
        }
    }
}