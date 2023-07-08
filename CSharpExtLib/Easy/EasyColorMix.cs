using System.Windows.Media;

namespace CSharpExtLib.Easy;

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
        return new( )
        {
            R = (byte) ((up.R + down.R) / 2),
            G = (byte) ((up.G + down.G) / 2),
            B = (byte) ((up.B + down.B) / 2),
            A = (byte) ((up.A + down.A) / 2)
        };
    }

    /// <summary>
    /// 以“乘法”模式混合颜色 (使用 WPF 色彩系统)
    /// </summary>
    /// <param name="up">上方图层颜色</param>
    /// <param name="down">下方图层颜色</param>
    /// <returns>混合后的的颜色</returns>
    public static Color Multiply(Color up, Color down)
    {
        return new( )
        {
            R = (byte) (up.R * down.R / 255),
            G = (byte) (up.G * down.G / 255),
            B = (byte) (up.B * down.B / 255),
            A = (byte) (up.A * down.A / 255)
        };
    }

    /// <summary>
    /// 以“相减”模式混合颜色 (使用 WPF 色彩系统)
    /// </summary>
    /// <param name="up">上方图层颜色</param>
    /// <param name="down">下方图层颜色</param>
    /// <returns>混合后的的颜色</returns>
    public static Color Min(Color up, Color down)
    {
        return new( )
        {
            R = (byte) System.Math.Abs(up.R - down.R),
            G = (byte) System.Math.Abs(up.G - down.G),
            B = (byte) System.Math.Abs(up.B - down.B),
            A = (byte) System.Math.Abs(up.A - down.A)
        };
    }
}
