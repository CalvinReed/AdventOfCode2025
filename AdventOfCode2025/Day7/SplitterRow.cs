namespace AdventOfCode2025.Day7;

public record SplitterRow(ImmutableArray<bool> HasSplitter)
{
    public static SplitterRow Parse(string row)
    {
        var builder = ImmutableArray.CreateBuilder<bool>(row.Length);
        foreach (var ch in row)
        {
            builder.Add(ch == '^');
        }

        return new SplitterRow(builder.MoveToImmutable());
    }
}
