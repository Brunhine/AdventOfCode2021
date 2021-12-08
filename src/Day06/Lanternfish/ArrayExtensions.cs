namespace Lanternfish
{
    public static class ArrayExtensions
    {
        public static T[] ShiftLeft<T>(this T[] array)
        {
            var size = array.Length;
            T[] newArray = new T[size];
            for (var i = 0; i < size; i++) newArray[i] = array[(i + 1) % size];

            return newArray;
        }
    }
}