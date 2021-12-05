using System;
using System.Collections.Generic;

namespace GiantSquid
{
    public class BingoGame
    {
        private BingoBoard winningBoard;
        private int winningNumber;
        public int[] NumbersToDraw { get; }
        public IEnumerable<BingoBoard> Boards { get; }

        public BingoGame(int[] numbersToDraw, IEnumerable<BingoBoard> boards)
        {
            winningBoard = null!;
            winningNumber = 0;

            NumbersToDraw = numbersToDraw;
            Boards = boards;
        }

        public int RunGame()
        {
            foreach (var number in NumbersToDraw)
            {
                CallNumberAndCheckForWinner(number);

                if (winningBoard != null) break;
            }

            if (winningBoard == null) throw new Exception("Winning board not found");

            var sum = winningBoard.GetUnmarkedSum();
            return sum * winningNumber;
        }

        private void CallNumberAndCheckForWinner(int number)
        {
            foreach (var board in Boards)
            {
                if (!board.CallNumber(number))
                    continue;

                winningBoard = board;
                winningNumber = number;
                break;
            }
        }
    }
}
