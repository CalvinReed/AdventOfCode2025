namespace AdventOfCode2025.Day2;

public readonly partial record struct IdRange(long Start, long End)
{
    public static IdRange[] ParseBatch(string input)
    {
        var matches = RangeRegex().Matches(input);
        var result = new IdRange[matches.Count];
        for (var i = 0; i < matches.Count; i++)
        {
            var match = matches[i];
            var start = long.Parse(match.Groups[1].ValueSpan);
            var end = long.Parse(match.Groups[2].ValueSpan);
            result[i] = new IdRange(start, end);
        }

        return result;
    }

    [GeneratedRegex(@"^(\d+)\1$")]
    public static partial Regex RepeatTwice();

    [GeneratedRegex(@"^(\d+)\1+$")]
    public static partial Regex RepeatMany();

    [GeneratedRegex(@"(\d+)-(\d+)")]
    private static partial Regex RangeRegex();
}
