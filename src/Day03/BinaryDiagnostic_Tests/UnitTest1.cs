using System;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;

namespace BinaryDiagnostic_Tests
{

    public class Tests
    {

        [Test]
        [TestCase(new object[]{"00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010"}, 
            ExpectedResult = 198)]
        public int Test1(params string[] input)
        {
            var results =  BinaryDiagnostic.Program.ReadReport(input);
            
            var gamma = Convert.ToInt32(string.Join("", results.gamma), 2);
            var epsilon = Convert.ToInt32(string.Join("", results.epsilon), 2);

            return gamma * epsilon;
        }
    }
}
