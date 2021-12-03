using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;

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
            string[] lines = File.ReadAllLines("input.txt");

            var results = ReadReport(lines);

            var gamma = Convert.ToInt32(string.Join("", results.gamma), 2);
            var epsilon = Convert.ToInt32(string.Join("", results.epsilon), 2);
            
            Console.WriteLine(gamma * epsilon);
        }

        public static (int[] gamma, int[] epsilon) ReadReport(IEnumerable<string> input)
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
    }
}
