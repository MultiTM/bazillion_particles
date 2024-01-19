namespace _Project._Scripts.Infrastructure.Utils
{
    public static class ArrayExtensions
    {
        public static void Clean<T>(this T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = default;
            }
        }
    }
}