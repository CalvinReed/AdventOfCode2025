namespace AdventOfCode2025.Day5;

public static partial class ParseInput
{
    public static IdRangeCollection Ranges(string input)
    {
        var matches = Range().Matches(input);
        var starts = new long[matches.Count];
        var ends = new long[matches.Count];
        for (var i = 0; i < matches.Count; i++)
        {
            starts[i] = long.Parse(matches[i].Groups[1].ValueSpan);
            ends[i] = long.Parse(matches[i].Groups[2].ValueSpan);
        }

        ends.Sort(starts);
        return new IdRangeCollection(starts, ends);
    }

    public static long[] Ids(string input)
    {
        var matches = Number().Matches(input);
        var ids = new long[matches.Count];
        for (var i = 0; i < matches.Count; i++)
        {
            ids[i] = long.Parse(matches[i].ValueSpan);
        }

        return ids;
    }

    [GeneratedRegex(@"^(\d+)-(\d+)$", RegexOptions.Multiline)]
    private static partial Regex Range();

    [GeneratedRegex(@"^(\d+)$", RegexOptions.Multiline)]
    private static partial Regex Number();
}
