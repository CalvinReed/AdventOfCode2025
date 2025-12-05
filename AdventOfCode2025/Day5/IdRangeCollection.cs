namespace AdventOfCode2025.Day5;

public class IdRangeCollection
{
    private readonly long[] starts;
    private readonly long[] ends;

    internal IdRangeCollection(long[] starts, long[] ends)
    {
        this.starts = starts;
        this.ends = ends;
    }

    public bool IsFresh(long id)
    {
        var binarySearch = ends.BinarySearch(id);
        var index = binarySearch >= 0 ? binarySearch : ~binarySearch;
        for (var i = index; i < starts.Length; i++)
        {
            if (id >= starts[i])
            {
                return true;
            }
        }

        return false;
    }

    public long RangeTotal()
    {
        var total = 0L;
        for (var i = 0; i < starts.Length; i++)
        {
            var start = starts[i];
            var end = ends[i];
            for (var k = i + 1; k < starts.Length; k++)
            {
                if (starts[k] > end)
                {
                    break;
                }

                start = Math.Min(start, starts[k]);
                end = Math.Max(end, ends[k]);
                i = k;
            }

            total += end - start + 1;
        }

        return total;
    }
}
