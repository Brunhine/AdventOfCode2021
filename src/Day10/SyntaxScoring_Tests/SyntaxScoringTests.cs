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

        var score = lines.Sum(SyntaxParser.GetIllegalLineScore);

        Assert.AreEqual(26397, score);
    }

    [Test]
    public void Part2Tests()
    {
        var lines = File.ReadLines("test_input.txt");

        var scores =
            (from line in lines
                where !SyntaxParser.IsIllegalLine(line)
                select SyntaxParser.GetAutoCompleteLineScore(line)).ToList();

        scores.Sort();

        Assert.AreEqual(288957, scores[scores.Count / 2]);
    }
}
