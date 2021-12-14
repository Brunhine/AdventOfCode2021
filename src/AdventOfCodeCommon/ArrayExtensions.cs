namespace AdventOfCodeCommon;

public static class ArrayExtensions
{
    public static T[] ShiftLeft<T>(this T[] array)
    {
        var size = array.Length;
        var newArray = new T[size];
        for (var i = 0; i < size; i++) newArray[i] = array[(i + 1) % size];

        return newArray;
    }

    public static IEnumerable<T> GetNeighbors<T>(this T[,] map, int h, int w)
    {
        var neighbors = new List<T>();

        // get top
        if (h > 0)
            neighbors.Add(map[h - 1, w]);

        // get bottom
        if (h < map.GetLength(0) - 1)
            neighbors.Add(map[h + 1, w]);

        // get right
        if (w < map.GetLength(1) - 1)
            neighbors.Add(map[h, w + 1]);

        // get left
        if (w > 0)
            neighbors.Add(map[h, w - 1]);

        return neighbors;
    }
}
