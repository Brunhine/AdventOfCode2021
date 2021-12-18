using System;
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
}
