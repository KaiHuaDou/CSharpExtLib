using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CSharpExtLibrary.Math
{
    /// <summary>
    /// FontDialog.xaml 的交互逻辑
    /// </summary>
    public sealed partial class WPFFontDialog : Window
    {
        public WPFFontDialog()
        {
            InitializeComponent();
            FontListBox.ItemsSource = GetFonts();
            FontListBox.SelectedIndex = 0;
            SizeListBox.SelectedIndex = 0;
        }
        public bool isBold, isItalic, isDeleted;
        public FontFamily fontFamily;
        public int fontSize;
        private bool hasResult = false;
        private static List<ListBoxItem> GetFonts()
        {
            ListBoxItem lbi;
            List<ListBoxItem> fontList = new List<ListBoxItem>();
            foreach (var family in Fonts.SystemFontFamilies)
            {
                foreach (var keyPair in family.FamilyNames)
                {
                        if (keyPair.Key != null && !string.IsNullOrEmpty(keyPair.Value))
                        {
                            lbi = new ListBoxItem();
                            lbi.Content = keyPair.Value;
                            if (FontManager.IsSymbolFont(lbi.Content.ToString()) == false)
                            {
                                lbi.FontFamily = new FontFamily(keyPair.Value);
                            }
                            fontList.Add(lbi);
                        }
                }
            }
            fontList.Sort(new FontListBoxItemComparer());
            fontList = PrivateApi.Purge(fontList);
            return fontList;
        }
        public new bool ShowDialog()
        {
            base.ShowDialog();
            return hasResult;
        }

        public new bool Show()
        {
            return this.ShowDialog();
        }

        private void FontListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FontTextBox.Text = (string)((ListBoxItem)FontListBox.SelectedItem).Content;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SizeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SizeTextBox.Text = SizeListBox.SelectedItem.ToString();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            var exTypes = new Type[]
            {
                typeof(NullReferenceException),
                typeof(ArgumentNullException),
                typeof(FormatException),
                typeof(OverflowException),
            };
            try
            {
                fontFamily = new FontFamily(FontTextBox.Text);
                fontSize = int.Parse(SizeTextBox.Text);
                isBold = (bool)BoldCheckBox.IsChecked;
                isItalic = (bool)ItalicCheckBox.IsChecked;
                isDeleted = (bool)DeletedCheckBox.IsChecked;
                hasResult = true;
                this.Close();
            }
            catch (Exception ex) when (exTypes.Contains(ex.GetType()))
            {
                MessageBox.Show("自定义字体或字号时请确定输入正确！", "选择字体",
                    MessageBoxButton.OK, MessageBoxImage.Error,
                    MessageBoxResult.OK, MessageBoxOptions.ServiceNotification);
            }
        }
    }
}