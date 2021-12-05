using System.Collections.Generic;
using System.Linq;

namespace SonarSweep
{
    public class SonarSweeper
    {
        private IEnumerable<int> Depths { get; }

        public int Increases { get; }

        public SonarSweeper(IEnumerable<int> depths)
        {
            Depths = depths;

            Increases = CalculateIncreases();
        }

        private int CalculateIncreases()
        {
            var increases = 0;
            var windows = GetWindows();

            for (var i = 0; i < windows.Count - 1; i++)
                if (windows[i + 1] > windows[i])
                    increases++;

            return increases;
        }

        private List<int> GetWindows()
        {
            var windows = new List<int>();
            var depths = Depths.ToList();

            for (var i = 0; i < depths.Count - 2; i++)
                windows.Add(depths[i] + depths[i + 1] + depths[i + 2]);

            return windows;
        }
    }
}
