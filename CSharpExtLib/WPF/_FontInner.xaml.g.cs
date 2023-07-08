using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace CSharpExtLib.WPF
{
    /// <summary>
    /// _FontInner
    /// </summary>
    internal partial class _FontInner : Window, IComponentConnector
    {
        [SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Button ConfirmButton;
        [SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Button CancelButton;
        [SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal CheckBox BoldCheckBox;
        [SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal CheckBox ItalicCheckBox;
        [SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal CheckBox DeletedCheckBox;
        [SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal TextBox SizeTextBox;
        [SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ListBox SizeListBox;
        [SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal TextBox FontTextBox;
        [SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ListBox FontListBox;
        private bool _contentLoaded;
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute( )]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.7.0")]
        public void InitializeComponent( )
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CSharpExtLib;component/wpf/_fontinner.xaml", System.UriKind.Relative);
            System.Windows.Application.LoadComponent(this, resourceLocater);
        }
        [SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.ConfirmButton = ((Button) (target));
                    this.ConfirmButton.Click += new System.Windows.RoutedEventHandler(this.ConfirmTask);
                    return;
                case 2:
                    this.CancelButton = ((Button) (target));
                    this.CancelButton.Click += new System.Windows.RoutedEventHandler(this.CacelTask);
                    return;
                case 3:
                    this.BoldCheckBox = ((CheckBox) (target));
                    return;
                case 4:
                    this.ItalicCheckBox = ((CheckBox) (target));
                    return;
                case 5:
                    this.DeletedCheckBox = ((CheckBox) (target));
                    return;
                case 6:
                    this.SizeTextBox = ((TextBox) (target));
                    return;
                case 7:
                    this.SizeListBox = ((ListBox) (target));
                    this.SizeListBox.SelectionChanged += new SelectionChangedEventHandler(this.ChangeSize);
                    return;
                case 8:
                    this.FontTextBox = ((TextBox) (target));
                    return;
                case 9:
                    this.FontListBox = ((ListBox) (target));
                    this.FontListBox.SelectionChanged += new SelectionChangedEventHandler(this.ChangeFont);
                    return;
            }
            this._contentLoaded = true;
        }
    }
}
