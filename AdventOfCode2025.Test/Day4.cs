using AdventOfCode2025.Day4;
using Xunit.Abstractions;

namespace AdventOfCode2025.Test;

public class Day4(ITestOutputHelper output)
{
    [Fact]
    public async Task Part1()
    {
        var input = await ReadInput.AllLines("d4");
        var grid = BitGrid.Parse(input);
        var count = grid.CountAccessible();
        output.WriteLine($"{count}");
        Assert.Equal(1569, count);
    }

    [Fact]
    public async Task Part2()
    {
        var input = await ReadInput.AllLines("d4");
        var grid = BitGrid.Parse(input);
        var count = grid.RemoveAll();
        output.WriteLine($"{count}");
        Assert.Equal(9280, count);
    }
}
