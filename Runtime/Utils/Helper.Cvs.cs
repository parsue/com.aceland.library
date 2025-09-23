using System.Linq;
using System.Text.RegularExpressions;

namespace AceLand.Library.Utils
{
    public static partial class Helper
    {
        private const string CVS_LINE_REGEX = @"(?<=^|,)(?:""(?<x>([^""]|"""")*)""|(?<x>[^,""\r\n]*))";

        internal static string[] ReadCsvLine(string line)
        {
            return (from Match m in Regex.Matches(line, CVS_LINE_REGEX, RegexOptions.ExplicitCapture) 
                select m.Groups[1].Value).ToArray();
        }
    }
}