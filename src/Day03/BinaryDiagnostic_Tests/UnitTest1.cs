using System;
using BinaryDiagnostic;
using NUnit.Framework;

namespace BinaryDiagnostic_Tests
{
    public class Tests
    {
        [Test]
        [TestCase("00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010",
            "01010",
            ExpectedResult = 198)]
        public int TestPowerConsumption(params string[] input)
        {
            var results = Program.GetPowerConsumption(input);

            var gamma = Convert.ToInt32(string.Join("", results.gamma), 2);
            var epsilon = Convert.ToInt32(string.Join("", results.epsilon), 2);

            return gamma * epsilon;
        }

        [Test]
        [TestCase("00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010",
            "01010",
            ExpectedResult = 230)]
        public int TestLifeSupport(params string[] input)
        {
            var results = Program.GetLifeSupportRating(input);

            var oxygen = Convert.ToInt32(string.Join("", results.oxygen), 2);
            var c02 = Convert.ToInt32(string.Join("", results.c02), 2);

            return oxygen * c02;
        }
    }
}
