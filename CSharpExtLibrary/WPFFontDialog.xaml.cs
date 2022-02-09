using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CSharpExtLibrary
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
        }
        public bool isBold, isItalic, isDeleted;
        public FontFamily fontFamily;
        public int fontSize;
        private bool hasResult = true;
        private static List<ListBoxItem> GetFonts()
        {
            CultureInfo currentCulture = CultureInfo.CurrentUICulture;
            CultureInfo enUsCultureInfo = new CultureInfo("en-US");
            CultureInfo specificCulture;
            ListBoxItem lbi;
            List<ListBoxItem> fontList = new List<ListBoxItem>();
            foreach (var family in Fonts.SystemFontFamilies)
            {
                foreach (var keyPair in family.FamilyNames)
                {
                    specificCulture = keyPair.Key.GetSpecificCulture();
                    if (specificCulture.Equals(currentCulture) || specificCulture.Equals(enUsCultureInfo))
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
            }
            return fontList;
        }
        public new bool ShowDialog()
        {
            base.ShowDialog();
            return hasResult;
        }

        public new void Show()
        {
            this.ShowDialog();
        }

        private void FontListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FontTextBox.Text = (string)((ListBoxItem)FontListBox.SelectedItem).Content;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            hasResult = false;
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
            }
            catch (Exception ex) when (exTypes.Contains(ex.GetType()))
            {
                hasResult = false;
            }
            this.Close();
        }
    }
}
