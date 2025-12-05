using AdventOfCode2025.Day5;

namespace AdventOfCode2025.Test;

public class Day5(ITestOutputHelper output)
{
    [Fact]
    public async Task Part1()
    {
        var input = await ReadInput.AllText("d5");
        var ranges = ParseInput.Ranges(input);
        var ids = ParseInput.Ids(input);
        var count = ids.Count(ranges.IsFresh);
        output.WriteLine($"{count}");
        Assert.Equal(712, count);
    }

    [Fact]
    public async Task Part2()
    {
        var input = await ReadInput.AllText("d5");
        var ranges = ParseInput.Ranges(input);
        var count = ranges.RangeTotal();
        output.WriteLine($"{count}");
        Assert.Equal(332998283036769, count);
    }
}
