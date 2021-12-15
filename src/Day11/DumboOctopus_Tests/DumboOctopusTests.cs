using DumboOctopus;
using NUnit.Framework;

namespace DumboOctopus_Tests;

public class DumboOctopusTests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("small_input.txt", 2, ExpectedResult = 9)]
    [TestCase("test_input.txt", 100, ExpectedResult = 1656)]
    public int Part1Tests(string fileName, int steps)
    {
        var grid = new OctopusGrid(fileName);

        for (var i = 0; i < steps; i++) grid.DoStep();

        return grid.TotalFlashes;
    }

    [Test]
    public void Part2Tests()
    {
        var grid = new OctopusGrid("test_input.txt");

        var step = 1;
        while (grid.DoStep() != 100) step++;

        Assert.AreEqual(195, step);
    }
}
