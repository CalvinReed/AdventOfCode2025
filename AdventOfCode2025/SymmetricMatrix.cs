using System.Diagnostics.Contracts;

namespace AdventOfCode2025;

public sealed class SymmetricMatrix<T>(int order)
{
    private readonly T[] items = new T[HalfSquare(order)];

    /// <summary>
    /// The length of each dimension
    /// </summary>
    public int Order { get; } = order;

    /// <summary>
    /// The contents of the matrix in linear order
    /// </summary>
    public Span<T> Items => items;

    public T this[int x, int y]
    {
        get => items[GetOffset(x, y)];
        set => items[GetOffset(x, y)] = value;
    }

    /// <summary>
    /// Maps an index for <see cref="Items"/> to a coordinate pair
    /// </summary>
    [Pure]
    public (int X, int Y) GetCoordinates(int index)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(index);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(index, items.Length);
        var x = (int)(Math.Sqrt(index * 2.0 + 0.25) - 0.5); // Inverse of HalfSquare
        var y = index - HalfSquare(x);
        return (x, y);
    }

    /// <summary>
    /// Maps a coordinate pair to an index for <see cref="Items"/>
    /// </summary>
    [Pure]
    private int GetOffset(int x, int y)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(x);
        ArgumentOutOfRangeException.ThrowIfNegative(y);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(x, Order);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(y, Order);
        var (hi, lo) = x >= y ? (x, y) : (y, x);
        return HalfSquare(hi) + lo;
    }

    private static int HalfSquare(int n)
    {
        var u = Convert.ToUInt32(n);
        return (int)checked(u * (u + 1) / 2);
    }
}
