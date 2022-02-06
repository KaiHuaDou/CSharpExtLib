using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;

namespace CSharpExtLibrary
{
    /// <summary>
    /// FontDialog.xaml 的交互逻辑
    /// </summary>
    public partial class FontDialog : Window
    {
        public FontDialog()
        {
            InitializeComponent();
            FontListBox.ItemsSource = GetFonts();
        }
        public static List<ListBoxItem> GetFonts()
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
                            if (FontManager.IsSymbolFont(lbi.Content.ToString(), new WindowInteropHelper(Application.Current.Windows[0]).Handle) == false)
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

        private void FontListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FontTextBox.Text = (string)((ListBoxItem)FontListBox.SelectedItem).Content;
        }

        private void SizeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SizeTextBox.Text = SizeListBox.SelectedItem.ToString();
        }
    }
}
