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
        Assert.AreEqual(15, map.GetLowSpots().Sum(x => x+1));
    }
}
