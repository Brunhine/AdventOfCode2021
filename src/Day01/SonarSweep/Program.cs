using System;
using System.IO;

namespace SonarSweep
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");

            var depths = Array.ConvertAll(lines, int.Parse);

            var sonar = new SonarSweeper(depths);

            Console.WriteLine($"There were {sonar.Increases} in depth.");
        }
    }
}
