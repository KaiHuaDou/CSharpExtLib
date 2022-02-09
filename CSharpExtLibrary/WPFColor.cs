using System.Windows.Media;
using System.Windows.Forms;
namespace CSharpExtLibrary
{
    public static class WPFColor
    {
        public static Color PickColor()
        {
            Color color = new Color( );
            ColorDialog cd = new ColorDialog( );
            cd.AnyColor = true;
            cd.FullOpen = true;
            cd.SolidColorOnly = false;
            if(cd.ShowDialog( ) == DialogResult.OK)
            {
                color = Converter.ConvertColor(cd.Color);
            }
            return color;
        }
    }
}