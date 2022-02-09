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
            WPFFontDialog wfd = new WPFFontDialog();
            wfd.ShowDialog();
            Console.WriteLine(wfd.fontFamily.ToString());
            Console.ReadKey();
        }
    }
}
