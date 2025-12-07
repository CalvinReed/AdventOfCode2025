namespace AdventOfCode2025.Day7;

public record BeamRow(ImmutableArray<bool> HasBeam, int SplitCount)
{
    public static BeamRow Parse(string row)
    {
        var builder = ImmutableArray.CreateBuilder<bool>(row.Length);
        builder.Count = builder.Capacity;
        builder[row.IndexOf('S')] = true;
        return new BeamRow(builder.MoveToImmutable(), 0);
    }
}
