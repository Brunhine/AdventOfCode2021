using System.IO;
using NUnit.Framework;
using TransparentOrigami;

namespace TransparentOrigami_Tests;

public class TransparentOrigamiTests
{
    [Test]
    public void Part1Tests()
    {
        var input = File.ReadAllLines("test_input.txt");
        var paper = new Paper(input);
        paper.DoFolds(1);

        Assert.AreEqual(17, paper.VisibleDots.Count);
    }
}
