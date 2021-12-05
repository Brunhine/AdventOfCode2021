using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GiantSquid
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");

            var numbersToDraw = GetNumbersToDraw(lines);

            var boards = GetBingoBoards(lines);

            var game = new BingoGame(numbersToDraw, boards);

            Console.WriteLine(game.RunGame());
        }

        public static int[] GetNumbersToDraw(IEnumerable<string> input)
        {
            return input.ToArray()[0].Split(",").Select(int.Parse).ToArray();
        }

        public static IEnumerable<BingoBoard> GetBingoBoards(IEnumerable<string> input)
        {
            var lines = input.ToList();
            lines.RemoveRange(0, 2);

            var boardNums = new int[5, 5];
            var row = 0;

            var boards = new List<BingoBoard>();

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    // commit board
                    boards.Add(new BingoBoard(boardNums));
                    boardNums = new int[5, 5];
                    row = 0;
                    continue;
                }

                var s = line.Split(" ").ToList()
                    .Where(x => !string.IsNullOrWhiteSpace(x)).ToList()
                    .Select(int.Parse).ToList();

                for (var i = 0; i < s.Count; i++) boardNums[row, i] = s[i];

                row++;
            }

            // commit last board
            boards.Add(new BingoBoard(boardNums));

            return boards;
        }
    }
}
