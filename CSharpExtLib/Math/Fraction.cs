namespace CSharpExtLib.Math
{
    public class Fraction
    {
        public int above;
        public int below;
        public static Fraction Simplify(Fraction fraction)
        {
            int maxFactor = StdApi.MaxFactor(fraction.below, fraction.above);
            fraction.below /= maxFactor;
            fraction.above /= maxFactor;
            return fraction;
        }
        public static Fraction Add(Fraction frac1, Fraction frac2)
        {
            Fraction result = new Fraction();
            result.below = frac1.below * frac2.below;
            result.above = frac1.above * frac2.below + frac2.above * frac1.below;
            return Simplify(result);
        }
        public static Fraction Sub(Fraction frac1, Fraction frac2)
        {
            frac2.above = -frac2.above;
            return Add(frac1, frac2);
        }
        public static Fraction Mul(Fraction frac1, Fraction frac2)
        {
            Fraction result = new Fraction();
            result.above = frac1.above * frac2.above;
            result.below = frac1.below * frac2.below;
            return Simplify(result);
        }
        public static Fraction Div(Fraction frac1, Fraction frac2)
        {
            int t = frac2.below;
            frac2.below = frac2.above;
            frac2.above = t;
            return Mul(frac1, frac2);
        }
        public static Fraction Square(Fraction frac)
        {
            frac.above *= frac.above;
            frac.below *= frac.below;
            return frac;
        }
        public static Fraction operator + (Fraction left, Fraction right)
        {
            return Add(left, right);
        }
        public static Fraction operator -(Fraction left, Fraction right)
        {
            return Sub(left, right);
        }

        public static Fraction operator *(Fraction left, Fraction right)
        {
            return Mul(left, right);
        }

        public static Fraction operator /(Fraction left, Fraction right)
        {
            return Div(left, right);
        }
        public static Fraction operator ++(Fraction frac)
        {
            frac.above++;
            return frac;
        }

        public static Fraction operator --(Fraction frac)
        {
            frac.above--;
            return frac;
        }
    }
}
