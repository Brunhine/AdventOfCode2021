using System.Diagnostics.CodeAnalysis;
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

    [TestCase(1, ExpectedResult = "NCNBCHB")]
    [TestCase(2, ExpectedResult = "NBCCNBBBCBHCB")]
    [TestCase(3, ExpectedResult = "NBBBCNCCNBBNBNBBCHBHHBCHB")]
    [TestCase(4, ExpectedResult = "NBBNBNBBCCNBCNCCNBBNBBNBBBNBBNBBCBHCBHHNHCBBCBHCB")]
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public string Part1TestPolymer(int steps)
    {
        var lines = File.ReadAllLines("test_input.txt").ToList();

        var polymer = Polymer.BuildPolymer(lines);

        for (var i = 0; i < steps; i++) polymer.DoStep();

        return polymer.CurrentPolymer;
    }

    [Test]
    public void Part1TestQuantities()
    {
        var lines = File.ReadAllLines("test_input.txt").ToList();

        var polymer = Polymer.BuildPolymer(lines);

        for (var i = 0; i < 10; i++) polymer.DoStep();

        Assert.AreEqual(1588, polymer.GetPolymerScore());
    }
}
