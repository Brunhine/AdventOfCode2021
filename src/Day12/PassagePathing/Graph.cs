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

    public int GetAllPaths(string start, string end)
    {
        currentPath.Clear();
        allPaths.Clear();

        FindPathWay(start, end);
        return allPaths.Count;
    }

    private void FindPathWay(string start, string end)
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

        if (IsSmallCave(start) && PathAlreadyVisited(start))
        {
            currentPath.Pop();
            return;
        }

        foreach (var adjacent in vertices[start]) FindPathWay(adjacent, end);

        currentPath.Pop();
    }

    private static bool IsSmallCave(string cave)
    {
        return cave.All(char.IsLower);
    }

    private bool PathAlreadyVisited(string v)
    {
        return currentPath.Count(c => c == v) > 1;
    }
}
