using System.IO;
using System.Linq;
using ExtendedPolymerization;
using NUnit.Framework;

namespace ExtendedPolymerization_Tests;

public class ExtendedPolymerizationTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Part1TestQuantities()
    {
        var lines = File.ReadAllLines("test_input.txt").ToList();

        var polymer = Polymer.BuildPolymer(lines);

        for (var i = 0; i < 10; i++) polymer.DoStep();

        Assert.AreEqual(1588, polymer.GetPolymerScore());
    }

    [Test]
    public void Part2TestQuantities()
    {
        var lines = File.ReadAllLines("test_input.txt").ToList();

        var polymer = Polymer.BuildPolymer(lines);

        for (var i = 0; i < 40; i++) polymer.DoStep();

        Assert.AreEqual(2188189693529, polymer.GetPolymerScore());
    }
}
