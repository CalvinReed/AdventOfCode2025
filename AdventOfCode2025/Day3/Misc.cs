namespace AdventOfCode2025.Day3;

public static class Misc
{
    public static long MaxPower(this BatteryBank bank, int pickCount)
    {
        var slice = bank.Batteries.AsSpan();
        var total = 0L;
        for (var i = pickCount - 1; i >= 0; i--)
        {
            var max = Max(slice[..^i]);
            var maxIndex = slice.IndexOf(max);
            total = total * 10 + max;
            slice = slice[(maxIndex + 1)..];
        }

        return total;
    }

    private static int Max(ReadOnlySpan<int> span)
    {
        var max = span[0];
        foreach (var i in span[1..])
        {
            max = Math.Max(max, i);
        }

        return max;
    }
}
