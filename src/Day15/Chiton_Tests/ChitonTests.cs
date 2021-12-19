using System;
using System.Runtime.CompilerServices;
using Chiton;
using NUnit.Framework;

namespace Chiton_Tests;

public class ChitonTests
{
    [Test]
    public void Part1Tests()
    {
        var map = new CavernMap("test_input.txt");

        Assert.AreEqual(40, map.LowestRisk());
    }

    [Test]
    public void Part2Tests()
    {
        var map = new CavernMap("test_input.txt", 5);
        
        Assert.AreEqual(315, map.LowestRisk());
    }
}
