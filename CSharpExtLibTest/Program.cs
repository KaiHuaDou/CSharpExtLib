using System;
using CSharpExtLib.WPF;

namespace CSharpExtLibTest
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            TestFontDialog( );
            Console.ReadKey( );
        }

        public static void TestFontDialog( )
        {
            FontDialog wfd = new FontDialog( );
            if (wfd.Show( ) == true)
            {
                Console.WriteLine("Font:" + wfd.Font.FontFamily.ToString( ));
                Console.WriteLine("Size:" + wfd.Font.FontSize);
                Console.WriteLine("Bold:" + wfd.Font.Bold);
                Console.WriteLine("Italic:" + wfd.Font.Italic);
                Console.WriteLine("Deleted:" + wfd.Font.Deleted);
            }
            else
            {
                Console.WriteLine("Task is canceled");
            }

        }
    }
}
