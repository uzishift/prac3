
namespace LibCalc
{
    public class LibCalculator
    {
        /// <summary>
        /// Находит минимальный среди максимальных элементов строк массива.
        /// </summary>
        /// <param name="array">Массив, в котором нужно найти минимальный среди максимальных элементов строк массива.</param>
        /// <returns>Возвращает минимальный элемент</returns>
        public static int MinInMax(int[,] array)
        {
            int max = -1000;
            int min = 1000;
            int[] arrayMax = new int[array.GetLength(0)];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] > max) max = array[i, j];
                }
                arrayMax[i] = max;
                max = -1000;
            }
            for (int i = 0; i < arrayMax.Length; i++)
            {
                if (arrayMax[i] < min) min = arrayMax[i];
            }
            return min;
        }
    }
}