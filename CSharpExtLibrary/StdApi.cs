﻿using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace CSharpExtLibrary
{
    public static class StdApi
    {
        public static List<ListBoxItem> Purge(List<ListBoxItem> list)
        {
            List<ListBoxItem> result = new List<ListBoxItem>();
            result.Add(list[0]);
            for(int i = 1; i < list.Count; i ++)
            {
                if(list[i].Content.ToString() != list[i - 1].Content.ToString())
                {
                    result.Add(list[i]);
                }
            }
            return result;
        }
    }
}
