using System;

namespace SevenSegmentSearch
{
    public class Digit
    {
        public char[] Signal { get; set; }
        public int? Value { get; set; }

        public Digit(string signal)
        {
            Signal = signal.ToCharArray();
            Array.Sort(Signal);
            Value = null;
        }
    }
}