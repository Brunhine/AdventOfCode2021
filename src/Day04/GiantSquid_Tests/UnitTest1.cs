using System.Collections.Generic;
using System.IO;
using GiantSquid;
using NUnit.Framework;

namespace GiantSquid_Tests
{
    public class Tests
    {
        private IEnumerable<BingoBoard> boards = null!;
        private int[] numbersToDraw = null!;

        [SetUp]
        public void Setup()
        {
            var lines = File.ReadAllLines("test_input.txt");

            numbersToDraw = Program.GetNumbersToDraw(lines);

            boards = Program.GetBingoBoards(lines);
        }

        [Test]
        public void TestSampleGame()
        {
            var game = new BingoGame(numbersToDraw, boards);

            Assert.AreEqual(1924, game.RunGame());
        }
    }
}
