using CSharpExtLibrary;

namespace WPFColorPickerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            WPFColorPicker.NameColor nameColor = WPFColorPicker.PickColor( );
            System.Console.WriteLine(nameColor.Name);
            System.Console.WriteLine(nameColor.color.A);
            System.Console.WriteLine(nameColor.color.R);
            System.Console.WriteLine(nameColor.color.G);
            System.Console.WriteLine(nameColor.color.B);
            System.Console.ReadLine( );
        }
    }
}
