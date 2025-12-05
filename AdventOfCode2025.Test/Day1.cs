using AdventOfCode2025.Day1;

namespace AdventOfCode2025.Test;

public class Day1(ITestOutputHelper output)
{
    [Fact]
    public async Task Part1()
    {
        var input = await ReadInput.AllText("d1");
        var turns = ParseInput.Turns(input);
        var dial = new Dial();
        foreach (var turn in turns)
        {
            dial.ApplyTurnByStop(turn);
        }

        output.WriteLine($"{dial.ZeroCounter}");
        Assert.Equal(992, dial.ZeroCounter);
    }

    [Fact]
    public async Task Part2()
    {
        var input = await ReadInput.AllText("d1");
        var turns = ParseInput.Turns(input);
        var dial = new Dial();
        foreach (var turn in turns)
        {
            dial.ApplyTurnByTick(turn);
        }

        output.WriteLine($"{dial.ZeroCounter}");
        Assert.Equal(6133, dial.ZeroCounter);
    }
}
