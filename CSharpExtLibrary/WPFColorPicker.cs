using System.Windows.Media;
using System.Windows.Forms;
namespace CSharpExtLibrary
{
    static class WPFColorPicker
    {
        static Color PickColor()
        {
            Color color = new Color( );
            ColorDialog cd = new ColorDialog( );
            cd.AnyColor = true;
            cd.FullOpen = true;
            cd.SolidColorOnly = false;
            if(cd.ShowDialog( ) == DialogResult.OK)
            {
                color.A = cd.Color.A;
                color.R = cd.Color.R;
                color.G = cd.Color.G;
                color.B = cd.Color.B;
            }
            return color;
        }
    }
}
