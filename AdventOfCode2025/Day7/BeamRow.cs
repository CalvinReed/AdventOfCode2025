using System.Collections.Immutable;

namespace AdventOfCode2025.Day7;

public record BeamRow(IImmutableSet<int> Indices, int SplitCount)
{
    public static BeamRow Parse(string row)
    {
        return new BeamRow([row.IndexOf('S')], 0);
    }
}
