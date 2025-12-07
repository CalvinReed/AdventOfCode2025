namespace AdventOfCode2025.Day7;

public record QuantumBeamRow(ImmutableArray<long> BeamCount)
{
    public static QuantumBeamRow Parse(string row)
    {
        var builder = ImmutableArray.CreateBuilder<long>(row.Length);
        builder.Count = builder.Capacity;
        builder[row.IndexOf('S')] = 1;
        return new QuantumBeamRow(builder.MoveToImmutable());
    }
}
