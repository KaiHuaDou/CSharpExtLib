using System.Windows.Media;

namespace CSharpExtLib.Easy;

public static class EasyConvert
{
    public static Color ConvertColor(System.Drawing.Color color)
    {
        return new( )
        {
            R = color.R,
            G = color.G,
            B = color.B,
            A = color.A
        };
    }
    public static System.Drawing.Color ConvertColor(Color color)
        => System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);
    public static FontFamily ConvertFontFamily(System.Drawing.FontFamily fontFamily)
        => new(fontFamily.Name);
    public static System.Drawing.FontFamily ConvertFontFamily(FontFamily fontFamily)
        => new(fontFamily.Source);
}
