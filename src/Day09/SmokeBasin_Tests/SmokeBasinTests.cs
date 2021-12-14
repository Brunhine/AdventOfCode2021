using System.Linq;
using NUnit.Framework;
using SmokeBasin;

namespace SmokeBasin_Tests;

public class SmokeBasinTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Part1Tests()
    {
        var map = new HeightMap("test_input.txt");
        var lowSpots = map.GetLowSpots();
        Assert.AreEqual(15, lowSpots.Sum(x => x.DangerLevel));
    }

    [Test]
    public void Part2Tests()
    {
        var map = new HeightMap("test_input.txt");
        var basins = map.GetBasins();
        var topThree = basins.OrderByDescending(x => x.Size).Take(3).ToList();
        Assert.AreEqual(1134, topThree[0].Size * topThree[1].Size * topThree[2].Size);
    }
}
