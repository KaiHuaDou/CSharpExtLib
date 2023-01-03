using System.Collections.Generic;

namespace CSharpExtLibrary
{
    public static class Universal
    {
        public static List<T> Purge<T>(List<T> list)
        {
            List<T> result = new List<T>( );
            result.Add(list[0]);
            for (int i = 1; i < list.Count; i++)
                if (list[i].ToString( ) != list[i - 1].ToString( ))
                    result.Add(list[i]);
            return result;
        }
    }
}
