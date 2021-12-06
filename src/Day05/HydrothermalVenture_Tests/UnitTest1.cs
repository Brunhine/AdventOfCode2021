using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using HydrothermalVenture;
using NUnit.Framework;

namespace HydrothermalVenture_Tests
{
    public class Tests
    {
        private IEnumerable<string> lines = new List<string>();

        [SetUp]
        public void Setup()
        {
            lines = File.ReadAllLines("test_input.txt");
        }

        [Test]
        public void Test1()
        {
            foreach (var line in lines)
            {
                var matches = Regex.Matches(line, Program.RegexString);
                var x1 = int.Parse(matches[0].Groups["x1"].Value);
                var x2 = int.Parse(matches[0].Groups["x2"].Value);
                var y1 = int.Parse(matches[0].Groups["y1"].Value);
                var y2 = int.Parse(matches[0].Groups["y2"].Value);

                Program.ParseCoordinates(x1, y1, x2, y2);
            }

            Assert.AreEqual(12, Program.VentCoordinates.Count(x => x.Value > 1));
        }
    }
}
