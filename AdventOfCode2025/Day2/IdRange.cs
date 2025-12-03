namespace AdventOfCode2025.Day2;

public record IdRange(long Start, long End)
{
    public static IdRange[] ParseBatch(string input)
    {
        var matches = IdRegex.Range().Matches(input);
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
}
