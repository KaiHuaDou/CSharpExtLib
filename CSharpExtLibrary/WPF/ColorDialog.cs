using System.Windows.Media;
using System.Windows.Forms;
namespace CSharpExtLib.WPF
{   
    public static class ColorDialog
    {
        public static Color PickColor()
        {
            Color color = new Color( );
            System.Windows.Forms.ColorDialog cd = new System.Windows.Forms.ColorDialog( );
            cd.AnyColor = true;
            cd.FullOpen = true;
            cd.SolidColorOnly = false;
            if(cd.ShowDialog( ) == DialogResult.OK)
            {
                color = EasyConverter.ConvertColor(cd.Color);
            }
            return color;
        }
    }
}