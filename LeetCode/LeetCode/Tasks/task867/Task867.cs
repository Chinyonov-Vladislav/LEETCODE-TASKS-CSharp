using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task867
{
    /*
     867. Матрица транспонирования
    Учитывая двумерный целочисленный массив matrix, верните транспонирование из matrix.
    Транспонирование матрицы — это перестановка строк и столбцов матрицы относительно главной диагонали.
    https://leetcode.com/problems/transpose-matrix/description/
     */
    public class Task867 : InfoBasicTask
    {
        public Task867(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] matrix = new int[][] {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5,6 }
            };
            printTwoDimensionalArray(matrix, "Исходная матрица");
            int[][] transposeMatrix = transpose(matrix);
            printTwoDimensionalArray(transposeMatrix, "Транспонированная матрица");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int[][] transpose(int[][] matrix)
        {
            int countRows = matrix.Length;
            int countColumns = matrix[0].Length;
            int[][] result = new int[countColumns][];
            for (int row = 0; row < countColumns; row++)
            {
                result[row] = new int[countRows];
            }
            for (int row = 0; row < countRows; row++)
            {
                for (int column = 0; column < countColumns; column++)
                {
                    result[column][row] = matrix[row][column];
                }
            }
            return result;
        }
    }
}
