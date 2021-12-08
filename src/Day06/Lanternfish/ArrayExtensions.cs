namespace Lanternfish
{
    public static class ArrayExtensions
    {
        public static long[] ShiftLeft(this long[] array)
        {
            var size = array.Length;
            long[] newArray = new long[size];
            for (var i = 0; i < size; i++) newArray[i] = array[(i + 1) % size];

            return newArray;
        }
    }
}
