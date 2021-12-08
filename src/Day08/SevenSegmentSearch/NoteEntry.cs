using System.Collections.Generic;

namespace SevenSegmentSearch
{
    public class NoteEntry
    {
        public List<string> SignalPatterns { get;}
        public List<string> OutPutValues { get; }

        public NoteEntry(List<string> signalPatterns, List<string> outPutValues)
        {
            SignalPatterns = signalPatterns;
            OutPutValues = outPutValues;
        }
    }
}
