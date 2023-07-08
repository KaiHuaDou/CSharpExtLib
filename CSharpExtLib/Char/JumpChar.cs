using System;
using System.Threading;

namespace CSharpExtLib.Char;

/// <summary>
/// 在控制台上显示逐字显示字符串
/// </summary>
public static class JumpChar
{
    /// <summary>
    /// 从零逐字打印字符串
    /// </summary>
    /// <param name="str">打印的字符串</param>
    /// <param name="span">等待的间隔</param>
    /// <param name="withEnter">打印后是否输出回车</param>
    public static void JumpPrint(string str, int span = 50, bool withEnter = true)
    {
        for (int i = 0; i < str.Length; i++)
        {
            Console.Write(str[i]);
            Thread.Sleep(span);
        }
        if (withEnter)
            Console.Write("\n");
    }

    /// <summary>
    /// 逐字删除字符串自零
    /// </summary>
    /// <param name="s">反向打印的字符串</param>
    /// <param name="span">等待的间隔</param>
    public static void JumpRemove(string s, int span = 100)
    {
        Console.Write(s);
        for (int i = 0; i < s.Length + 2; i++)
        {
            Thread.Sleep(span);
            for (int j = 0; j <= i + 1; j++)
                Console.Write("\b");
            for (int j = 0; j <= i + 1; j++)
                Console.Write(" ");
        }
        Console.Write("\n");
    }
}
