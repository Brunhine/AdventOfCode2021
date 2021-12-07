using System.Collections.Generic;

namespace Lanternfish
{
    public class Fish
    {
        private int internalTimer;
        private List<Fish> school;

        private Fish(ref List<Fish> school) : this(ref school, 8)
        {
        }

        public Fish(ref List<Fish> school, int internalTimer)
        {
            this.school = school;
            this.internalTimer = internalTimer;
        }

        public void Age()
        {
            internalTimer--;
            if (internalTimer >= 0) return;
            internalTimer = 6;
            school.Add(new Fish(ref school));
        }
    }
}
