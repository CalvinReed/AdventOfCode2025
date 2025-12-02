using AdventOfCode2025.Day2;
using Xunit.Abstractions;

namespace AdventOfCode2025.Test;

public class Day2(ITestOutputHelper output)
{
    [Fact]
    public async Task Part1()
    {
        var input = await ReadInput.AllText("d2");
        var ranges = IdRange.ParseBatch(input);
        var sum = ranges.Sum(x => x.SumMatching(IdRange.RepeatTwice()));
        output.WriteLine($"{sum}");
        Assert.Equal(19219508902L, sum);
    }

    [Fact]
    public async Task Part2()
    {
        var input = await ReadInput.AllText("d2");
        var ranges = IdRange.ParseBatch(input);
        var sum = ranges.Sum(x => x.SumMatching(IdRange.RepeatMany()));
        output.WriteLine($"{sum}");
        Assert.Equal(27180728081L, sum);
    }
}
