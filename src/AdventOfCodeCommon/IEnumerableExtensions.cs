namespace AdventOfCodeCommon;

public static class EnumerableExtensions
{
    public static bool IsSubset<T>(this IEnumerable<T> array1, IEnumerable<T> array2)
    {
        return !array2.Except(array1).Any();
    }
}
