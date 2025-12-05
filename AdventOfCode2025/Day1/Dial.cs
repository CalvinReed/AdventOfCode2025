namespace AdventOfCode2025.Day1;

public class Dial
{
    private int position = 50;

    public int ZeroCounter { get; private set; }

    public void ApplyTurnByStop(int turn)
    {
        position += turn;
        position %= 100;
        position += 100;
        position %= 100;
        if (position == 0)
        {
            ZeroCounter++;
        }
    }

    public void ApplyTurnByTick(int turn)
    {
        var (fullTurns, remainder) = Math.DivRem(turn, 100);
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
}
