namespace AdventOfCode2025.Day8;

public class LinkSet(int length)
{
    private readonly List<int>[] sets = Enumerable.Range(0, length)
        .Select<int, List<int>>(x => [x])
        .ToArray();

    public bool Link(int i, int k)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(i);
        ArgumentOutOfRangeException.ThrowIfNegative(k);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(i, length);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(k, length);
        if (ReferenceEquals(sets[i], sets[k]))
        {
            return false;
        }

        var (gt, lt) = sets[i].Count >= sets[k].Count ? (i, k) : (k, i);
        var set = sets[gt];
        set.AddRange(sets[lt]);
        foreach (var index in set)
        {
            sets[index] = set;
        }

        return true;
    }

    public long ProductHighest(int count)
    {
        return sets
            .Distinct(ReferenceEqualityComparer.Instance)
            .Cast<ICollection<int>>()
            .Select(x => x.Count)
            .OrderDescending()
            .Take(count)
            .Aggregate(1L, (l, i) => l * i);
    }
}
