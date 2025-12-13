using System.Runtime.Intrinsics;

namespace AdventOfCode2025.Day9;

public readonly record struct Coords(Vector64<int> Vector)
{
    public static Coords Parse(string line)
    {
        var split = line.Split(',');
        var x = int.Parse(split[0]);
        var y = int.Parse(split[1]);
        return new Coords(Vector64.Create(x, y));
    }

    public static long Area(Coords a, Coords b)
    {
        var vector = Vector64.Abs(a.Vector - b.Vector) + Vector64<int>.One;
        return Math.BigMul(vector[0], vector[1]);
    }
}
