using AdventOfCode2025.Day3;
using Xunit.Abstractions;

namespace AdventOfCode2025.Test;

public class Day3(ITestOutputHelper output)
{
    [Fact]
    public async Task Part1()
    {
        var acc = new Accumulator();
        await foreach (var bank in ReadInput.Lines("d3").Select(BatteryBank.Parse))
        {
            acc.Add(bank, 2);
        }

        output.WriteLine($"{acc.Total}");
        Assert.Equal(17443, acc.Total);
    }

    [Fact]
    public async Task Part2()
    {
        var acc = new Accumulator();
        await foreach (var bank in ReadInput.Lines("d3").Select(BatteryBank.Parse))
        {
            acc.Add(bank, 12);
        }

        output.WriteLine($"{acc.Total}");
        Assert.Equal(172167155440541, acc.Total);
    }
}
