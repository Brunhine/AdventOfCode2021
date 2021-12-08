using System.IO;
using System.Linq;
using NUnit.Framework;
using SevenSegmentSearch;

namespace SevenSegmentSearch_Tests
{
    public class SevenSegmentSearchTests
    {
        private readonly string[] partTwoSample;
        private readonly string[] testInput;

        public SevenSegmentSearchTests()
        {
            testInput = File.ReadAllLines("test_input.txt");
            partTwoSample = File.ReadAllLines("part2_sample_input.txt");
        }

        [Test]
        public void PartOneTests()
        {
            var notebook = new Notebook(testInput.Select(x => new NoteEntry(x)).ToList());

            Assert.AreEqual(26, notebook.CountUniqueSegmentOutputs());
        }

        [Test]
        public void PartTwoSmallTest()
        {
            var notebook = new Notebook(partTwoSample.Select(x => new NoteEntry(x)).ToList());

            Assert.AreEqual(5353, notebook.GetTotalOutputValues());
        }

        [Test]
        public void PartTwoLargeTest()
        {
            var notebook = new Notebook(testInput.Select(x => new NoteEntry(x)).ToList());

            Assert.AreEqual(61229, notebook.GetTotalOutputValues());
        }
    }
}
