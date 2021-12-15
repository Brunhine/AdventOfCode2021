using System.IO;
using System.Linq;
using NUnit.Framework;
using PassagePathing;

namespace PassagePathing_Tests;

public class PassagePathingTests
{
    [TestCase("small_input.txt", ExpectedResult = 10)]
    [TestCase("test_input.txt", ExpectedResult = 19)]
    [TestCase("large_input.txt", ExpectedResult = 226)]
    public int Part1Tests(string fileName)
    {
        var graph = GetGraph(fileName);

        return graph.GetAllPaths("start", "end", PathingType.VisitOnce);
    }

    [TestCase("small_input.txt", ExpectedResult = 36)]
    [TestCase("test_input.txt", ExpectedResult = 103)]
    [TestCase("large_input.txt", ExpectedResult = 3509)]
    public int Part2Tests(string fileName)
    {
        var graph = GetGraph(fileName);

        return graph.GetAllPaths("start", "end", PathingType.VisitOneTwice);
    }

    private static Graph GetGraph(string fileName)
    {
        var lines = File.ReadAllLines(fileName).ToList();

        var graph = new Graph();

        lines.ForEach(line =>
        {
            var edge = line.Split('-');
            graph.AddEdge(edge[0], edge[1]);
        });

        return graph;
    }
}
