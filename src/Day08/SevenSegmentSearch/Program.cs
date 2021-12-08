using System;
using System.IO;
using System.Linq;

namespace SevenSegmentSearch
{
    public static class Program
    {
        //Segment count per number:
        // 0 : 6
        // 1 : 2 (unique)
        // 2 : 5
        // 3 : 5
        // 4 : 4 (unique)
        // 5 : 5
        // 6 : 6
        // 7 : 3 (unique)
        // 8 : 7 (unique)
        // 9 : 6
        public static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");

            var notebook = input.Select(GetNoteEntry).ToList();

            var sum = notebook.Sum(CountUniqueSegmentOutputs);
            
            Console.WriteLine(sum);
        }

        private static NoteEntry GetNoteEntry(string inputLine)
        {
            var splits = inputLine.Split("|");

            return new NoteEntry(splits[0].Trim().Split(" ").ToList(), splits[1].Trim().Split(" ").ToList());
        }

        private static int CountUniqueSegmentOutputs(NoteEntry entry)
        {
            return entry.OutPutValues.Count(x => x.Length is 2 or 3 or 4 or 7);
        }
    }
}