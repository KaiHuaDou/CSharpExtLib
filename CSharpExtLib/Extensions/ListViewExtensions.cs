using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CSharpExtLib.Extensions;

/// <summary>
/// <see cref="ListView"/> 的扩展类
/// </summary>
public static class ListViewExtensions
{
    /// <summary>
    /// 将 ListView 滚动至底部
    /// </summary>
    /// <param name="list">要操作的 ListView</param>
    public static void ScrollToBottom(this ListView list)
    {
        DependencyObject d = VisualTreeHelper.GetChild(list, 0);
        ScrollViewer s = (ScrollViewer) VisualTreeHelper.GetChild(d, 0);
        s.ScrollToBottom( );
    }
}
