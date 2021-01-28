using System.Windows.Media;
using System.Windows.Forms;
namespace CSharpExtLibrary
{
    public static class WPFColorPicker
    {
        public struct NameColor
        {
            public Color color;
            public string Name;
        }
        public static NameColor PickColor()
        {
            NameColor nameColor = new NameColor( );
            ColorDialog cd = new ColorDialog( );
            cd.AnyColor = true;
            cd.FullOpen = true;
            cd.SolidColorOnly = false;
            if(cd.ShowDialog( ) == DialogResult.OK)
            {
                nameColor.color.A = cd.Color.A;
                nameColor.color.R = cd.Color.R;
                nameColor.color.G = cd.Color.G;
                nameColor.color.B = cd.Color.B;
                if(cd.Color.IsNamedColor == true)
                {
                    nameColor.Name = cd.Color.Name;
                }
                else
                {
                    nameColor.Name = cd.Color.ToString( );
                }
            }
            return nameColor;
        }
    }
}