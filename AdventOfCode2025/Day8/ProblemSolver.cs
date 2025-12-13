namespace AdventOfCode2025.Day8;

public class ProblemSolver
{
    private readonly ImmutableArray<Coords> array;
    private readonly SymmetricMatrix<float> distances;
    private readonly LinkSet links;
    private readonly Queue<int> priority;

    public ProblemSolver(ImmutableArray<Coords> array)
    {
        this.array = array;
        distances = InitDistances(array);
        links = new LinkSet(array.Length);
        priority = InitPriority(distances.Items);
    }

    public long Part1()
    {
        for (var i = 0; i < 1000; i++)
        {
            LinkClosest();
        }

        return links.ProductHighest(3);
    }

    public long Part2()
    {
        (int I, int K) lastLinked = (-1, -1);
        while (priority.Count > 0)
        {
            lastLinked = LinkClosest() ?? lastLinked;
        }

        var a = Convert.ToInt32(array[lastLinked.I].Vector.X);
        var b = Convert.ToInt32(array[lastLinked.K].Vector.X);
        return Math.BigMul(a, b);
    }

    private (int, int)? LinkClosest()
    {
        var i = priority.Dequeue();
        var tuple = distances.GetCoordinates(i);
        return links.Link(tuple.X, tuple.Y) ? tuple : null;
    }

    private static SymmetricMatrix<float> InitDistances(ImmutableArray<Coords> array)
    {
        var matrix = new SymmetricMatrix<float>(array.Length);
        for (var y = 0; y < array.Length; y++)
        for (var x = y; x < array.Length; x++)
        {
            matrix[x, y] = Coords.Distance(array[x], array[y]);
        }

        return matrix;
    }

    private static Queue<int> InitPriority(Span<float> distances)
    {
        var indexes = Indexes(distances.Length);
        distances.Sort(indexes);
        var length = distances.TrimStart(0).Length;
        var result = new Queue<int>(length);
        foreach (var i in indexes.AsSpan(^length..))
        {
            result.Enqueue(i);
        }

        // Put everything back to initial order
        for (var i = 0; i < indexes.Length; i++)
        {
            while (indexes[i] != i)
            {
                var k = indexes[i];
                (distances[i], distances[k]) = (distances[k], distances[i]);
                (indexes[i], indexes[k]) = (indexes[k], indexes[i]);
            }
        }

        return result;
    }

    private static int[] Indexes(int length)
    {
        var arr = new int[length];
        for (var i = 0; i < arr.Length; i++)
        {
            arr[i] = i;
        }

        return arr;
    }
}
