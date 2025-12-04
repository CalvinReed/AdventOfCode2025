namespace AdventOfCode2025.Day4;

public static class Extension
{
    private const int Threshold = 4;

    extension(BitGrid grid)
    {
        public int CountAccessible()
        {
            var count = 0;
            for (var y = 0; y < grid.YLength; y++)
            for (var x = 0; x < grid.XLength; x++)
            {
                if (grid[x, y] && grid.CountSetAdjacent(x, y) < Threshold)
                {
                    count++;
                }
            }

            return count;
        }

        public int RemoveAll()
        {
            int total = 0, count;
            do
            {
                count = grid.RemoveAccessible();
                total += count;
            } while (count > 0);

            return total;
        }

        private int RemoveAccessible()
        {
            var count = 0;
            for (var y = 0; y < grid.YLength; y++)
            for (var x = 0; x < grid.XLength; x++)
            {
                if (!grid[x, y] || grid.CountSetAdjacent(x, y) >= Threshold)
                {
                    continue;
                }

                grid[x, y] = false;
                count++;
            }

            return count;
        }

        private int CountSetAdjacent(int x, int y)
        {
            var xStart = Math.Max(x - 1, 0);
            var yStart = Math.Max(y - 1, 0);
            var xLimit = Math.Min(x + 2, grid.XLength);
            var yLimit = Math.Min(y + 2, grid.YLength);
            var count = 0;
            for (var yCurrent = yStart; yCurrent < yLimit; yCurrent++)
            for (var xCurrent = xStart; xCurrent < xLimit; xCurrent++)
            {
                if ((xCurrent != x || yCurrent != y) && grid[xCurrent, yCurrent])
                {
                    count++;
                }
            }

            return count;
        }
    }
}
