using System.Collections.Generic;

namespace CSharpExtLib.WPF
{
    public class FontDialog
    {
        public FontUnion Font;

        public bool Show( )
        {
            _FontInner dialog = new _FontInner( );
            return ShowDialog(dialog);
        }

        public bool Show(List<double> sizes)
        {
            _FontInner dialog = new _FontInner { Sizes = sizes };
            return ShowDialog(dialog);
        }

        private bool ShowDialog(_FontInner dialog)
        {
            dialog.ShowDialog( );
            Font = dialog.Font;
            return dialog.dialogResult;
        }
    }
}
