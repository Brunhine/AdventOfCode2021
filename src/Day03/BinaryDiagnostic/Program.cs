using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BinaryDiagnostic
{
    public static class Program
    {
        private static int ToInt(this char c)
        {
            return c - '0';
        }

        public static void Main(string[] args)
        {
            // Get report from file
            string[] lines = File.ReadAllLines("input.txt");

            // calculate power consumption (part 1)
            var powerConsumption = GetPowerConsumption(lines);

            var gamma = Convert.ToInt32(string.Join("", powerConsumption.gamma), 2);
            var epsilon = Convert.ToInt32(string.Join("", powerConsumption.epsilon), 2);

            Console.WriteLine($"Power Consumption: {gamma * epsilon}");

            // calculate life support (part 2)
            var lifeSupport = GetLifeSupportRating(lines);

            var oxygen = Convert.ToInt32(string.Join("", lifeSupport.oxygen), 2);
            var c02 = Convert.ToInt32(string.Join("", lifeSupport.c02), 2);

            Console.WriteLine($"Life Support: {oxygen * c02}");
        }

        public static (int[] gamma, int[] epsilon) GetPowerConsumption(IEnumerable<string> input)
        {
            var reports = input.Select(line => Array.ConvertAll(line.ToCharArray(), ToInt)).ToList();

            var size = reports[0].Length;

            var gamma = new int[size];
            var epsilon = new int[size];

            for (var i = 0; i < size; i++)
            {
                var bits = reports.Select(report => report[i]).ToList();

                gamma[i] = bits.GroupBy(v => v).OrderByDescending(g => g.Count()).First().Key;
                epsilon[i] = bits.GroupBy(v => v).OrderBy(g => g.Count()).First().Key;
            }

            return (gamma, epsilon);
        }

        public static (int[] oxygen, int[] c02) GetLifeSupportRating(IEnumerable<string> input)
        {
            var lifeSupportReports = input.ToList();
            return (GetOxygenGeneratorRating(lifeSupportReports), GetC02ScrubberRating(lifeSupportReports));
        }

        private static int[] GetOxygenGeneratorRating(IEnumerable<string> input)
        {
            var reports = input.Select(line => Array.ConvertAll(line.ToCharArray(), ToInt)).ToList();

            var i = 0;
            while (reports.Count > 1)
            {
                var mostCommon = reports.Select(line => line[i]).GroupBy(v => v).OrderByDescending(g => g.Count())
                    .ThenByDescending(g => g.Key)
                    .First().Key;
                reports.RemoveAll(line => line[i] != mostCommon);

                i++;
            }

            return reports[0];
        }

        private static int[] GetC02ScrubberRating(IEnumerable<string> input)
        {
            var reports = input.Select(line => Array.ConvertAll(line.ToCharArray(), ToInt)).ToList();

            var i = 0;
            while (reports.Count > 1)
            {
                var leastCommon = reports.Select(line => line[i]).GroupBy(v => v).OrderBy(g => g.Count())
                    .ThenBy(g => g.Key)
                    .First().Key;
                reports.RemoveAll(line => line[i] != leastCommon);

                i++;
            }

            return reports[0];
        }
    }
}
