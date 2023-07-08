using System.Windows.Forms;
using System.Windows.Media;

namespace CSharpExtLib.WPF;

public static class FontSubDialog
{
    public static FontUnion Show( )
    {
        System.Windows.Forms.FontDialog fd = new( );
        FontUnion result = new( );
        if (fd.ShowDialog( ) == DialogResult.OK)
        {
            result.FontFamily = new FontFamily(fd.Font.FontFamily.Name);
            result.FontSize = fd.Font.Size;
            result.Bold = fd.Font.Bold;
            result.Italic = fd.Font.Italic;
            result.Deleted = fd.Font.Strikeout;
        }
        return result;
    }
}
