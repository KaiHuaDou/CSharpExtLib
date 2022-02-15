using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace CSharpExtLibrary
{
    public static class FontManager
    {
        public static bool IsSymbolFont(string fontName)
        {
            FontType fontType = FontSupporter.GetFontType(fontName);
            if(fontType == FontType.SYMBOL || fontType == FontType.DECORATE)
            {
                return true;
            }
            return false;
        }
    }
    public enum FontType : int
    {
        EMPTY = 0,
        ERROR = 1,
        DISPLAY = 2,
        SCRIPT = 3,
        DECORATE = 4,
        SYMBOL = 5
    }

    public class FontSupporter
    {
        public static FontType GetFontType(string fontName)
        {
            Font font = new Font("Arial", 15);
            try
            {
                font = new Font(fontName, 15, FontStyle.Regular);
            }
            catch (Exception) { }
            return GetFontType(Graphics.FromHwnd(new IntPtr()), font);
        }

        [DllImport("gdi32", CharSet = CharSet.Ansi)]
        private static extern int GetOutlineTextMetrics(IntPtr hdc, int cbData, IntPtr lpOtm);

        [DllImport("gdi32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hObj);

        private static FontType GetFontType(
            Graphics graphics, Font font)
        {
            byte bFamilyType = 0;
            IntPtr hdc = graphics.GetHdc();
            IntPtr hFontOld = SelectObject(hdc, font.ToHfont());
            int bufSize = GetOutlineTextMetrics(hdc, 0, IntPtr.Zero);
            IntPtr lpOtm = Marshal.AllocCoTaskMem(bufSize);
            Marshal.WriteInt32(lpOtm, bufSize);
            int success = GetOutlineTextMetrics(hdc, bufSize, lpOtm);
            if (success != 0)
            {
                int offset = 61;
                bFamilyType = Marshal.ReadByte(lpOtm, offset);
            }
            Marshal.FreeCoTaskMem(lpOtm);
            SelectObject(hdc, hFontOld);
            graphics.ReleaseHdc(hdc);
            return (FontType)bFamilyType;
        }
    }
}
