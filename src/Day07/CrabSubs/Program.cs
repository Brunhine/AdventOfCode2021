using System;
using System.IO;
using System.Linq;

namespace CrabSubs
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var line = File.ReadAllText("input.txt");

            var positions = Array.ConvertAll(line.Split(","), int.Parse);

            var (bestPosition, fuelUsage) = DetermineOptimalCrabPosition(positions);

            Console.WriteLine(
                $"Best fuel usage is {fuelUsage} units to get to position {bestPosition}");
        }

        public static (int bestPosition, int fuelUsage) DetermineOptimalCrabPosition(int[] positions)
        {
            var maxPosition = positions.Max();

            var bestPosition = int.MaxValue;
            var bestFuelUsage = int.MaxValue;

            for (var i = 0; i < maxPosition; i++)
            {
                var fuelUsed = positions.Sum(p1 => CalculateFuelUsage(p1, i));
                if (fuelUsed >= bestFuelUsage) continue;
                bestPosition = i;
                bestFuelUsage = fuelUsed;
            }

            return (bestPosition, bestFuelUsage);
        }

        private static int CalculateFuelUsage(int p1, int p2)
        {
            var dist = Math.Abs(p1 - p2);

            // Triangular number: https://www.wikiwand.com/en/Triangular_number
            return dist * (dist + 1) / 2;
        }
    }
}
