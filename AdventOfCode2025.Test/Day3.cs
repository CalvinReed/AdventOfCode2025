using AdventOfCode2025.Day3;

namespace AdventOfCode2025.Test;

public class Day3(ITestOutputHelper output)
{
    [Fact]
    public async Task Part1()
    {
        var lines = await ReadInput.AllLines("d3");
        var acc = new Accumulator();
        foreach (var bank in lines.Select(BatteryBank.Parse))
        {
            acc.Add(bank, 2);
        }

        output.WriteLine($"{acc.Total}");
        Assert.Equal(17443, acc.Total);
    }

    [Fact]
    public async Task Part2()
    {
        var lines = await ReadInput.AllLines("d3");
        var acc = new Accumulator();
        foreach (var bank in lines.Select(BatteryBank.Parse))
        {
            acc.Add(bank, 12);
        }

        output.WriteLine($"{acc.Total}");
        Assert.Equal(172167155440541, acc.Total);
    }
}
