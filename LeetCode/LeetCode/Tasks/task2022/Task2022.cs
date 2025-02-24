using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2022
{
    /*
     2022. Преобразование одномерного массива в двумерный
    Вам предоставляется 0-индексированный одномерный (1D) массив целых чисел original и два целых числа, m и n. 
    Вам поручено создать двумерный (2D) массив с  m строками и n столбцами, используя все элементы из original.
    Элементы с индексами от 0 до n - 1 (включительно) в original должны образовывать первую строку созданного двумерного массива, элементы с индексами от n до 2 * n - 1 (включительно) должны образовывать вторую строку созданного двумерного массива и так далее.
    Верните двумерный m x nмассив, созданный в соответствии с описанной выше процедурой, или пустой двумерный массив, если это невозможно.
    https://leetcode.com/problems/convert-1d-array-into-2d-array/description/
     */
    public class Task2022 : InfoBasicTask
    {
        public Task2022(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array = new int[] { 1, 2, 3, 4 };
            printArray(array, "Исходный массив: ");
            int countRows = 2;
            int countColumns = 2;
            Console.WriteLine($"Количество строк в результирующем двумерном массиве = {countRows}");
            Console.WriteLine($"Количество столбцов в результирующем двумерном массиве = {countColumns}");
            int[][] resultArray = construct2DArray( array, countRows, countColumns );
            printTwoDimensionalArray(resultArray, "Результирующий двумерный массив");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int[][] construct2DArray(int[] original, int m, int n)
        {
            if (original.Length != m * n)
            {
                return new int[0][];
            }
            int[][] result = new int[m][];
            int index = 0;
            for (int i = 0; i < m; i++)
            {
                result[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    result[i][j] = original[index];
                    index++;
                }
            }
            return result;
        }
    }
}
