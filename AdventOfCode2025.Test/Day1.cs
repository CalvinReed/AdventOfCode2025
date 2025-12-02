using AdventOfCode2025.Day1;
using Xunit.Abstractions;

namespace AdventOfCode2025.Test;

public class Day1(ITestOutputHelper output)
{
    [Fact]
    public async Task Part1()
    {
        var dial = new Dial();
        await foreach (var line in ReadInput.Lines("d1"))
        {
            dial.ApplyTurnByStop(line);
        }

        output.WriteLine($"{dial.ZeroCounter}");
        Assert.Equal(992, dial.ZeroCounter);
    }

    [Fact]
    public async Task Part2()
    {
        var dial = new Dial();
        await foreach (var line in ReadInput.Lines("d1"))
        {
            dial.ApplyTurnByTick(line);
        }

        output.WriteLine($"{dial.ZeroCounter}");
        Assert.Equal(6133, dial.ZeroCounter);
    }
}
