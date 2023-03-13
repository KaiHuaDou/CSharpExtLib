using System.IO;
using System.Security.Principal;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Input;
using System.Runtime.Serialization;
using System;

namespace CSharpExtLib
{
    public static class Standard
    {
        /// <summary>
        /// 判断是否为管理员账户
        /// </summary>
        public static bool IsAdministrator( )
        {
            return new WindowsPrincipal(WindowsIdentity.GetCurrent( ))
                .IsInRole(WindowsBuiltInRole.Administrator);
        }

        /// <summary>
        /// 模拟键盘发送按键
        /// </summary>
        /// <param name="key">模拟的按键</param>
        public static void SendKey(Key key)
        {
            SendKey(key, 0);
            SendKey(key, 1);
        }

        /// <summary>
        /// 模拟键盘发送按键（可指定按下或抬起）
        /// </summary>
        /// <param name="key">模拟的按键</param>
        /// <param name="mode">按下(0)还是抬起(1)</param>
        public static void SendKey(Key key, int mode)
        {
            if (Keyboard.PrimaryDevice != null && Keyboard.PrimaryDevice.ActiveSource != null)
            {
                var e = new KeyEventArgs(Keyboard.PrimaryDevice, Keyboard.PrimaryDevice.ActiveSource, 0, key)
                {
                    RoutedEvent = mode != 0 ? Keyboard.KeyUpEvent : Keyboard.KeyDownEvent
                };
                InputManager.Current.ProcessInput(e);
            }
        }
        
        /// <summary>
        /// 创建未初始化的对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <returns>尚未执行过构造函数的对象</returns>
        public static T CreateUninitializedObject<T>( )
        {
            T t = (T) FormatterServices.GetUninitializedObject(typeof(T));
            var constructorInfo = typeof(T).GetConstructor(new Type[0]);
            constructorInfo.Invoke(t, null);
            return t;
        }
    }

    public static class FrameworkElementExtensions
    {
        /// <summary>
        /// 为 FrameworkElement 对象截图
        /// </summary>
        /// <param name="element">截图的对象</param>
        /// <param name="scale">缩放系数, 默认1.0 (100%)</param>
        /// <param name="dpi">DPI (像素密度), 默认96.0</param>
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
            RenderTargetBitmap bitmap = new RenderTargetBitmap(newWidth, newHeight, dpi, dpi, PixelFormats.Pbgra32);
            Rectangle rect = new Rectangle
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

    public static class ButtonExtensions
    {
        /// <summary>
        /// 模拟 Button 的点击操作
        /// </summary>
        /// <param name="button">操作的 Button</param>
        public static void Click(this Button button)
        {
            ButtonAutomationPeer peer = new ButtonAutomationPeer(button);
            IInvokeProvider provider = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
            provider.Invoke( );
        }
    }

    public static class ListViewExtensions
    {
        /// <summary>
        /// 将 ListView 滚动至底部
        /// </summary>
        /// <param name="list">要操作的 ListView</param>
        public static void ScrollToBottom(this ListView list)
        {
            DependencyObject d = VisualTreeHelper.GetChild(list, 0);
            ScrollViewer s = (ScrollViewer) VisualTreeHelper.GetChild(d, 0);
            s.ScrollToBottom( );
        }
    }

    public static class CharExtensions
    {
        /// <summary>
        /// 高效判断字符是不是 ASCII 字母或数字
        /// </summary>
        /// <param name="ch">要判断的字符</param>
        public static bool IsAsciiLetterOrDigit(this char ch)
        {
            return ((((uint) (ch - 'A')) & ~0x20) < 26) ||
                    (((uint) (ch - '0')) < 10);
        }
    }

    public static class FileInfoExtensions
    {
        /// <summary>
        /// 快速判断文件是不是隐藏
        /// </summary>
        /// <param name="file">判断的 FileInfo</param>
        public static bool IsHidden(this FileInfo file)
        {
            return file.Attributes.HasFlag(FileAttributes.Hidden);
        }
    }
}
