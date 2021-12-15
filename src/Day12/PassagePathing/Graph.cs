namespace PassagePathing;

public class Graph
{
    private readonly List<List<string>> allPaths = new();
    private readonly Stack<string> currentPath = new();
    private readonly Dictionary<string, List<string>> vertices = new();

    public void AddEdge(string from, string to)
    {
        if (!vertices.ContainsKey(from))
            vertices.Add(from, new List<string>());

        if (!vertices.ContainsKey(to))
            vertices.Add(to, new List<string>());

        vertices[from].Add(to);
        vertices[to].Add(from);
    }

    public int GetAllPaths(string start, string end, PathingType mode)
    {
        currentPath.Clear();
        allPaths.Clear();

        FindPathWay(start, end, mode);
        return allPaths.Count;
    }

    private void FindPathWay(string start, string end, PathingType mode = PathingType.VisitOnce)
    {
        if (start == "start" && currentPath.Contains("start"))
            return;

        currentPath.Push(start);

        if (start == end)
        {
            allPaths.Add(currentPath.Reverse().ToList());
            currentPath.Pop();
            return;
        }

        var canVisit = mode switch
        {
            PathingType.VisitOnce => AlreadyVisitedOnce(start),
            PathingType.VisitOneTwice => AlreadyVisitedOneTwice(start),
            _ => throw new ArgumentOutOfRangeException(nameof(mode), mode, null)
        };

        if (IsSmallCave(start) && canVisit)
        {
            currentPath.Pop();
            return;
        }

        foreach (var adjacent in vertices[start]) FindPathWay(adjacent, end, mode);

        currentPath.Pop();
    }
    
    private static bool IsSmallCave(string cave)
    {
        return cave.All(char.IsLower);
    }

    private bool AlreadyVisitedOnce(string v)
    {
        return currentPath.Count(c => c == v) > 1;
    }

    private bool AlreadyVisitedOneTwice(string v)
    {
        return currentPath
                   .Where(c => char.IsLower(c[0]) && c != v)
                   .GroupBy(c => c)
                   .Any(g => g.Count() > 1)
               && currentPath.Count(c => c == v) == 2
               || currentPath.Count(c => c == v) > 2;
    }
}
