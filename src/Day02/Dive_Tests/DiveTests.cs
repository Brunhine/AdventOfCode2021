using System.Linq;
using Dive;
using NUnit.Framework;

namespace Dive_Tests
{
    public class DiveTests
    {
        [Test]
        [TestCase("forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2", ExpectedResult = 900)]
        public int DiveTest(params string[] input)
        {
            var instructions = input.Select(s => new Instruction(s));
            var sub = new Submarine(instructions);
            var position = sub.Drive();
            return position.Depth * position.Horizontal;
        }
    }
}
