using System;
using System.IO;
using System.Linq;

namespace CrabSubs
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            string line = File.ReadAllText("input.txt");

            int[] positions = Array.ConvertAll(line.Split(","), int.Parse);

            var optimal = DetermineOptimalCrabPosition(positions);

            Console.WriteLine(
                $"Best fuel usage is {optimal.fuelUsage} units to get to position {optimal.bestPosition}");
        }

        public static (int bestPosition, int fuelUsage) DetermineOptimalCrabPosition(int[] positions)
        {
            var maxPosition = positions.Max();

            var bestPosition = int.MaxValue;
            var bestFuelUsage = int.MaxValue;

            for (var i = 0; i < maxPosition; i++)
            {
                var fuelUsed = positions.Sum(t => Math.Abs(t - i));
                if (fuelUsed >= bestFuelUsage) continue;
                bestPosition = i;
                bestFuelUsage = fuelUsed;
            }

            return (bestPosition, bestFuelUsage);
        }
    }
}
