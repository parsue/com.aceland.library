using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;
using ZLinq;

namespace AceLand.Library.Models
{
    public sealed class PathData : IComparable, IComparable<string>, IComparable<PathData>, IEquatable<PathData>
    {
        public static IPathDataBuilder Builder() => new PathDataBuilder();
        
        private PathData(string path)
        {
            _path = path;
        }

        private readonly string _path;
        public string FullPath => Path.GetFullPath(_path);
        public string Filename => Path.GetFileName(_path);
        public string FilenameWithoutExtension => Path.GetFileNameWithoutExtension(_path);
        public string FileExtension => Path.GetExtension(_path);

        public override string ToString() => FullPath;

        // Comparison settings
        private static readonly StringComparison Cmp = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
            ? StringComparison.OrdinalIgnoreCase
            : StringComparison.Ordinal;

        private static StringComparer Comparer => RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
            ? StringComparer.OrdinalIgnoreCase
            : StringComparer.Ordinal;
        
        // Equality
        public bool Equals(PathData other) => other is not null && Comparer.Equals(_path, other._path);
        public override bool Equals(object obj) => obj is PathData pd && Equals(pd);
        public override int GetHashCode() => Comparer.GetHashCode(_path);

        public static bool operator ==(PathData a, PathData b) => Equals(a, b);
        public static bool operator !=(PathData a, PathData b) => !Equals(a, b);
        public static implicit operator string(PathData pathData) => pathData.FullPath;

        // IComparable
        public int CompareTo(object obj) => obj switch
        {
            null => 1,
            string s => Comparer.Compare(_path, NormalizeInput(s, out _)),
            PathData p => Comparer.Compare(_path, p._path),
            _ => throw new ArgumentException("Object must be a string or PathData", nameof(obj))
        };

        public int CompareTo(string other) => other is null
            ? 1
            : Comparer.Compare(_path, NormalizeInput(other, out _));

        public int CompareTo(PathData other) => other is null
            ? 1
            : Comparer.Compare(_path, other._path);

        // Normalize: combine parts, resolve to full path, trim trailing separators (except root)
        private static string NormalizeInput(string input, out string error)
        {
            error = null;
            try
            {
                var full = Path.GetFullPath(input);
                var trimmed = TrimTrailingSeparatorsPreserveRoot(full);
                return trimmed;
            }
            catch (Exception ex)
            {
                error = $"Invalid path: {ex.Message}";
                return null;
            }
        }

        private static string TrimTrailingSeparatorsPreserveRoot(string path)
        {
            if (string.IsNullOrEmpty(path)) return path;

            var root = Path.GetPathRoot(path);
            var trimmed = path.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
            if (string.IsNullOrEmpty(root)) return trimmed;
            if (Comparer.Equals(trimmed, root.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)))
                return root; // keep canonical root with separator
            return trimmed;
        }
        
        // Builder

        public interface IPathDataBuilder
        {
            IPathDataPathBuilder WithPath(params string[] pathParts);
        }

        public interface IPathDataPathBuilder : IPathDataBuilder
        {
            PathData Build();
        }

        private class PathDataBuilder : IPathDataPathBuilder
        {
            private readonly List<string> _path = new();

            public PathData Build()
            {
                if (_path.Count == 0)
                {
                    Debug.LogError("Path data builder contains no path data");
                    return null;
                }
                
                var path = _path.AsValueEnumerable()
                    .Aggregate(string.Empty, (current, pathPart) => Path.Combine(current, pathPart));

                try
                {
                    _ = Path.GetFullPath(path);
                    return new PathData(path);
                }
                catch
                {
                    Debug.LogError("Path data builder only supports fully qualified paths");
                    return null;
                }
            }
            
            public IPathDataPathBuilder WithPath(params string[] pathParts)
            {
                _path.AddRange(pathParts);
                return this;
            }
        }
    }
}