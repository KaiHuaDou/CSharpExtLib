using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;

namespace CSharpExtLibrary
{
    public static class FontManager
    {
        public static bool IsSymbolFont(string fontName, IntPtr hwnd)
        {
            Font font = new Font(fontName, 15);
            FontSupporter.PanoseFontFamilyTypes pfft = FontSupporter.PanoseFontFamilyType(Graphics.FromHwnd(hwnd), font);
            if (pfft == FontSupporter.PanoseFontFamilyTypes.PAN_FAMILY_PICTORIAL)
            {
                return true;
            }
            return false;
        }
    }
    public class FontSupporter
    {
        public enum PanoseFontFamilyTypes : int
        {
            //  Any
            PAN_ANY = 0,
            // No Fit
            PAN_NO_FIT = 1,
            // Text and Display
            PAN_FAMILY_TEXT_DISPLAY = 2,
            // Script
            PAN_FAMILY_SCRIPT = 3,
            // Decorative
            PAN_FAMILY_DECORATIVE = 4,
            // Pictorial                      
            PAN_FAMILY_PICTORIAL = 5
        }
        [DllImport("gdi32", CharSet = CharSet.Ansi)]
        private static extern int GetOutlineTextMetrics(
         IntPtr hdc, int cbData, IntPtr lpOtm);

        [DllImport("gdi32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hObj);

        public static PanoseFontFamilyTypes PanoseFontFamilyType(
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
            return (PanoseFontFamilyTypes)bFamilyType;
        }
    }
}
