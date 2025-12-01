using System.Diagnostics;
using System.Text.RegularExpressions;

namespace AdventOfCode2025.Day1;

public partial class Part1
{
    private int position = 50;

    public int ZeroCounter { get; private set; }

    public void ApplyTurn(string turn)
    {
        position += ParseTurn(turn);
        position %= 100;
        position += 100;
        position %= 100;
        if (position == 0)
        {
            ZeroCounter++;
        }
    }

    private static int ParseTurn(string turn)
    {
        var match = TurnRegex().Match(turn);
        if (!match.Success)
        {
            throw new FormatException();
        }

        var inc = int.Parse(match.Groups[2].ValueSpan);
        return match.Groups[1].ValueSpan switch
        {
            "L" => -inc,
            "R" => inc,
            _ => throw new UnreachableException()
        };
    }

    [GeneratedRegex(@"^([LR])(\d+)$")]
    private static partial Regex TurnRegex();
}
