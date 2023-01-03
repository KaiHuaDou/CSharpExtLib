using System.Windows.Forms;
using System.Windows.Media;
using CSharpExtLib.Easy;

namespace CSharpExtLib.WPF
{
    public static class ColorPicker
    {
        public static Color PickColor( )
        {
            Color color = new Color( );
            ColorDialog cd = new ColorDialog
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
}
