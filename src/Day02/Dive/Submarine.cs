using System;
using System.Collections.Generic;

namespace Dive
{
    public class Submarine
    {
        public IEnumerable<Instruction> Instructions { get; set; }

        public Position Position { get; }

        public Submarine(IEnumerable<Instruction> instructions)
        {
            Instructions = instructions;
            Position = new Position();
        }

        public Position Drive()
        {
            foreach (var instruction in Instructions)
                switch (instruction.Direction)
                {
                    case Direction.Forward:
                        Position.Horizontal += instruction.Distance;
                        break;
                    case Direction.Up:
                        Position.Depth -= instruction.Distance;
                        break;
                    case Direction.Down:
                        Position.Depth += instruction.Distance;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

            return Position;
        }
    }
}