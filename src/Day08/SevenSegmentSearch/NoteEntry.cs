using System;
using System.Collections.Generic;
using System.Linq;

namespace SevenSegmentSearch
{
    public class NoteEntry
    {
        public List<Digit> SignalPatterns { get;}
        public List<Digit> OutputDigits { get; }

        public int OutputValue
        {
            get
            {
                return int.Parse(string.Concat(OutputDigits.Select(x => x.Value)));
            }
        }

        public NoteEntry(List<string> signalPatterns, List<string> outPutValues)
        {
            SignalPatterns = signalPatterns.Select(s => new Digit(s)).ToList();
            OutputDigits = outPutValues.Select(s => new Digit(s)).ToList();
        }
    }
}
