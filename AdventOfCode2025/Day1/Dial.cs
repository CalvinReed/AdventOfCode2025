using System.Diagnostics;

namespace AdventOfCode2025.Day1;

public partial class Dial
{
    private int position = 50;

    public int ZeroCounter { get; private set; }

    public void ApplyTurnByStop(string turn)
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

    public void ApplyTurnByTick(string turn)
    {
        var inc = ParseTurn(turn);
        var (fullTurns, remainder) = Math.DivRem(inc, 100);
        ZeroCounter += Math.Abs(fullTurns);
        var nextPosition = position + remainder;
        switch (nextPosition)
        {
            case 0:
            case >= 100:
            case < 0 when position > 0:
                ZeroCounter++;
                break;
        }

        position = (nextPosition + 100) % 100;
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
