using System.Windows.Media;

namespace CSharpExtLib.Easy
{
    /// <summary>
    /// 模拟 Photoshop 的颜色混合机制
    /// </summary>
    public static class EasyColorMix
    {
        /// <summary>
        /// 以普通模式混合颜色 (使用 WPF 色彩系统)
        /// </summary>
        /// <param name="up">上方图层颜色</param>
        /// <param name="down">下方图层颜色</param>
        /// <returns>混合后的的颜色</returns>
        public static Color Normal(Color up, Color down)
        {
            Color result = new Color( );
            result.R = (byte) ((up.R + down.R) / 2);
            result.G = (byte) ((up.G + down.G) / 2);
            result.B = (byte) ((up.B + down.B) / 2);
            result.A = (byte) ((up.A + down.A) / 2);
            return result;
        }

        /// <summary>
        /// 以“乘法”模式混合颜色 (使用 WPF 色彩系统)
        /// </summary>
        /// <param name="up">上方图层颜色</param>
        /// <param name="down">下方图层颜色</param>
        /// <returns>混合后的的颜色</returns>
        public static Color Multiply(Color up, Color down)
        {
            Color result = new Color( );
            result.R = (byte) (up.R * down.R / 255);
            result.G = (byte) (up.G * down.G / 255);
            result.B = (byte) (up.B * down.B / 255);
            result.A = (byte) (up.A * down.A / 255);
            return result;
        }

        /// <summary>
        /// 以“相减”模式混合颜色 (使用 WPF 色彩系统)
        /// </summary>
        /// <param name="up">上方图层颜色</param>
        /// <param name="down">下方图层颜色</param>
        /// <returns>混合后的的颜色</returns>
        public static Color Min(Color up, Color down)
        {
            Color result = new Color( );
            result.R = (byte) System.Math.Abs(up.R - down.R);
            result.G = (byte) System.Math.Abs(up.G - down.G);
            result.B = (byte) System.Math.Abs(up.B - down.B);
            result.A = (byte) System.Math.Abs(up.A - down.A);
            return result;
        }
    }
}
