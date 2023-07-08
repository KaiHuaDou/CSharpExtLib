using System.Windows.Media;

namespace CSharpExtLib.WPF;

public struct FontUnion
{
    public bool Bold { get; set; }
    public bool Italic { get; set; }
    public bool Deleted { get; set; }
    public FontFamily FontFamily { get; set; }
    public float FontSize { get; set; }
}
