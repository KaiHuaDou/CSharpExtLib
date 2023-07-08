using System.IO;

namespace CSharpExtLib.Extensions;

/// <summary>
/// <see cref="FileInfo"/> 的扩展类
/// </summary>
public static class FileInfoExtensions
{
    /// <summary>
    /// 快速判断文件是不是隐藏
    /// </summary>
    /// <param name="file">判断的 FileInfo</param>
    public static bool IsHidden(this FileInfo file)
        => file.Attributes.HasFlag(FileAttributes.Hidden);
}
