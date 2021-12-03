﻿using System;
using System.IO;

namespace Day1_SonarSweep
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");

            var depths = Array.ConvertAll(lines, int.Parse);

            var sonar = new SonarSweeper(depths);

            Console.WriteLine(sonar.Increases);
        }
    }
}