using AdventOfCode2025.Day2;

namespace AdventOfCode2025.Test;

public class Day2(ITestOutputHelper output)
{
    [Fact]
    public async Task Part1()
    {
        var input = await ReadInput.AllText("d2");
        var total = IdRange.ParseBatch(input)
            .SelectMany(x => x.Enumerate())
            .Where(x => Misc.IsMatch(x, IdRegex.RepeatTwice()))
            .Sum();
        output.WriteLine($"{total}");
        Assert.Equal(19219508902, total);
    }

    [Fact]
    public async Task Part2()
    {
        var input = await ReadInput.AllText("d2");
        var total = IdRange.ParseBatch(input)
            .SelectMany(x => x.Enumerate())
            .Where(x => Misc.IsMatch(x, IdRegex.RepeatMany()))
            .Sum();
        output.WriteLine($"{total}");
        Assert.Equal(27180728081, total);
    }
}
