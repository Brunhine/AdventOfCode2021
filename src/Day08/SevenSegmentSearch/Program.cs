using System;
using System.IO;
using System.Linq;
using AdventOfCodeCommon;

namespace SevenSegmentSearch
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");

            var notebook = input.Select(GetNoteEntry).ToList();

            foreach (var entry in notebook) DecodeEntry(entry);

            Console.WriteLine(notebook.Sum(x => x.OutputValue));
        }

        private static NoteEntry GetNoteEntry(string inputLine)
        {
            var splits = inputLine.Split("|");

            return new NoteEntry(splits[0].Trim().Split(" ").ToList(), splits[1].Trim().Split(" ").ToList());
        }

        private static void DecodeEntry(NoteEntry entry)
        {
            DecodeSignalPatterns(entry);

            foreach (var val in entry.OutputDigits)
                val.Value = entry.SignalPatterns.Single(v => v.Signal.SequenceEqual(val.Signal)).Value;
        }

        private static void DecodeSignalPatterns(NoteEntry entry)
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

        private static int CountUniqueSegmentOutputs(NoteEntry entry)
        {
            return entry.OutputDigits.Count(x => x.Signal.Length is 2 or 3 or 4 or 7);
        }
    }
}