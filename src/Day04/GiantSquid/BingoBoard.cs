using System.Collections.Generic;
using System.Linq;

namespace GiantSquid
{
    public class BingoBoard
    {
        private BoardSpot[,] Board { get; }

        public BingoBoard(int[,] boardNumbers)
        {
            Board = new BoardSpot[5, 5];

            for (var i = 0; i < 5; i++)
            for (var j = 0; j < 5; j++)
                Board[i, j] = new BoardSpot(boardNumbers[i, j]);
        }

        public bool CallNumber(int numberCalled)
        {
            for (var i = 0; i < 5; i++)
            for (var j = 0; j < 5; j++)
            {
                var boardSpot = Board[i, j];
                if (boardSpot.IsMarked || boardSpot.Number != numberCalled)
                    continue;
                boardSpot.IsMarked = true;
                return GetIsWinner();
            }

            return false;
        }

        private bool GetIsWinner()
        {
            return CheckHorizontalWinner() || CheckVerticalWinner(); // || CheckDiagonalWinner();
        }

        private bool CheckHorizontalWinner()
        {
            for (var i = 0; i < 5; i++)
            {
                var row = GetRow(Board, i);
                if (row.All(x => x.IsMarked)) return true;
            }

            return false;
        }

        private bool CheckVerticalWinner()
        {
            for (var i = 0; i < 5; i++)
            {
                var col = GetColumn(Board, i);
                if (col.All(x => x.IsMarked))
                    return true;
            }

            return false;
        }

        private bool CheckDiagonalWinner()
        {
            return CheckLeftDiagonalWinner() || CheckRightDiagonalWinner();
        }

        private bool CheckLeftDiagonalWinner()
        {
            for (var i = 0; i < 5; i++)
                if (!Board[i, i].IsMarked)
                    return false;

            return true;
        }

        private bool CheckRightDiagonalWinner()
        {
            for (var i = 4; i > -1; i--)
                if (!Board[i, i].IsMarked)
                    return false;

            return true;
        }

        private static IEnumerable<BoardSpot> GetRow(BoardSpot[,] board, int rowNumber)
        {
            return Enumerable.Range(0, board.GetLength(0))
                .Select(x => board[rowNumber, x])
                .ToArray();
        }

        private static IEnumerable<BoardSpot> GetColumn(BoardSpot[,] board, int columnNumber)
        {
            return Enumerable.Range(0, board.GetLength(0))
                .Select(x => board[x, columnNumber])
                .ToArray();
        }

        public int GetUnmarkedSum()
        {
            var sum = 0;

            for (var i = 0; i < 5; i++)
            {
                var row = GetRow(Board, i);
                sum += row.Where(x => !x.IsMarked).Sum(x => x.Number);
            }

            return sum;
        }
    }
}
