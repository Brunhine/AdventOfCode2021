using System.IO;
using System.Linq;
using NUnit.Framework;
using PassagePathing;

namespace PassagePathing_Tests;

public class PassagePathingTests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("small_input.txt", ExpectedResult = 10)]
    [TestCase("test_input.txt", ExpectedResult = 19)]
    [TestCase("large_input.txt", ExpectedResult = 226)]
    public int Part1Tests(string fileName)
    {
        var lines = File.ReadAllLines(fileName).ToList();

        var graph = new Graph();

        lines.ForEach(line =>
        {
            var edge = line.Split('-');
            graph.AddEdge(edge[0], edge[1]);
        });

        return graph.GetAllPaths("start", "end");
    }
    
    [Test]
    public void Part2Tests()
    {
        Assert.Pass();
    }
}
