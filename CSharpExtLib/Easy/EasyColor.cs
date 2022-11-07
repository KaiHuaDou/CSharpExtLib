using System.Windows.Media;
using System;

namespace CSharpExtLibrary.Easy
{
    public static class EasyColor
    {
        public static Color Normal(Color up, Color down)
        {
            Color result = new Color();
            result.R = (byte)((up.R + down.R) / 2);
            result.G = (byte)((up.G + down.G) / 2);
            result.B = (byte)((up.B + down.B) / 2);
            result.A = (byte)((up.A + down.A) / 2);
            return result;
        }
        public static Color Multiply(Color up, Color down)
        {
            Color result = new Color();
            result.R = (byte)(up.R * down.R / 255);
            result.G = (byte)(up.G * down.G / 255);
            result.B = (byte)(up.B * down.B / 255);
            result.A = (byte)(up.A * down.A / 255);
            return result;
        }
        public static Color Min(Color up, Color down)
        {
            Color result = new Color();
            result.R = (byte) Math.Abs(up.R - down.R);
            result.G = (byte) Math.Abs(up.G - down.G);
            result.B = (byte) Math.Abs(up.B - down.B);
            result.A = (byte) Math.Abs(up.A - down.A);
            return result;
        }
    }
}
