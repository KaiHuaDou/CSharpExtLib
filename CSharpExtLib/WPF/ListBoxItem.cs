using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace CSharpExtLib.WPF;

/// <summary>
/// <see cref="ListBoxItem"/> 的默认比较器
/// </summary>
public class ListBoxItemComparer : IEqualityComparer<ListBoxItem>
{
    public bool Equals(ListBoxItem x, ListBoxItem y)
        => x.Content.ToString( ) == y.Content.ToString( );

    public int GetHashCode(ListBoxItem obj)
        => obj == null ? 0 : obj.Content.GetHashCode( );
}

public class ListBoxItemSorter : IComparer<ListBoxItem>
{
    public int Compare(ListBoxItem x, ListBoxItem y)
        => string.Compare(x.Content.ToString( ), y.Content.ToString( ), StringComparison.Ordinal);
}
