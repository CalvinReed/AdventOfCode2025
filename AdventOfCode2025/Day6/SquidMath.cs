using System.Diagnostics;

namespace AdventOfCode2025.Day6;

public static partial class SquidMath
{
    public static long GrandTotal1(string input)
    {
        var numbers = Number().Matches(input);
        var operators = Operator().Matches(input);
        var rowCount = numbers.Count / operators.Count;
        var colCount = operators.Count;
        var buffer = new long[rowCount];
        var grandTotal = 0L;
        for (var i = 0; i < colCount; i++)
        {
            for (var k = 0; k < rowCount; k++)
            {
                var numberIndex = k * colCount + i;
                buffer[k] = long.Parse(numbers[numberIndex].ValueSpan);
            }

            var total = operators[i].ValueSpan switch
            {
                "+" => buffer.Sum(),
                "*" => buffer.Product(),
                _ => throw new UnreachableException()
            };
            grandTotal += total;
        }

        return grandTotal;
    }

    public static long GrandTotal2(string[] lines)
    {
        var width = lines[0].Length;
        var digits = new char[lines.Length];
        var numbers = new List<long>();
        var grandTotal = 0L;
        for (var x = width - 1; x >= 0; x--)
        {
            for (var y = 0; y < lines.Length; y++)
            {
                digits[y] = lines[y][x];
            }

            if (!long.TryParse(digits.AsSpan(..^1), out var n))
            {
                continue;
            }

            numbers.Add(n);
            switch (digits[^1])
            {
                case '+':
                    grandTotal += numbers.Sum();
                    numbers.Clear();
                    break;
                case '*':
                    grandTotal += numbers.Product();
                    numbers.Clear();
                    break;
            }
        }

        return grandTotal;
    }

    private static long Product(this IEnumerable<long> enumerable) => enumerable.Aggregate((x, y) => x * y);

    [GeneratedRegex(@"\d+")]
    private static partial Regex Number();

    [GeneratedRegex("[*+]")]
    private static partial Regex Operator();
}
