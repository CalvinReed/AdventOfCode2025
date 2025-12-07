using System.Collections.Immutable;

namespace AdventOfCode2025.Day7;

public static class RowOperation
{
    public static BeamRow Progress(BeamRow beamRow, SplitterRow splitterRow)
    {
        var builder = ImmutableHashSet.CreateBuilder<int>();
        var splitCount = beamRow.SplitCount;
        foreach (var i in beamRow.Indices)
        {
            if (splitterRow.Indices.Contains(i))
            {
                builder.Add(i - 1);
                builder.Add(i + 1);
                splitCount++;
            }
            else
            {
                builder.Add(i);
            }
        }

        return new BeamRow(builder.ToImmutable(), splitCount);
    }

    public static QuantumBeamRow Progress(QuantumBeamRow beamRow, SplitterRow splitterRow)
    {
        var builder = ImmutableDictionary.CreateBuilder<int, long>();
        foreach (var (i, count) in beamRow.Indices)
        {
            if (splitterRow.Indices.Contains(i))
            {
                builder.AddCount(i - 1, count);
                builder.AddCount(i + 1, count);
            }
            else
            {
                builder.AddCount(i, count);
            }
        }

        return new QuantumBeamRow(builder.ToImmutable());
    }

    private static void AddCount(this ImmutableDictionary<int, long>.Builder builder, int i, long count)
    {
        if (!builder.TryAdd(i, count))
        {
            builder[i] += count;
        }
    }
}
