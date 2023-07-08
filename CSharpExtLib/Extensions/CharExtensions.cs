namespace CSharpExtLib.Extensions;

/// <summary>
/// <see cref="char"/> 的扩展类
/// </summary>
public static class CharExtensions
{
    /// <summary>
    /// 高效判断字符是不是 ASCII 字母或数字
    /// </summary>
    /// <param name="ch">要判断的字符</param>
    public static bool IsAsciiLetterOrDigit(this char ch)
    {
        return ((uint) (ch - 'A') & ~0x20) < 26 ||
                (uint) (ch - '0') < 10;
    }
}
