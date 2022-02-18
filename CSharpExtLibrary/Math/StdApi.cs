namespace CSharpExtLibrary.Math
{
    public static class StdApi
    {
        public static bool IsEven(int a)
        {
            return a % 2 == 0;
        }
        public static int Max(int a, int b)
        {
            return a > b ? a : b;
        }
        public static int Min(int a, int b)
        {
            return a < b ? a : b;
        }
        public static int MaxFactor(int a, int b)
        {
            if (a < b)
            {
                int t = a;
                a = b;
                b = t;
            }
            while (b > 0)
            {
                int t = a % b;
                a = b;
                b = t;
            }
            return a;
        }
        public static int MinMutiple(int a, int b)
        {
            return a  * b / MaxFactor(a, b);
        }
    }
}