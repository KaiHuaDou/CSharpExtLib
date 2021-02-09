using CSharpExtLibrary;
using System;
using System.Windows;

namespace CSharpExtLibraryTest
{
    class Program
    {
        public static void ColorPickerTester()
        {
            WPFColorPicker.NameColor nameColor = WPFColorPicker.PickColor( );
            Console.WriteLine(nameColor.Name);
            Console.WriteLine(nameColor.color.A);
            Console.WriteLine(nameColor.color.R);
            Console.WriteLine(nameColor.color.G);
            Console.WriteLine(nameColor.color.B);
            Console.ReadLine( );
        }
        public static void JumpCharTester()
        {
            JumpChar.jumpPrint(Console.ReadLine( ));
            JumpChar.jumpRemove(Console.ReadLine( ));
            
        }
        static void Main(string[] args)
        {
            while(true)
                JumpCharTester( );
        }
    }
    public class WpfApp : Application
    {
    }
}
