using System.Collections.Immutable;
using AdventOfCode2025.Day9;

namespace AdventOfCode2025.Test;

public class Day9(ITestOutputHelper output)
{
    [Fact]
    public async Task Part1()
    {
        var lines = await ReadInput.AllLines("d9");
        var array = lines.Select(Coords.Parse).ToImmutableArray();
        var solver = new ProblemSolver(array);
        var result = solver.Part1();
        output.WriteLine($"{result}");
        Assert.Equal(4759420470, result);
    }
}
