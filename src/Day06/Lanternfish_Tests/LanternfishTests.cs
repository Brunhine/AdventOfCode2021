using Lanternfish;
using NUnit.Framework;

namespace Lanternfish_Tests
{
    public class LanternfishTests
    {
        [TestCase(new[] {3, 4, 3, 1, 2}, 18, ExpectedResult = 26)]
        [TestCase(new[] {3, 4, 3, 1, 2}, 80, ExpectedResult = 5934)]
        public int TestPartOne(int[] input, int days)
        {
            var school = new School(input);

            for (var i = 0; i < days; i++) school.PassDay();

            return school.Size;
        }
    }
}
