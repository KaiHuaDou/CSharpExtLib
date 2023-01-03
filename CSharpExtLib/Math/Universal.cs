namespace CSharpExtLib.Math
{
    public static class Universal
    {
        public static bool IsEven(int n)
        {
            return n % 2 == 0;
        }
        public static bool IsOdd(int n)
        {
            return n % 2 != 0;
        }
        public static int MaxFactor(int a, int b)
        {
            if (a < b)
                return MaxFactor(b, a);
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
            return a * b / MaxFactor(a, b);
        }
    }
}