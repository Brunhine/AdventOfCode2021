using System;
using System.IO;
using System.Linq;

namespace Dive
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");

            var instructions = lines.Select(s => new Instruction(s));

            var sub = new Submarine(instructions);

            var position = sub.Drive();

            Console.WriteLine(
                $"Final position: h:{position.Horizontal} d:{position.Depth} (h*d= {position.Depth * position.Horizontal})");
        }
    }
}
