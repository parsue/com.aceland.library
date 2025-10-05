using System;
using System.Collections.Generic;
using AceLand.Library.Utils;
using UnityEngine;
using ZLinq;

namespace AceLand.Library.Models
{
    public sealed class CsvData
    {
        public static ICsvDataBuilder Builder() => new CsvDataBuilder();
        
        private CsvData(List<string[]> lines, bool hasHeader, int columnCount)
        {
            HasHeader = hasHeader;
            Header = hasHeader ? lines[0] : Array.Empty<string>();
            _lines = lines.GetRange(hasHeader ? 1 : 0, lines.Count - 1)
                .AsValueEnumerable()
                .ToArray();
            ColumnCount = columnCount;
        }

        public string[] Header { get; }
        private readonly string[][] _lines;

        public IEnumerable<string[]> Lines => _lines;
        public string[] this[int index] => _lines[index];
        public int ColumnCount { get; }
        public int LineCount => _lines.Length;
        public bool HasHeader { get; }

        // builder

        public interface ICsvDataBuilder
        {
            ICsvDataLineBuilder WithHeader(string header);
            ICsvDataFinalBuilder WithHeaderFields(params string[] fields);
            ICsvDataLineBuilder WithoutHeader();
        }

        public interface ICsvDataLineBuilder
        {
            ICsvDataFinalBuilder WithLine(string line);
            ICsvDataFinalBuilder WithFields(params string[] fields);
        }

        public interface ICsvDataFinalBuilder : ICsvDataLineBuilder
        {
            CsvData Build();
        }

        private class CsvDataBuilder : ICsvDataBuilder, ICsvDataFinalBuilder
        {
            private readonly List<string[]> _lines = new();
            private bool _hasHeader;
            private int _columnCount;
            
            public CsvData Build()
            {
                return new CsvData(_lines, _hasHeader, _columnCount);
            }
            
            public ICsvDataLineBuilder WithHeader(string header)
            {
                if (!UpdateColumnCount(header, out var fields)) return this;

                _lines.Add(fields);
                return this;
            }

            public ICsvDataFinalBuilder WithHeaderFields(params string[] fields)
            {
                if (!UpdateColumnCount(fields)) return this;

                _lines.Add(fields);
                return this;
            }

            public ICsvDataLineBuilder WithoutHeader()
            {
                return this;
            }

            public ICsvDataFinalBuilder WithLine(string line)
            {
                if (!UpdateColumnCount(line, out var fields)) return this;
                
                _lines.Add(fields);
                return this;
            }

            public ICsvDataFinalBuilder WithFields(params string[] fields)
            {
                if (!UpdateColumnCount(fields)) return this;

                _lines.Add(fields);
                return this;
            }

            private bool UpdateColumnCount(string line, out string[] fields)
            {
                fields = ALib.Helper.ReadCsvLine(line);
                if (_columnCount == 0)
                {
                    _columnCount = fields.Length;
                    return true;
                }

                if (_columnCount == fields.Length) return true;
                
                Debug.LogWarning($"Column count mismatch: {line}");
                return false;
            }

            private bool UpdateColumnCount(string[] fields)
            {
                if (_columnCount == 0)
                {
                    _columnCount = fields.Length;
                    return true;
                }

                if (_columnCount == fields.Length) return true;
                
                Debug.LogWarning($"Column count mismatch: {string.Join(',', fields)}");
                return false;
            }
        }
    }
}