using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace CSharpExtLib.WPF
{
    public class ListBoxItemComparer : IEqualityComparer<ListBoxItem>
    {
        public bool Equals(ListBoxItem x, ListBoxItem y)
            => x.Content.ToString() == y.Content.ToString( );

        public int GetHashCode(ListBoxItem obj)
        {
            if (obj == null) return 0;
            return obj.Content.GetHashCode( );
        }
    }

    public class ListBoxItemSorter : IComparer<ListBoxItem>
    {
        public int Compare(ListBoxItem x, ListBoxItem y)
            => x.Content.ToString().CompareTo(y.Content.ToString());
    }
}