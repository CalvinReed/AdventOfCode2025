using AdventOfCode2025.Day6;

namespace AdventOfCode2025.Test;

public class Day6(ITestOutputHelper output)
{
    [Fact]
    public async Task Part1()
    {
        var input = await ReadInput.AllText("d6");
        var grandTotal = SquidMath.GrandTotal1(input);
        output.WriteLine($"{grandTotal}");
        Assert.Equal(6299564383938, grandTotal);
    }

    [Fact]
    public async Task Part2()
    {
        var lines = await ReadInput.AllLines("d6");
        var grandTotal = SquidMath.GrandTotal2(lines);
        output.WriteLine($"{grandTotal}");
        Assert.Equal(11950004808442, grandTotal);
    }
}
