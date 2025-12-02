using System.Text.RegularExpressions;

namespace AdventOfCode2025.Day2;

public static class Extension
{
    public static long SumMatching(this IdRange idRange, Regex regex)
    {
        Span<char> buffer = stackalloc char[32];
        var sum = 0L;
        for (var i = idRange.Start; i <= idRange.End; i++)
        {
            i.TryFormat(buffer, out var written);
            if (regex.IsMatch(buffer[..written]))
            {
                sum += i;
            }
        }

        return sum;
    }
}
