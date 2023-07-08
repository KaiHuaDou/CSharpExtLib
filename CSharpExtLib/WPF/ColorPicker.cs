using System.Windows.Forms;
using System.Windows.Media;
using CSharpExtLib.Easy;

namespace CSharpExtLib.WPF;

public static class ColorPicker
{
    public static Color Show( )
    {
        Color color = new( );
        ColorDialog cd = new( )
        {
            AnyColor = true,
            FullOpen = true,
            SolidColorOnly = false
        };
        if (cd.ShowDialog( ) == DialogResult.OK)
            color = EasyConvert.ConvertColor(cd.Color);
        return color;
    }
}
