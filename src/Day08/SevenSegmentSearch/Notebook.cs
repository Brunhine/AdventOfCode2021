using System.Collections.Generic;
using System.Linq;
using AdventOfCodeCommon;

namespace SevenSegmentSearch
{
    public class Notebook
    {
        public List<NoteEntry> Entries { get; set; }

        public Notebook(List<NoteEntry> entries)
        {
            Entries = entries;
            
            DecodeEntries();
        }

        private void DecodeEntries()
        {
            DecodeSignalPatterns();
            
            SetOutputValues();
        }
        
        public int CountUniqueSegmentOutputs()
        {
            return Entries.Sum(entry => entry.OutputDigits.Count(x => x.Signal.Length is 2 or 3 or 4 or 7));
        }
        
        public int GetTotalOutputValues()
        {
            return Entries.Sum(entry => entry.OutputValue);
        }

        private void SetOutputValues()
        {
            foreach (var entry in Entries)
            foreach (var val in entry.OutputDigits)
                val.Value = entry.SignalPatterns.Single(v => v.Signal.SequenceEqual(val.Signal)).Value;
        }

        private void DecodeSignalPatterns()
        {
            foreach (var entry in Entries)
            {
                var one = entry.SignalPatterns.Single(x => x.Signal.Length == 2);
                one.Value = 1;

                var four = entry.SignalPatterns.Single(x => x.Signal.Length == 4);
                four.Value = 4;

                var seven = entry.SignalPatterns.Single(x => x.Signal.Length == 3);
                seven.Value = 7;

                var eight = entry.SignalPatterns.Single(x => x.Signal.Length == 7);
                eight.Value = 8;


                var midL = four.Signal.Except(one.Signal).ToArray();
                var botL = eight.Signal.Except(seven.Signal).Except(four.Signal).ToArray();

                entry.SignalPatterns.Single(x => x.Signal.Length == 6 && !x.Signal.IsSubset(midL)).Value = 0;
                entry.SignalPatterns.Single(x => x.Signal.Length == 6 && !x.Signal.IsSubset(one.Signal)).Value = 6;
                entry.SignalPatterns.Single(x => x.Signal.Length == 6 && !x.Signal.IsSubset(botL)).Value = 9;

                entry.SignalPatterns.Single(x => x.Signal.Length == 5 && x.Signal.IsSubset(botL)).Value = 2;
                entry.SignalPatterns.Single(x => x.Signal.Length == 5 && x.Signal.IsSubset(one.Signal)).Value = 3;
                entry.SignalPatterns.Single(x => x.Signal.Length == 5 && x.Signal.IsSubset(midL)).Value = 5;
            }
        }

        
    }
}
