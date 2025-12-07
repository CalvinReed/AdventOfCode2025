using System.Collections.Immutable;

namespace AdventOfCode2025.Day7;

public record QuantumBeamRow(ImmutableDictionary<int, long> Indices)
{
    public static QuantumBeamRow Parse(string row)
    {
        var i = row.IndexOf('S');
        var pair = KeyValuePair.Create(i, 1L);
        return new QuantumBeamRow([pair]);
    }
}
