namespace AdventOfCode2025.Day2;

public static class Misc
{
    public static bool IsMatch(long i, Regex regex)
    {
        Span<char> buffer = stackalloc char[32];
        i.TryFormat(buffer, out var written);
        return regex.IsMatch(buffer[..written]);
    }

    public static IEnumerable<long> Enumerate(this IdRange range)
    {
        for (var i = range.Start; i <= range.End; i++)
        {
            yield return i;
        }
    }
}
