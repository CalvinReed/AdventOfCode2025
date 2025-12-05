using System.Diagnostics;

namespace AdventOfCode2025.Day1;

public static partial class ParseInput
{
    public static int[] Turns(string input)
    {
        var matches = TurnRegex().Matches(input);
        var result = new int[matches.Count];
        for (var i = 0; i < matches.Count; i++)
        {
            var value = int.Parse(matches[i].Groups[2].ValueSpan);
            result[i] = matches[i].Groups[1].ValueSpan switch
            {
                "L" => -value,
                "R" => value,
                _ => throw new UnreachableException()
            };
        }

        return result;
    }

    [GeneratedRegex(@"([LR])(\d+)")]
    private static partial Regex TurnRegex();
}
