using System.Windows.Media;

namespace CSharpExtLib.Easy
{
    public static class EasyConvert
    {
        public static Color ConvertColor(System.Drawing.Color color)
        {
            Color result = new Color();
            result.R = color.R;
            result.G = color.G;
            result.B = color.B;
            result.A = color.A;
            return result;
        }
        public static System.Drawing.Color ConvertColor(Color color)
        {
            System.Drawing.Color result;
            result = System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);
            return result;
        }
        public static FontFamily ConvertFontFamily(System.Drawing.FontFamily fontFamily)
        {
            FontFamily result = new FontFamily(fontFamily.Name);
            return result;
        }
        public static System.Drawing.FontFamily ConvertFontFamily(FontFamily fontFamily)
        {
            System.Drawing.FontFamily result = new System.Drawing.FontFamily(fontFamily.Source);
            return result;
        }
    }
}
