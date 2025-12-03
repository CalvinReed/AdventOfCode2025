using AdventOfCode2025.Day3;
using Xunit.Abstractions;

namespace AdventOfCode2025.Test;

public class Day3(ITestOutputHelper output)
{
    [Fact]
    public async Task Part1()
    {
        var banks = new List<BatteryBank>();
        await foreach (var line in ReadInput.Lines("d3"))
        {
            banks.Add(BatteryBank.Parse(line));
        }

        var sum = banks.Sum(x => x.MaxJoltage(2));
        output.WriteLine($"{sum}");
        Assert.Equal(17443, sum);
    }

    [Fact]
    public async Task Part2()
    {
        var banks = new List<BatteryBank>();
        await foreach (var line in ReadInput.Lines("d3"))
        {
            banks.Add(BatteryBank.Parse(line));
        }

        var sum = banks.Sum(x => x.MaxJoltage(12));
        output.WriteLine($"{sum}");
        Assert.Equal(172167155440541, sum);
    }
}
