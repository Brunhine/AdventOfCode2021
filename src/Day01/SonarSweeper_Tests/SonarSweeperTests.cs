using Day1_SonarSweep;
using NUnit.Framework;

namespace SonarSweeper_Tests
{
    public class SonarSweeperTests
    {
        [TestCase(new[] {1, 2, 3, 4}, ExpectedResult = 1)]
        [TestCase(new[] {1, 2, 3, 1}, ExpectedResult = 0)]
        [TestCase(new[] {1, 2, 3, 1, 3}, ExpectedResult = 1)]
        [TestCase(new[] {1, 1, 1, 1, 1, 1, 1, 1}, ExpectedResult = 0)]
        [TestCase(new[] {1, 2, 3, 1, 3, 2, 3, 1, 3}, ExpectedResult = 3)]
        [TestCase(new[] {199, 200, 208, 210, 200, 207, 240, 269, 260, 263}, ExpectedResult = 5)]
        public int DepthTest(int[] depths)
        {
            return new SonarSweeper(depths).Increases;
        }
    }
}
