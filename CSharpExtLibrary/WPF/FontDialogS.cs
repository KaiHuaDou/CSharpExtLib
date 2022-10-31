using System.Windows.Forms;

namespace CSharpExtLib.WPF
{
    public struct FontS
    {
        public bool isBold, isItalic, isDeleted;
        public System.Windows.Media.FontFamily fontFamily;
        public float fontSize;
    }
    public static class FontDialogS
    {
        public static System.Windows.Media.FontFamily ShowFamily()
        {
            System.Windows.Forms.FontDialog fd = new System.Windows.Forms.FontDialog();
            if(fd.ShowDialog() == DialogResult.OK)
            {
                return new System.Windows.Media.FontFamily(fd.Font.FontFamily.Name);
            }
            return null;
        }
        public static FontS ShowStruct()
        {
            System.Windows.Forms.FontDialog fd = new System.Windows.Forms.FontDialog();
            FontS result = new FontS();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                result.fontFamily = new System.Windows.Media.FontFamily(fd.Font.FontFamily.Name);
                result.fontSize = fd.Font.Size;
                result.isBold = fd.Font.Bold;
                result.isItalic = fd.Font.Italic;
                result.isDeleted = fd.Font.Strikeout;
            }
            return result;
        }

    }
}
