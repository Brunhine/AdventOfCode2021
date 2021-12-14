using System.IO;
using System.Linq;
using NUnit.Framework;
using SyntaxScoring;

namespace SyntaxScoring_Tests;

public class SyntaxScoringTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Part1Tests()
    {
        var lines = File.ReadAllLines("test_input.txt");

        var score = lines.Sum(SyntaxParser.GetLineScore);

        Assert.AreEqual(26397, score);
    }
}
