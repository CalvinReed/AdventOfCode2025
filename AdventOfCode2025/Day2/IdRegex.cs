namespace AdventOfCode2025.Day2;

public static partial class IdRegex
{
    [GeneratedRegex(@"^(\d+)\1$")]
    public static partial Regex RepeatTwice();

    [GeneratedRegex(@"^(\d+)\1+$")]
    public static partial Regex RepeatMany();

    [GeneratedRegex(@"(\d+)-(\d+)")]
    internal static partial Regex Range();
}
