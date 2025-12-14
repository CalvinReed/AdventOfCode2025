using AdventOfCode2025.Day9;

namespace AdventOfCode2025.Test;

public class Day9(ITestOutputHelper output)
{
    [Fact]
    public async Task Part1()
    {
        var input = await ReadInput.AllText("d9");
        var solver = CoordsBlock.Parse(input);
        var result = solver.MaxArea();
        output.WriteLine($"{result}");
        Assert.Equal(4759420470, result);
    }

    [Fact]
    public async Task Part2()
    {
        var input = await ReadInput.AllText("d9");
        var solver = CoordsBlock.Parse(input);
        var result = solver.MaxAreaLinear();
        output.WriteLine($"{result}");
    }
}
