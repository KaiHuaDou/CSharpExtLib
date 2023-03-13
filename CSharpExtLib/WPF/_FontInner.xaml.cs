﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CSharpExtLib.Char;

namespace CSharpExtLib.WPF
{
    public partial class _FontInner : Window
    {
        public FontUnion Font;
        public List<double> Sizes = new List<double> { 5.5, 6.5,
            7.5, 10, 10.5, 11, 12, 14, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
        public bool dialogResult = false;

        private double maxHeight = 0.5 * System.Windows.Forms.SystemInformation.WorkingArea.Height;

        public _FontInner( )
        {
            InitializeComponent( );
            FontListBox.ItemsSource = GetFonts( );
            SizeListBox.ItemsSource = Sizes;
            FontListBox.SelectedIndex = 0;
            SizeListBox.SelectedIndex = 0;
            this.FontListBox.MaxHeight = this.SizeListBox.MaxHeight = maxHeight;
        }

        private static List<ListBoxItem> GetFonts( )
        {
            List<ListBoxItem> fonts = new List<ListBoxItem>( );
            foreach (var family in Fonts.SystemFontFamilies)
            {
                foreach (var font in family.FamilyNames.Where(font
                    => font.Key != null && !string.IsNullOrEmpty(font.Value)))
                {
                    ListBoxItem item = new ListBoxItem { Content = font.Value };
                    if (!FontMgr.IsSymbolFont(item.Content.ToString( )))
                        item.FontFamily = new FontFamily(font.Value);
                    fonts.Add(item);
                }
            }
            fonts.Sort(new ListBoxItemSorter( ));
            fonts = fonts.Distinct(new ListBoxItemComparer( )).ToList( );
            return fonts;
        }

        private void ConfirmTask(object o, RoutedEventArgs e)
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
                Font.FontFamily = new FontFamily(FontTextBox.Text);
                Font.FontSize = float.Parse(SizeTextBox.Text);
                Font.Bold = (bool) BoldCheckBox.IsChecked;
                Font.Italic = (bool) ItalicCheckBox.IsChecked;
                Font.Deleted = (bool) DeletedCheckBox.IsChecked;
                dialogResult = true;
                this.Close( );
            }
            catch (Exception ex) when (exTypes.Contains(ex.GetType( )))
            {
                MessageBox.Show("格式错误", "字体选择器",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ChangeFont(object o, SelectionChangedEventArgs e)
            => FontTextBox.Text = (string) ((ListBoxItem) FontListBox.SelectedItem).Content;

        private void ChangeSize(object o, SelectionChangedEventArgs e)
            => SizeTextBox.Text = SizeListBox.SelectedItem.ToString( );

        private void CacelTask(object o, RoutedEventArgs e) => Close( );
    }
}