
using NUnit.Framework;

namespace CrabSubs
{
    public class CrabSubsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(new int[] {16,1,2,0,4,2,7,1,2,14}, ExpectedResult = 37)]
        public int PartOneTests(int[] positions)
        {
            return Program.calc(positions);
        }
    }
}
