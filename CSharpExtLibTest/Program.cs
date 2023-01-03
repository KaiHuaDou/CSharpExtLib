using System;
using CSharpExtLib.WPF;

namespace CSharpExtLibTest
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            TestWPFFontDialog();
            Console.ReadKey();
        }
        public static void TestWPFFontDialog()
        {
            FontDialog wfd = new FontDialog();
            if (wfd.Show() == true)
            {
                Console.WriteLine("Font:" + wfd.fontFamily.ToString());
                Console.WriteLine("Size:" + wfd.fontSize);
                Console.WriteLine("Bold:" + wfd.isBold);
                Console.WriteLine("Italic:" + wfd.isItalic);
                Console.WriteLine("DeleteLine:" + wfd.isDeleted);
            }
            else
            {
                Console.WriteLine("Task is canceled");
            }
        }
    }
}
