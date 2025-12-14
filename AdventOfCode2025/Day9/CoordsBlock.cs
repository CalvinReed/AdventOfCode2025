using System.Globalization;
using Coords = (int X, int Y);

namespace AdventOfCode2025.Day9;

public sealed partial class CoordsBlock
{
    private readonly Coords[] redTiles;
    private readonly Coords lower, upper;

    private CoordsBlock(Coords[] redTiles)
    {
        this.redTiles = redTiles;
        lower = (
            redTiles.Min(a => a.X),
            redTiles.Min(a => a.Y));
        upper = (
            redTiles.Max(a => a.X),
            redTiles.Max(a => a.Y));
    }

    public long MaxArea()
    {
        var result = long.MinValue;
        for (var i = 0; i < redTiles.Length; i++)
        for (var k = i + 1; k < redTiles.Length; k++)
        {
            result = Math.Max(result, Area(i, k));
        }

        return result;
    }

    public long MaxAreaLinear()
    {
        throw new NotImplementedException();
    }

    private long Area(int i, int k)
    {
        var x = Math.Abs(redTiles[i].X - redTiles[k].X) + 1;
        var y = Math.Abs(redTiles[i].Y - redTiles[k].Y) + 1;
        return Math.BigMul(x, y);
    }

    private bool Aligned(int i, int k)
    {
        return redTiles[i].X == redTiles[k].X ||
               redTiles[i].Y == redTiles[k].Y;
    }

    public static CoordsBlock Parse(string input)
    {
        var matches = CoordsRegex().Matches(input);
        var arr = new Coords[matches.Count];
        for (var i = 0; i < matches.Count; i++)
        {
            var x = int.Parse(matches[i].Groups[1].ValueSpan, NumberStyles.None);
            var y = int.Parse(matches[i].Groups[2].ValueSpan, NumberStyles.None);
            arr[i] = (x, y);
        }

        return new CoordsBlock(arr);
    }

    [GeneratedRegex(@"(\d+),(\d+)")]
    private static partial Regex CoordsRegex();
}
