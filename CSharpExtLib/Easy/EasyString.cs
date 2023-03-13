﻿using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CSharpExtLib.Easy
{
    public static class EasyString
    {
        /// <summary>
        /// 获取字符串的最后一行
        /// </summary>
        /// <param name="text">字符串</param>
        /// <returns>字符串的最后一行</returns>
        public static string GetLastLine(string text)
        {
            Match match = Regex.Match(text, "^.*$", RegexOptions.Multiline | RegexOptions.RightToLeft);
            return match.Value;
        }

        /// <summary>
        /// 获取字符串的最后 <paramref name="count"/> 行
        /// </summary>
        /// <param name="text">字符串</param>
        /// <param name="count">行数</param>
        /// <returns>最后 <paramref name="count"/> 行的数组</returns>
        public static string[] GetLastLines(string text, int count)
        {
            string[] lines = new string[count];
            Match match = Regex.Match(text, "^.*$", RegexOptions.Multiline | RegexOptions.RightToLeft);
            for(int i = 0;i < count;i ++)
            { 
                lines[i] = match.Value;
                match = match.NextMatch( );
            }
            return lines;
        }

        /// <summary>
        /// 将字符串压缩至 <paramref name="len"/> 个字符长 
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="len">长度</param>
        /// <returns>压缩后的字符串</returns>
        public static string ZipStr(string str, int len)
        {
            if (str.Length <= len)
                return str;
            return str.Substring(0, len - 6) + "…" + str.Substring(str.Length - 6);
        }
    }
}
