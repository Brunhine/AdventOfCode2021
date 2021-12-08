using System.Collections.Generic;
using System.Linq;

namespace SevenSegmentSearch
{
    public class NoteEntry
    {
        public List<Digit> SignalPatterns { get; }
        public List<Digit> OutputDigits { get; }

        public int OutputValue
        {
            get { return int.Parse(string.Concat(OutputDigits.Select(x => x.Value))); }
        }

        public NoteEntry(string inputLine)
        {
            var splits = inputLine.Split("|");

            SignalPatterns = splits[0].Trim().Split(" ").ToList().Select(s => new Digit(s)).ToList();
            OutputDigits = splits[1].Trim().Split(" ").ToList().Select(s => new Digit(s)).ToList();
        }
    }
}
