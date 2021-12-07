using System;
using System.IO;

namespace Lanternfish
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            const int days = 80;

            string input = File.ReadAllText("input.txt");

            int[] ages = Array.ConvertAll(input.Split(","), int.Parse);

            var school = new School(ages);

            for (var i = 0; i < days; i++) school.PassDay();

            Console.WriteLine($"Number of fish after 80 days: {school.Size}");
        }
    }
}
