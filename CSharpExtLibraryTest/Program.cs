using System;
using System.Windows;
using CSharpExtLibrary;

namespace CSharpExtLibraryTest
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
            WPFFontDialog wfd = new WPFFontDialog();
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
