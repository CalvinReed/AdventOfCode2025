using System.Collections.Immutable;

namespace AdventOfCode2025.Day7;

public record SplitterRow(IImmutableSet<int> Indices)
{
    public static SplitterRow Parse(string row)
    {
        return new SplitterRow(AllIndices(row, '^'));
    }

    private static ImmutableHashSet<int> AllIndices(ReadOnlySpan<char> row, char ch)
    {
        var builder = ImmutableHashSet.CreateBuilder<int>();
        var slice = row;
        while (!slice.IsEmpty)
        {
            var i = slice.IndexOf(ch);
            if (i >= 0)
            {
                builder.Add(i + row.Length - slice.Length);
                slice = slice[(i + 1)..];
            }
            else
            {
                slice = ReadOnlySpan<char>.Empty;
            }
        }

        return builder.ToImmutable();
    }
}
