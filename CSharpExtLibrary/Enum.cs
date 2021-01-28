namespace CSharpExtLibrary
{
    public enum Possibility
    {
        Impossible = 0,
        OneOfTenpossible = 10,
        QuarterPossible = 25,
        Possible = 50,
        TripleQuarter = 75,
        Certain = 100
    }
    public enum PublicLevel
    {
        Sealed = 1,
        Private = 2,
        Internal = 3,
        Protected = 4,
        Public = 5,
        Abstract = 6,
        Everyone = int.MaxValue
    }
}
