using System.Windows.Media;
using System.Windows.Forms;
namespace CSharpExtLibrary
{
    public static class WPFColor
    {
        public static Color ConvertColor(System.Drawing.Color color)
        {
            Color ans = new Color();
            ans.R = color.R;
            ans.G = color.G;
            ans.B = color.B;
            ans.A = color.A;
            return ans;
        }
        public static System.Drawing.Color ConvertColor(Color color)
        {
            System.Drawing.Color ans;
            ans = System.Drawing.Color.FromArgb(
                color.A, color.R, color.G, color.B);
            return ans;
        }
        public static Color PickColor()
        {
            Color color = new Color( );
            ColorDialog cd = new ColorDialog( );
            cd.AnyColor = true;
            cd.FullOpen = true;
            cd.SolidColorOnly = false;
            if(cd.ShowDialog( ) == DialogResult.OK)
            {
                color = ConvertColor(cd.Color);
            }
            return color;
        }
    }
}