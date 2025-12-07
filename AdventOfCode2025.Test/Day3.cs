using AdventOfCode2025.Day3;

namespace AdventOfCode2025.Test;

public class Day3(ITestOutputHelper output)
{
    [Fact]
    public async Task Part1()
    {
        var lines = await ReadInput.AllLines("d3");
        var total = lines
            .Select(BatteryBank.Parse)
            .Sum(x => x.MaxPower(2));
        output.WriteLine($"{total}");
        Assert.Equal(17443, total);
    }

    [Fact]
    public async Task Part2()
    {
        var lines = await ReadInput.AllLines("d3");
        var total = lines
            .Select(BatteryBank.Parse)
            .Sum(x => x.MaxPower(12));
        output.WriteLine($"{total}");
        Assert.Equal(172167155440541, total);
    }
}
