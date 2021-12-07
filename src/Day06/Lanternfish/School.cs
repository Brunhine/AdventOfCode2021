using System.Collections.Generic;

namespace Lanternfish
{
    public class School
    {
        private List<Fish> school = new();

        public int Size => school.Count;

        public School(IEnumerable<int> startingFish)
        {
            school = new List<Fish>();
            foreach (var age in startingFish) school.Add(new Fish(ref school, age));
        }

        public void AddFish(int age = 8)
        {
            school.Add(new Fish(ref school, age));
        }

        public void PassDay()
        {
            var schoolSize = school.Count;
            for (var j = 0; j < schoolSize; j++) school[j].Age();
        }
    }
}
