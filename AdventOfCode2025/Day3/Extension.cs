namespace AdventOfCode2025.Day3;

public static class Extension
{
    public static long MaxJoltage(this BatteryBank bank, int count)
    {
        var slice = bank.Batteries.AsSpan();
        var total = 0L;
        for (var i = count - 1; i >= 0; i--)
        {
            var max = slice[..^i].Max();
            var maxIndex = slice.IndexOf(max);
            total = total * 10 + max;
            slice = slice[(maxIndex + 1)..];
        }

        return total;
    }

    private static int Max(this ReadOnlySpan<int> span)
    {
        var max = span[0];
        foreach (var i in span[1..])
        {
            max = Math.Max(max, i);
        }

        return max;
    }
}
