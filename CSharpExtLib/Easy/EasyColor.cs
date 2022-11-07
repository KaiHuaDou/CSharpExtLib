using System.Windows.Media;

namespace CSharpExtLibrary.Easy
{
    public static class EasyColor
    {
        public static Color Mix(Color color1, Color color2)
        {
            Color result = new Color();
            result.R = (byte)((color1.R + color2.R) / 2);
            result.G = (byte)((color1.G + color2.G) / 2);
            result.B = (byte)((color1.B + color2.B) / 2);
            result.A = (byte)((color1.A + color2.A) / 2);
            return result;
        }
    }
}
