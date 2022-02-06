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
            Application app = new Application();
            app.Run(new FontDialog());
        }
    }
}
