using System;

namespace Dive
{
    public class Instruction
    {
        public Direction Direction { get; set; }
        public int Distance { get; set; }

        public Instruction(string input)
        {
            var split = input.Split(" ");

            Direction = Enum.Parse<Direction>(split[0], true);
            Distance = int.Parse(split[1]);
        }
    }
}
