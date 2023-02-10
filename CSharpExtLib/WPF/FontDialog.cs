using System.Collections.Generic;

namespace CSharpExtLib.WPF
{
    public class FontDialog
    {
        public FontUnion Font;
        public List<double> Sizes = new List<double> { 5.5, 6.5, 7.5, 10, 10.5, 11, 12, 14, 18, 20, 22, 24, 26, 28, 36, 48, 72 };

        public bool Show( )
        {
            _FontInner dialog = new _FontInner { Sizes = Sizes };
            dialog.ShowDialog( );
            Font = dialog.Font;
            return dialog.dialogResult;
        }
    }
}
