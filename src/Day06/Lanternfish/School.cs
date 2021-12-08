using System.Collections.Generic;
using System.Linq;

namespace Lanternfish
{
    public class School
    {
        private long[] school;

        public long Size => school.Sum();

        public School(IEnumerable<int> startingFish)
        {
            school = new long[9];
            foreach (var age in startingFish) school[age]++;
        }

        public void PassDay()
        {
            var newFish = school[0];

            school = school.ShiftLeft();

            school[6] += newFish;
        }
    }
}
