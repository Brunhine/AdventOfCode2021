using AdventOfCodeCommon;

namespace SmokeBasin;

public class HeightMap
{
    private readonly int height;
    private readonly int[,] map;
    private readonly int width;

    public HeightMap(string fileName)
    {
        var strings = File.ReadAllLines(fileName);

        width = strings[0].ToCharArray().Length;
        height = strings.Length;

        map = new int[height, width];

        for (var h = 0; h < height; h++)
        {
            var points = strings[h].ToCharArray();
            for (var w = 0; w < width; w++)
                map[h, w] = (int) char.GetNumericValue(points[w]);
        }
    }

    public IEnumerable<int> GetLowSpots()
    {
        var lowSpots = new List<int>();

        for (var h = 0; h < height; h++)
        for (var w = 0; w < width; w++)
        {
            var num = map[h, w];
            var n = map.GetNeighbors(h, w);
            if (n.All(x => x > num)) lowSpots.Add(num);
        }

        return lowSpots;
    }
}
