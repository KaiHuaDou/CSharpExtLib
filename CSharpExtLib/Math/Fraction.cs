using System;
using System.Runtime.Serialization;

namespace CSharpExtLib.Math;

/// <summary>
/// 表示分数的类
/// </summary>
[Serializable]
public class Fraction : ISerializable
{
    private int _below;

    /// <summary>
    /// 分子
    /// </summary>
    public int Above { get; set; }

    /// <summary>
    /// 分母
    /// </summary>
    public int Below
    {
        get => _below;
        set => _below = value != 0 ? value : throw new DivideByZeroException( );
    }

    /// <summary>
    /// 初始化比值为 0 的实例
    /// </summary>
    public Fraction( )
    {
        Above = 0;
        Below = 1;
    }

    /// <summary>
    /// 初始化比值为 <paramref name="value"/> 的实例
    /// </summary>
    /// <param name="value">分数的值</param>
    public Fraction(int value)
    {
        Above = 1;
        Below = value;
    }

    /// <summary>
    /// 初始化分子为 <paramref name="a"/>，分母为 <paramref name="b"/> 的实例
    /// </summary>
    /// <param name="a">分子</param>
    /// <param name="b">分母</param>
    public Fraction(int a, int b)
    {
        Above = a;
        Below = b;
    }

    /// <summary>
    /// 简化分数至最简形式
    /// </summary>
    /// <returns>最简形式的分数</returns>
    public Fraction Simplify( )
    {
        int maxFactor = Universal.MaxFactor(Below, Above);
        return new Fraction(Above /= maxFactor, Below /= maxFactor);
    }

    public static Fraction Add(Fraction a, Fraction b)
    {
        Fraction result = new( )
        {
            Below = a.Below * b.Below,
            Above = a.Above * b.Below + b.Above * a.Below
        };
        return result.Simplify( );
    }

    public static Fraction Plus(Fraction a, Fraction b) => a + b;

    public static Fraction Subtract(Fraction a, Fraction b)
        => Add(a, -b);

    public static Fraction Multiply(Fraction a, Fraction b)
    {
        Fraction result = new( )
        {
            Above = a.Above * b.Above,
            Below = a.Below * b.Below
        };
        return result.Simplify( );
    }
    public static Fraction Divide(Fraction a, Fraction b)
    {
        (b.Below, b.Above) = (b.Above, b.Below);
        return Multiply(a, b);
    }

    public static Fraction Square(Fraction f)
    {
        f.Above *= f.Above;
        f.Below *= f.Below;
        return f;
    }

    public override bool Equals(object obj)
        => this == (Fraction) obj;

    public override int GetHashCode( )
        => ((double) Above / Below).GetHashCode( );

    public override string ToString( )
        => Above + "/" + Below;

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("above", Above);
        info.AddValue("below", Below);
    }

    public static Fraction operator +(Fraction l, Fraction r) => Add(l, r);
    public static Fraction operator -(Fraction l, Fraction r) => Subtract(l, r);
    public static Fraction operator *(Fraction l, Fraction r) => Multiply(l, r);
    public static Fraction operator /(Fraction l, Fraction r) => Divide(l, r);

    public static Fraction operator +(Fraction frac) => frac;

    public static Fraction operator -(Fraction frac)
    {
        frac.Above = -frac.Above;
        return frac;
    }

    public static Fraction operator ++(Fraction frac)
    {
        frac.Above += frac.Below;
        return frac;
    }

    public static Fraction operator --(Fraction frac)
    {
        frac.Above -= frac.Below;
        return frac;
    }

    public static bool operator ==(Fraction l, Fraction r)
        => l.Below == r.Below && l.Above == r.Above;

    public static bool operator !=(Fraction l, Fraction r)
        => !(l == r);

    public static Fraction Plus(Fraction item) => throw new NotImplementedException( );

    protected Fraction(SerializationInfo serializationInfo, StreamingContext streamingContext)
    {
        throw new NotImplementedException( );
    }

    public static Fraction Negate(Fraction item) => throw new NotImplementedException( );

    public static Fraction Increment(Fraction item) => throw new NotImplementedException( );

    public static Fraction Decrement(Fraction item) => throw new NotImplementedException( );
}
