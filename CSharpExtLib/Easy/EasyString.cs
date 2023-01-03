using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CSharpExtLibrary.Easy
{
    public static class EasyString
    {
        public static string GetLastLine(string text)
        {
            Match match = Regex.Match(text, "^.*$", RegexOptions.Multiline | RegexOptions.RightToLeft);
            return match.Value;
        }
        public static List<string> GetLastLines(string text, int count)
        {
            List<string> lines = new List<string>( );
            Match match = Regex.Match(text, "^.*$", RegexOptions.Multiline | RegexOptions.RightToLeft);
            while (match.Success && lines.Count < count)
            {
                lines.Insert(0, match.Value);
                match = match.NextMatch( );
            }
            return lines;
        }
        public static string ZipStr(string str, int len)
        {
            if (str.Length <= len)
                return str;
            return str.Substring(0, len - 6) + "…" + str.Substring(str.Length - 6);
        }
    }
}
