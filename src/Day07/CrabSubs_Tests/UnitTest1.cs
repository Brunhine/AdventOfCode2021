using NUnit.Framework;

namespace CrabSubs
{
    public class CrabSubsTests
    {
        [TestCase(new[] {16, 1, 2, 0, 4, 2, 7, 1, 2, 14}, ExpectedResult = 168)]
        public int PartOneTests(int[] positions)
        {
            return Program.DetermineOptimalCrabPosition(positions).fuelUsage;
        }
    }
}
