namespace AdventOfCode2025.Day2;

public class Accumulator
{
    public long Total { get; private set; }

    public void Add(IdRange range, Regex regex)
    {
        Span<char> buffer = stackalloc char[32];
        for (var i = range.Start; i <= range.End; i++)
        {
            i.TryFormat(buffer, out var written);
            if (regex.IsMatch(buffer[..written]))
            {
                Total += i;
            }
        }
    }
}
