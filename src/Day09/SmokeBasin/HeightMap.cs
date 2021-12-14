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

        CheckTopNeighbor(position, ref upSlopes, neighbors[0]);

        CheckRightNeighbor(position, ref upSlopes, neighbors[1]);

        CheckBottomNeighbor(position, ref upSlopes, neighbors[2]);

        CheckLeftNeighbor(position, ref upSlopes, neighbors[3]);
    }

    private void CheckTopNeighbor(Position position, ref List<Position> upSlopes, int? neighbor)
    {
        if (!IsUpSlope(neighbor, position.Height)) return;
        var p = new Position((position.Location.h - 1, position.Location.w), neighbor);
        GetUpSlopes(p, ref upSlopes);
    }

    private void CheckRightNeighbor(Position position, ref List<Position> upSlopes, int? neighbor)
    {
        if (!IsUpSlope(neighbor, position.Height)) return;
        var p = new Position((position.Location.h, position.Location.w + 1), neighbor);
        GetUpSlopes(p, ref upSlopes);
    }

    private void CheckBottomNeighbor(Position position, ref List<Position> upSlopes, int? neighbor)
    {
        if (!IsUpSlope(neighbor, position.Height)) return;
        var p = new Position((position.Location.h + 1, position.Location.w), neighbor);
        GetUpSlopes(p, ref upSlopes);
    }

    private void CheckLeftNeighbor(Position position, ref List<Position> upSlopes, int? neighbor)
    {
        if (!IsUpSlope(neighbor, position.Height)) return;
        var p = new Position((position.Location.h, position.Location.w - 1), neighbor);
        GetUpSlopes(p, ref upSlopes);
    }

    private bool IsUpSlope(int? neighbor, int orig)
    {
        return neighbor > orig && neighbor is < 9;
    }
}
