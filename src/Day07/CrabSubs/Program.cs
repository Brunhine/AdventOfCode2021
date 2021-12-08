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
            
            Console.WriteLine($"Best fuel usage is {calc(positions)}");
        }

        public static int calc(int[] positions)
        {
            var maxPosition = positions.Max();
            
            var bestPosition = int.MaxValue;
            var bestFuelUsage = int.MaxValue;

            for (int i = 0; i < maxPosition; i++)
            {
                var fuelUsed = 0;
                for (int j = 0; j < positions.Length; j++)
                {
                    var distance = Math.Abs(positions[j] - i);
                    fuelUsed += distance;
                }

                if (fuelUsed < bestFuelUsage)
                {
                    bestPosition = i;
                    bestFuelUsage = fuelUsed;
                }
            }

            return bestFuelUsage;
        }
    }
}
