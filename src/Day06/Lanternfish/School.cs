using System.Collections.Generic;
using System.Linq;

namespace Lanternfish
{
    public class School
    {
        private long[] school;

        public long Size
        {
            get
            {
                long fish = 0;
                for (int i = 0; i < school.Length; i++)
                {
                    fish += school[i];
                }

                return fish;
            }
        }

        public School(IEnumerable<int> startingFish)
        {
            school = new long[9];
            foreach (var age in startingFish)
            {
                school[age]++;
            }
        }

        public void AddFish(int age = 8)
        {
            school[age-1]++;
        }

        public void PassDay()
        {
            long newFish = school[0];

            school = shiftLeft(school);

            school[6] += newFish;
            //school[7] += newFish;
        }

        private long[] shiftLeft(long[] array)
        {
            long[] newArray = new long[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[(i + 1) % array.Length];
            }

            return newArray;
        }
    }
}
