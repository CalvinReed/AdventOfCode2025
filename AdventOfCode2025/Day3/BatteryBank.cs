using System.Collections.Immutable;

namespace AdventOfCode2025.Day3;

public record BatteryBank(ImmutableArray<int> Batteries)
{
    public static BatteryBank Parse(string str)
    {
        var builder = ImmutableArray.CreateBuilder<int>(str.Length);
        foreach (var ch in str)
        {
            builder.Add(ch - '0');
        }

        return new BatteryBank(builder.MoveToImmutable());
    }
}
