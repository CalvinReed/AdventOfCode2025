namespace AdventOfCode2025.Day9;

public sealed class ProblemSolver(ImmutableArray<Coords> array)
{
    private readonly SymmetricMatrix<long> areas = InitAreas(array);

    public long Part1()
    {
        return Max(areas.Items);
    }

    private static long Max(ReadOnlySpan<long> span)
    {
        var value = long.MinValue;
        foreach (var l in span)
        {
            if (l > value)
            {
                value = l;
            }
        }

        return value;
    }

    private static SymmetricMatrix<long> InitAreas(ImmutableArray<Coords> array)
    {
        var matrix = new SymmetricMatrix<long>(array.Length);
        for (var y = 0; y < array.Length; y++)
        for (var x = y; x < array.Length; x++)
        {
            matrix[x, y] = Coords.Area(array[x], array[y]);
        }

        return matrix;
    }
}
