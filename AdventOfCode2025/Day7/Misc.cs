namespace AdventOfCode2025.Day7;

public static class Misc
{
    public static BeamRow Propagate(BeamRow beamRow, SplitterRow splitterRow)
    {
        var builder = ImmutableArray.CreateBuilder<bool>(beamRow.HasBeam.Length);
        builder.Count = builder.Capacity;
        var splitCount = beamRow.SplitCount;
        for (var i = 0; i < beamRow.HasBeam.Length; i++)
        {
            if (!beamRow.HasBeam[i]) continue;
            if (splitterRow.HasSplitter[i])
            {
                builder[i - 1] = true;
                builder[i + 1] = true;
                splitCount++;
            }
            else
            {
                builder[i] = true;
            }
        }

        return new BeamRow(builder.MoveToImmutable(), splitCount);
    }

    public static QuantumBeamRow Propagate(QuantumBeamRow beamRow, SplitterRow splitterRow)
    {
        var builder = ImmutableArray.CreateBuilder<long>(beamRow.BeamCount.Length);
        builder.Count = builder.Capacity;
        for (var i = 0; i < beamRow.BeamCount.Length; i++)
        {
            var count = beamRow.BeamCount[i];
            if (splitterRow.HasSplitter[i])
            {
                builder[i - 1] += count;
                builder[i + 1] += count;
            }
            else
            {
                builder[i] += count;
            }
        }

        return new QuantumBeamRow(builder.MoveToImmutable());
    }
}
