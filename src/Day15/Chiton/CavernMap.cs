namespace Chiton;

public class CavernMap
{
    private int Width { get; }
    private int Height { get; }
    private Dictionary<(int x, int y), int> Graph { get; }

    public CavernMap(string fileName, int multiples = 1)
    {
        Graph = GetGraphFromFile(fileName, multiples);
        Width = Graph.Max(p => p.Key.x);
        Height = Graph.Max(p => p.Key.y);
    }

    private static Dictionary<(int x, int y), int> GetGraphFromFile(string fileName, int multiples = 1)
    {
        var lines = File.ReadAllLines(fileName).ToList();
        var graph = new Dictionary<(int, int), int>();
        var chunkWidth = lines[0].Length;
        var chunkHeight = lines.Count;

        for (var y = 0; y < chunkHeight * multiples; y++)
        for (var x = 0; x < chunkWidth * multiples; x++)
        {
            var val = int.Parse(lines[y % chunkHeight][x % chunkWidth].ToString()) + x / chunkWidth + y / chunkHeight;
            while (val > 9) val -= 9; 
            graph.Add((x, y), val);
        }

        return graph;
    }

    private bool IsInGrid((int x, int y) point)
    {
        var (x, y) = point;
        return x >= 0 && x <= Width && y >= 0 && y <= Height;
    }

    private int GetManhattanScore((int x, int y) point)
    {
        var (x, y) = point;
        return Width - x + Width - y;
    }

    private IEnumerable<(int, int)> GetNeighbors((int x, int y) p)
    {
        return new List<(int, int)>
        {
            (p.x - 1, p.y),
            (p.x + 1, p.y),
            (p.x, p.y - 1),
            (p.x, p.y + 1)
        }.Where(IsInGrid);
    }

    public int LowestRisk()
    {
        var dest = (Width, Height);
        var candidates = new SortedSet<(int risk, int manhattan, (int x, int y) point)>
        {
            (0, GetManhattanScore((0, 0)), (0, 0))
        };
        var visited = new HashSet<(int x, int y)>();

        while (candidates.Count > 0)
        {
            var currentCandidate = candidates.First();
            candidates.Remove(currentCandidate);
            var currentPoint = currentCandidate.point;

            foreach (var neighbor in GetNeighbors(currentPoint))
                if (neighbor == dest)
                {
                    return currentCandidate.risk + Graph[dest];
                }
                else if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    var next = (Graph[neighbor] + currentCandidate.risk, GetManhattanScore(neighbor), neighbor);
                    candidates.Add(next);
                }
        }

        throw new Exception("No valid path found.");
    }
}
