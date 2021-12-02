using System;
using System.Collections.Generic;

namespace Dive
{
    public class Submarine
    {
        private IEnumerable<Instruction> Instructions { get; }

        public Position Position { get; }

        private int Aim { get; set; }

        public Submarine(IEnumerable<Instruction> instructions)
        {
            Instructions = instructions;
            Position = new Position();
            Aim = 0;
        }

        public Position Drive()
        {
            foreach (var instruction in Instructions)
                switch (instruction.Direction)
                {
                    case Direction.Forward:
                        Position.Horizontal += instruction.Distance;
                        Position.Depth += Aim * instruction.Distance;
                        break;
                    case Direction.Up:
                        Aim -= instruction.Distance;
                        break;
                    case Direction.Down:
                        Aim += instruction.Distance;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

            return Position;
        }
    }
}