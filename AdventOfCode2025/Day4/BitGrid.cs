namespace AdventOfCode2025.Day4;

public class BitGrid
{
    private readonly bool[,] array;

    private BitGrid(int xLength, int yLength)
    {
        array = new bool[xLength, yLength];
    }

    public int XLength => array.GetLength(0);
    public int YLength => array.GetLength(1);

    public bool this[int x, int y]
    {
        get => array[x, y];
        set => array[x, y] = value;
    }

    public static BitGrid Parse(string[] input)
    {
        var grid = new BitGrid(input[0].Length, input.Length);
        for (var y = 0; y < grid.YLength; y++)
        for (var x = 0; x < grid.XLength; x++)
        {
            grid[x, y] = input[y][x] == '@';
        }

        return grid;
    }
}
