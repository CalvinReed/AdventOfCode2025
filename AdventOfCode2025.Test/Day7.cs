using AdventOfCode2025.Day7;

namespace AdventOfCode2025.Test;

public class Day7(ITestOutputHelper output)
{
    [Fact]
    public async Task Part1()
    {
        var lines = await ReadInput.AllLines("d7");
        var seed = BeamRow.Parse(lines[0]);
        var result = lines
            .Skip(1)
            .Select(SplitterRow.Parse)
            .Aggregate(seed, RowOperation.Progress);
        output.WriteLine($"{result.SplitCount}");
        Assert.Equal(1562, result.SplitCount);
    }

    [Fact]
    public async Task Part2()
    {
        var lines = await ReadInput.AllLines("d7");
        var seed = QuantumBeamRow.Parse(lines[0]);
        var result = lines
            .Skip(1)
            .Select(SplitterRow.Parse)
            .Aggregate(seed, RowOperation.Progress);
        var sum = result.Indices.Values.Sum();
        output.WriteLine($"{sum}");
        Assert.Equal(24292631346665, sum);
    }
}
