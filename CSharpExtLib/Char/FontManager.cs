using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace CSharpExtLib.Char
{
    /// <summary>
    /// 管理字体相关的类
    /// </summary>
    public static class FontMgr
    {
        [DllImport("gdi32", CharSet = CharSet.Ansi)]
        private static extern int GetOutlineTextMetrics(IntPtr hdc, int cbData, IntPtr lpOtm);

        [DllImport("gdi32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hObj);

        /// <summary>
        /// 根据字体名称确定字体是否是符号字体
        /// </summary>
        /// <param name="fontName">字体名称</param>
        /// <returns>
        /// fontName 关联的 <see cref="FontType"/> 是否以下二者之一
        /// + <see cref="FontType.Decorate"/> 
        /// + <see cref="FontType.Symbol"/>
        /// </returns>
        public static bool IsSymbolFont(string fontName)
        {
            FontType fontType = GetFontType(fontName);
            return fontType == FontType.Symbol || fontType == FontType.Decorate;
        }

        /// <summary>
        /// 根据字体名称获取字体类型
        /// </summary>
        /// <param name="fontName">字体名称</param>
        /// <returns>字体类型参见<see cref="FontType"/></returns>
        public static FontType GetFontType(string fontName)
        {
            Font font = new Font("Arial", 1);
            try { font = new Font(fontName, 1); } catch { }
            return GetFontType(font);
        }

        private static FontType GetFontType(Font font)
        {
            byte familyType = 0;
            Graphics graph = Graphics.FromHwnd(new IntPtr( ));
            IntPtr hdc = graph.GetHdc( );
            IntPtr fontObj = SelectObject(hdc, font.ToHfont( ));
            int bufSize = GetOutlineTextMetrics(hdc, 0, IntPtr.Zero);
            IntPtr bufPtr = Marshal.AllocCoTaskMem(bufSize);
            Marshal.WriteInt32(bufPtr, bufSize);
            int success = GetOutlineTextMetrics(hdc, bufSize, bufPtr);
            if (success != 0)
            {
                int offset = 61;
                familyType = Marshal.ReadByte(bufPtr, offset);
            }
            Marshal.FreeCoTaskMem(bufPtr);
            SelectObject(hdc, fontObj);
            graph.ReleaseHdc(hdc);
            return (FontType) familyType;
        }

    }
}
