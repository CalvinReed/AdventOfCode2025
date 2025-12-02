namespace AdventOfCode2025.Test;

public static class ReadInput
{
    public static IAsyncEnumerable<string> Lines(string name)
    {
        return File.ReadLinesAsync($"./Input/{name}");
    }

    public static Task<string> AllText(string name)
    {
        return File.ReadAllTextAsync($"./Input/{name}");
    }
}
