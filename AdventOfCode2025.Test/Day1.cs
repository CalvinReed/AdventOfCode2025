using AdventOfCode2025.Day1;
using Xunit.Abstractions;

namespace AdventOfCode2025.Test;

public class Day1(ITestOutputHelper output)
{
    [Fact]
    public async Task Part1()
    {
        var part1 = new Part1();
        await foreach (var line in ReadInput.Lines("d1"))
        {
            part1.ApplyTurn(line);
        }

        output.WriteLine($"{part1.ZeroCounter}");
        Assert.Equal(992, part1.ZeroCounter);
    }

    [Fact]
    public async Task Part2()
    {
        var part2 = new Part2();
        await foreach (var line in ReadInput.Lines("d1"))
        {
            part2.ApplyTurn(line);
        }

        output.WriteLine($"{part2.ZeroCounter}");
        Assert.Equal(6133, part2.ZeroCounter);
    }
}
