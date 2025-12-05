namespace AdventOfCode2025.Test;

public static class ReadInput
{
    public static Task<string[]> AllLines(string name)
    {
        return File.ReadAllLinesAsync($"./Input/{name}");
    }

    public static Task<string> AllText(string name)
    {
        return File.ReadAllTextAsync($"./Input/{name}");
    }
}
