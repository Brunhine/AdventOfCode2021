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

    public IEnumerable<LowPoint> GetLowSpots()
    {
        var lowSpots = new List<LowPoint>();

        for (var h = 0; h < height; h++)
        for (var w = 0; w < width; w++)
        {
            var num = map[h, w];
            var n = map.GetNeighbors(h, w);
            if (n.All(x => x == null || x > num)) lowSpots.Add(new LowPoint((h, w), num));
        }

        return lowSpots;
    }

    public IEnumerable<Basin> GetBasins()
    {
        var lowSpots = GetLowSpots();

        var basins = new List<Basin>();

        foreach (var lowSpot in lowSpots)
        {
            var basin = new Basin();
            var l = new List<Position>();

            GetUpSlopes(lowSpot, ref l);

            basin.Positions = l;

            basins.Add(basin);
        }

        return basins;
    }

    private void GetUpSlopes(Position position, ref List<Position> upSlopes)
    {
        if (!upSlopes.Contains(position)) upSlopes.Add(position);

        var neighbors = map.GetNeighbors(position.Location.h, position.Location.w);

        // look up
        if (IsUpSlope(neighbors[0], position.Height))
        {
            var p = new Position((position.Location.h - 1, position.Location.w), neighbors[0]);
            GetUpSlopes(p, ref upSlopes);
        }

        // look right
        if (IsUpSlope(neighbors[1], position.Height))
        {
            var p = new Position((position.Location.h, position.Location.w + 1), neighbors[1]);
            GetUpSlopes(p, ref upSlopes);
        }

        // look down
        if (IsUpSlope(neighbors[2], position.Height))
        {
            var p = new Position((position.Location.h + 1, position.Location.w), neighbors[2]);
            GetUpSlopes(p, ref upSlopes);
        }

        // look left
        if (IsUpSlope(neighbors[3], position.Height))
        {
            var p = new Position((position.Location.h, position.Location.w - 1), neighbors[3]);
            GetUpSlopes(p, ref upSlopes);
        }
    }

    private bool IsUpSlope(int? neighbor, int orig)
    {
        return neighbor > orig && neighbor is < 9;
    }
}
