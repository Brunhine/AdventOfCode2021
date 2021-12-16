using System.IO;
using System.Linq;
using NUnit.Framework;
using TransparentOrigami;

namespace TransparentOrigami_Tests;

public class TransparentOrigamiTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Part1Tests()
    {
        var input = File.ReadAllLines("test_input.txt");
        var paper = new Paper(input);
        paper.DoFolds(1);

        Assert.AreEqual(17, paper.VisibleDots.Count);
    }

    [Test]
    public void Part2Tests()
    {
        Assert.Pass();
    }
}
