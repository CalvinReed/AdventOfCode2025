using System.Numerics;

namespace AdventOfCode2025.Day8;

public readonly record struct Coords(Vector3 Vector)
{
    public static Coords Parse(string line)
    {
        var split = line.Split(',');
        var vector = Vector3.Create(
            float.Parse(split[0]),
            float.Parse(split[1]),
            float.Parse(split[2]));
        return new Coords(vector);
    }

    public static float Distance(Coords a, Coords b)
    {
        return Vector3.Distance(a.Vector, b.Vector);
    }
}
