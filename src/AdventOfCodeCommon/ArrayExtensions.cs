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

    public static T?[] GetNeighbors<T>(this T[,] map, int h, int w) where T : struct
    {
        var neighbors = new T?[4];

        // top
        neighbors[0] = h > 0 ? map[h - 1, w] : null;

        // right
        neighbors[1] = w < map.GetLength(1) - 1 ? map[h, w + 1] : null;

        // bottom
        neighbors[2] = h < map.GetLength(0) - 1 ? map[h + 1, w] : null;

        // left
        neighbors[3] = w > 0 ? map[h, w - 1] : null;

        return neighbors;
    }

    public static T?[] GetNeighborsWithDiagonals<T>(this T[,] map, int h, int w) where T : class
    {
        var neighbors = new T?[8];

        // top
        neighbors[0] = h > 0 ? map[h - 1, w] : null;

        // top right
        neighbors[1] = h > 0 && w < map.GetLength(1) - 1 ? map[h - 1, w + 1] : null;

        // right
        neighbors[2] = w < map.GetLength(1) - 1 ? map[h, w + 1] : null;

        // bottom right
        neighbors[3] = h < map.GetLength(0) - 1 && w < map.GetLength(1) - 1 ? map[h + 1, w + 1] : null;

        // bottom
        neighbors[4] = h < map.GetLength(0) - 1 ? map[h + 1, w] : null;

        // bottom left
        neighbors[5] = h < map.GetLength(0) - 1 && w > 0 ? map[h + 1, w - 1] : null;

        // left
        neighbors[6] = w > 0 ? map[h, w - 1] : null;

        // top left
        neighbors[7] = h > 0 && w > 0 ? map[h - 1, w - 1] : null;

        return neighbors;
    }
}
