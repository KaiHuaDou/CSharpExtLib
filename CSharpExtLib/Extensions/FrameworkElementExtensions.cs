using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CSharpExtLib.Extensions;

/// <summary>
/// <see cref="FrameworkElement"/> 的扩展类
/// </summary>
public static class FrameworkElementExtensions
{
    /// <summary>
    /// 为 FrameworkElement 对象截图
    /// </summary>
    /// <param name="element">截图的对象</param>
    /// <param name="scale">缩放系数</param>
    /// <param name="dpi">DPI (像素密度)</param>
    /// <returns>以 BitmapSource 返回图像</returns>
    public static BitmapSource Snap(this FrameworkElement element, double scale = 1.0, double dpi = 96.0)
    {
        int width = (int) element.ActualWidth;
        int height = (int) element.ActualHeight;
        if (!element.IsLoaded)
        {
            element.Arrange(new Rect(0, 0, width, height));
            element.Measure(new Size(width, height));
        }
        int newWidth = (int) (width * scale);
        int newHeight = (int) (height * scale);
        RenderTargetBitmap bitmap = new(newWidth, newHeight, dpi, dpi, PixelFormats.Pbgra32);
        Rectangle rect = new( )
        {
            Width = newWidth,
            Height = newHeight,
            Fill = new VisualBrush(element)
            {
                Viewbox = new Rect(0, 0, width, height),
                ViewboxUnits = BrushMappingMode.Absolute,
            }
        };
        rect.Measure(new Size(newWidth, newHeight));
        rect.Arrange(new Rect(new Size(newWidth, newHeight)));
        bitmap.Render(rect);
        return bitmap;
    }
}
