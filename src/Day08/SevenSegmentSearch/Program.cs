using System;
using System.IO;
using System.Linq;

namespace SevenSegmentSearch
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");

            var notebook = new Notebook(input.Select(x => new NoteEntry(x)).ToList());

            Console.WriteLine(notebook.Entries.Sum(x => x.OutputValue));
        }
    }
}
