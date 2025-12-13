using System.Collections.Immutable;
using AdventOfCode2025.Day8;

namespace AdventOfCode2025.Test;

public class Day8(ITestOutputHelper output)
{
    [Fact]
    public async Task Part1()
    {
        var lines = await ReadInput.AllLines("d8");
        var coords = lines.Select(Coords.Parse).ToImmutableArray();
        var problemSolver = new ProblemSolver(coords);
        var result = problemSolver.Part1();
        output.WriteLine($"{result}");
        Assert.Equal(123234, result);
    }

    [Fact]
    public async Task Part2()
    {
        var lines = await ReadInput.AllLines("d8");
        var coords = lines.Select(Coords.Parse).ToImmutableArray();
        var problemSolver = new ProblemSolver(coords);
        var result = problemSolver.Part2();
        output.WriteLine($"{result}");
        Assert.Equal(9259958565, result);
    }
}
