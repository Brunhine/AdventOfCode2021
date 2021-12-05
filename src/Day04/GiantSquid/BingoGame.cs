using System;
using System.Collections.Generic;
using System.Linq;

namespace GiantSquid
{
    public class BingoGame
    {
        private BingoBoard WinningBoard { get; set; }
        private int WinningNumber { get; set; }
        private int[] NumbersToDraw { get; }
        private IEnumerable<BingoBoard> Boards { get; }

        public BingoGame(int[] numbersToDraw, IEnumerable<BingoBoard> boards)
        {
            WinningBoard = null!;
            WinningNumber = 0;

            NumbersToDraw = numbersToDraw;
            Boards = boards;
        }

        public int RunGame()
        {
            foreach (var number in NumbersToDraw)
            {
                CallNumberAndCheckForWinner(number);

                if (Boards.All(b => b.HasWon)) break;
            }

            if (WinningBoard == null) throw new Exception("Winning board not found");

            var sum = WinningBoard.GetUnmarkedSum();
            return sum * WinningNumber;
        }

        private void CallNumberAndCheckForWinner(int number)
        {
            foreach (var board in Boards)
            {
                if (board.HasWon || !board.CallNumber(number))
                    continue;

                WinningBoard = board;
                WinningNumber = number;
            }
        }
    }
}
