using System;
using System.Runtime.Serialization;

namespace CSharpExtLib.Math
{
    [Serializable]
    public class Fraction : ISerializable
    {
        private int _below;
        public int above { get; set; }
        public int below
        {
            get { return _below; }
            set
            {
                if (value != 0)
                    _below = value;
                else
                    throw new DivideByZeroException( );
            }
        }
        public Fraction( )
        {
            above = 0;
            below = 1;
        }
        public Fraction(int a, int b)
        {
            above = a;
            below = b;
        }
        public Fraction Simplify( )
        {
            int maxFactor = Universal.MaxFactor(this.below, this.above);
            return new Fraction(above /= maxFactor, below /= maxFactor);
        }
        public static Fraction Add(Fraction a, Fraction b)
        {
            Fraction result = new Fraction( );
            result.below = a.below * b.below;
            result.above = a.above * b.below + b.above * a.below;
            return result.Simplify( );
        }
        public static Fraction Sub(Fraction a, Fraction b)
        {
            return Add(a, -b);
        }
        public static Fraction Mul(Fraction a, Fraction b)
        {
            Fraction result = new Fraction( );
            result.above = a.above * b.above;
            result.below = a.below * b.below;
            return result.Simplify( );
        }
        public static Fraction Div(Fraction a, Fraction b)
        {
            int t = b.below;
            b.below = b.above;
            b.above = t;
            return Mul(a, b);
        }
        public static Fraction Square(Fraction f)
        {
            f.above *= f.above;
            f.below *= f.below;
            return f;
        }
        public override bool Equals(object obj)
        {
            return this == (Fraction) obj;
        }
        public override int GetHashCode( )
        {
            return ((double) above / below).GetHashCode( );
        }
        public override string ToString( )
        {
            return above + "/" + below;
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("above", above);
            info.AddValue("below", below);
        }
        public static Fraction operator +(Fraction l, Fraction r)
        {
            return Add(l, r);
        }
        public static Fraction operator -(Fraction l, Fraction r)
        {
            return Sub(l, r);
        }
        public static Fraction operator -(Fraction frac)
        {
            frac.above = -frac.above;
            return frac;
        }
        public static Fraction operator *(Fraction l, Fraction r)
        {
            return Mul(l, r);
        }
        public static Fraction operator /(Fraction l, Fraction r)
        {
            return Div(l, r);
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
        public static bool operator ==(Fraction l, Fraction r)
        {
            return l.below == r.below && l.above == r.above;
        }
        public static bool operator !=(Fraction l, Fraction r)
        {
            return !(l == r);
        }
    }
}
