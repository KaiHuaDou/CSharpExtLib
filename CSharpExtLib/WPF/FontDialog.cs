using System.Collections.Generic;

namespace CSharpExtLib.WPF;

/// <summary>
/// WPF 字体选择器
/// </summary>
public class FontDialog
{
    /// <summary>
    /// 选择的字体
    /// </summary>
    public FontUnion Font { get; set; }

    /// <summary>
    /// 显示字体选择器窗口
    /// </summary>
    /// <returns>是否成功</returns>
    public bool? Show( )
    {
        _FontInner dialog = new( );
        return ShowDialog(dialog);
    }

    /// <summary>
    /// 显示带有指定字号列表的字体选择器窗口
    /// </summary>
    /// <param name="sizes">字号列表</param>
    /// <returns>是否成功</returns>
    public bool? Show(List<double> sizes)
    {
        _FontInner dialog = new( ) { Sizes = sizes };
        return ShowDialog(dialog);
    }

    private bool? ShowDialog(_FontInner dialog)
    {
        dialog.ShowDialog( );
        Font = dialog.Font;
        return dialog.dialogResult;
    }
}
