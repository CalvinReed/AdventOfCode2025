using AdventOfCode2025.Day2;

namespace AdventOfCode2025.Test;

public class Day2(ITestOutputHelper output)
{
    [Fact]
    public async Task Part1()
    {
        var input = await ReadInput.AllText("d2");
        var acc = new Accumulator();
        foreach (var range in IdRange.ParseBatch(input))
        {
            acc.Add(range, IdRegex.RepeatTwice());
        }

        output.WriteLine($"{acc.Total}");
        Assert.Equal(19219508902, acc.Total);
    }

    [Fact]
    public async Task Part2()
    {
        var input = await ReadInput.AllText("d2");
        var acc = new Accumulator();
        foreach (var range in IdRange.ParseBatch(input))
        {
            acc.Add(range, IdRegex.RepeatMany());
        }

        output.WriteLine($"{acc.Total}");
        Assert.Equal(27180728081, acc.Total);
    }
}
