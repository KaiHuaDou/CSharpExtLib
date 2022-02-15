namespace CSharpExtLibrary.Math
{
    public static class StdApi
    {
        public static bool IsEven(int number)
        {
            return number % 2 == 0;
        }
        public static int Max(int a, int b)
        {
            return a > b ? a : b;
        }
        public static int Min(int a, int b)
        {
            return a < b ? a : b;
        }
    }
}
