using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2373
{
    /*
     2373. Наибольшие локальные значения в матрице
    Вам дана n x n целочисленная матрица grid.
    Сгенерируйте целочисленную матрицу maxLocal такого размера (n - 2) x (n - 2), чтобы:
        maxLocal[i][j] равно наибольшему значению матрицы 3 x 3 в grid по центру строки i + 1 и столбца j + 1.
    Другими словами, мы хотим найти наибольшее значение в каждой непрерывной матрице 3 x 3 в grid.
    Возвращает сгенерированную матрицу.
    Ограничения:
        n == grid.length == grid[i].length
        3 <= n <= 100
        1 <= grid[i][j] <= 100
    https://leetcode.com/problems/largest-local-values-in-a-matrix/description/
     */
    public class Task2373 : InfoBasicTask
    {
        public Task2373(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] matrix = new int[][] {
                new int[]{9,9,8,1 },
                 new int[]{5,6,2,6 },
                  new int[]{8,2,6,4 },
                   new int[]{ 6,2,2,2},
            };
            printTwoDimensionalArray(matrix, "Исходная матрица");
            if (isValid(matrix))
            {
                int[][] mat = largestLocal(matrix);
                printTwoDimensionalArray(mat, "Результирующая матрица");
            }
            else
            {
                Console.WriteLine($"Исходная матрица не валидна, так как не является квадратной!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(int[][] grid)
        {
            int countRows = grid.Length;
            for (int i = 0; i < grid.Length; i++)
            {
                if (grid[i].Length != countRows)
                {
                    return false;
                }
            }
            return true;
        }
        private int[][] largestLocal(int[][] grid)
        {
            int newSize = grid.Length-2;
            int[][] result = new int[newSize][];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new int[newSize];
            }
            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result[i].Length; j++)
                {
                    int max = grid[i][j];
                    for (int index1 = i; index1 <= i + 2; index1++)
                    {
                        for (int index2 = j; index2 <= j + 2; index2++)
                        {
                            if (grid[index1][index2] > max)
                            {
                                max = grid[index1][index2];
                            }
                        }
                    }
                    result[i][j] = max;
                }
            }
            return result;
        }
    }
}
