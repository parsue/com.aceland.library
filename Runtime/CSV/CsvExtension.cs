using System.Collections.Generic;
using System.IO;
using AceLand.Library.Models;
using AceLand.Library.Utils;
using UnityEngine;

namespace AceLand.Library.CSV
{
    
    public static class CsvExtension
    {
        public static CsvData ReadAsCsvData(this PathData pathData, bool hasHeader = false)
        {
            if (!File.Exists(pathData))
            {
                Debug.LogError($"File is not exist - {pathData}");
                return null;
            }
            
            var lines = hasHeader switch
            {
                true => File.ReadAllLines(pathData)[1..],
                false => File.ReadAllLines(pathData),
            };

            return DataBuilder(lines, hasHeader);
        }

        public static CsvData ReadAsCsvData(this TextAsset cvsText, bool hasHeader = false)
        {
            var lines = hasHeader switch
            {
                true => cvsText.text.Split('\n')[1..],
                false => cvsText.text.Split('\n'),
            };

            return DataBuilder(lines, hasHeader);
        }
        
        public static IEnumerable<string[]> ReadAsCsv(this PathData pathData, bool hasHeader = false)
        {
            if (!File.Exists(pathData))
            {
                Debug.LogError($"File is not exist - {pathData}");
                yield break;
            }
            
            var lines = hasHeader switch
            {
                true => File.ReadAllLines(pathData)[1..],
                false => File.ReadAllLines(pathData),
            };
            
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line.Trim())) continue;
                var fields = ALib.Helper.ReadCsvLine(line);
                yield return fields;
            }
        }

        public static IEnumerable<string[]> ReadAsCsv(this TextAsset cvsText, bool hasHeader = false)
        {
            var lines = hasHeader switch
            {
                true => cvsText.text.Split('\n')[1..],
                false => cvsText.text.Split('\n'),
            };
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line.Trim())) continue;
                var fields = ALib.Helper.ReadCsvLine(line);
                yield return fields;
            }
        }

        private static CsvData DataBuilder(string[] lines, bool hasHeader)
        {
            var csvBuilder = hasHeader
                ? CsvData.Builder().WithHeader(lines[0]).WithLine(lines[1])
                : CsvData.Builder().WithoutHeader().WithLine(lines[0]);

            for (var i = hasHeader ? 2 : 1; i < lines.Length; i++)
            {
                var line = lines[i];
                csvBuilder = csvBuilder.WithLine(line);
            }
            
            return csvBuilder.Build();
        }
    }
}