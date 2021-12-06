using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace HydrothermalVenture
{
    public static class Program
    {
        private const string RegexString = @"(?<x1>[0-9]+?),(?<y1>[0-9]+?) -> (?<x2>[0-9]+?),(?<y2>[0-9]+.?)";

        private static readonly Dictionary<Tuple<int, int>, int> ventCoordinates = new();

        public static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");

            foreach (var line in lines)
            {
                var matches = Regex.Matches(line, RegexString);
                var x1 = int.Parse(matches[0].Groups["x1"].Value);
                var x2 = int.Parse(matches[0].Groups["x2"].Value);
                var y1 = int.Parse(matches[0].Groups["y1"].Value);
                var y2 = int.Parse(matches[0].Groups["y2"].Value);

                ParseCoordinates(x1, y1, x2, y2);
            }

            Console.WriteLine(ventCoordinates.Count(x => x.Value > 1));
        }

        private static void ParseCoordinates(int x1, int y1, int x2, int y2)
        {
            if (x1 != x2 && y1 != y2)
                SolveDiagonal(x1, y1, x2, y2);
            else
                SolveHorizontalAndVertical(x1, y1, x2, y2);
        }

        private static void SolveDiagonal(int x1, int y1, int x2, int y2)
        {
            if (x1 < x2 && y1 < y2 || x1 > x2 && y1 > y2)
                SolveSlopeDown(x1, y1, x2, y2);
            else
                SolveSlopeUp(x1, y1, x2, y2);
        }

        private static void SolveSlopeUp(int x1, int y1, int x2, int y2)
        {
            if (y1 > y2)
            {
                (x2, x1) = (x1, x2);
                (y2, y1) = (y1, y2);
            }

            var dx = x1;
            var dy = y1;

            while (dx >= x2 && dy <= y2)
            {
                InsertPoint(new Tuple<int, int>(dx, dy));
                dx--;
                dy++;
            }
        }

        private static void SolveSlopeDown(int x1, int y1, int x2, int y2)
        {
            if (x1 > x2)
                (x2, x1) = (x1, x2);

            if (y1 > y2)
                (y2, y1) = (y1, y2);

            var dx = x1;
            var dy = y1;
            
            while (dx <= x2 && dy <= y2)
            {
                InsertPoint(new Tuple<int, int>(dx, dy));
                dx++;
                dy++;
            }
        }

        private static void SolveHorizontalAndVertical(int x1, int y1, int x2, int y2)
        {
            if (x1 > x2)
                (x2, x1) = (x1, x2);

            if (y1 > y2)
                (y2, y1) = (y1, y2);

            for (var dy = y1; dy <= y2; dy++)
            for (var dx = x1; dx <= x2; dx++)
            {
                var vent = new Tuple<int, int>(dx, dy);
                InsertPoint(vent);
            }
        }

        private static void InsertPoint(Tuple<int, int> point)
        {
            if (ventCoordinates.ContainsKey(point))
                ventCoordinates[point]++;
            else
                ventCoordinates.Add(point, 1);
        }
    }
}
