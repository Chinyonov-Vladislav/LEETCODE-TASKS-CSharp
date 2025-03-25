using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task73
{
    /*
     73. Установите нули в матрице
    Дана m x n целочисленная матрица matrix, если элемент равен 0, то установите для всей его строки и столбца значение 0's.
    Вы должны сделать это на месте.
    Ограничения:
        m == matrix.length
        n == matrix[0].length
        1 <= m, n <= 200
        -2^31 <= matrix[i][j] <= 2^31 - 1
    https://leetcode.com/problems/set-matrix-zeroes/description/
     */
    public class Task73 : InfoBasicTask
    {
        public Task73(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] matrix = new int[][] {
                new int[] {0,1,2,0 },
                new int[] {3,4,5,2 },
                new int[] {1,3,1,5 }
            };
            printTwoDimensionalArray(matrix, "Исходная двумерная матрица");
            if (isValid(matrix))
            {
                setZeroes(matrix);
                printTwoDimensionalArray(matrix, "Конечная двумерная матрица");
            }
            else
            {
                printInfoNotValidData();
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(int[][] matrix)
        {
            int lowLimit = 1;
            int highLimit = 200;
            int countRows = matrix.Length;
            if (countRows < lowLimit || countRows > highLimit)
            {
                return false;
            }
            int countColumns = matrix[0].Length;
            foreach (int[] row in matrix)
            {
                if (row.Length < lowLimit || row.Length > highLimit || row.Length != countColumns)
                {
                    return false;
                }
            }
            return true;
        }
        private void setZeroes(int[][] matrix)
        {
            List<int[]> points = new List<int[]>();
            int countRows = matrix.Length;
            int countColumns = matrix[0].Length;
            for (int indexRow = 0; indexRow < countRows; indexRow++)
            {
                for (int indexColumn = 0; indexColumn < countColumns; indexColumn++)
                {
                    if (matrix[indexRow][indexColumn] == 0)
                    {
                        points.Add(new int[] { indexRow, indexColumn });
                    }
                }
            }
            foreach (int[] point in points)
            {
                for (int indexRow = 0; indexRow < countRows; indexRow++)
                {
                    matrix[indexRow][point[1]] = 0;
                }
                for (int indexColumn = 0; indexColumn < countColumns; indexColumn++)
                {
                    matrix[point[0]][indexColumn] = 0;
                }
            }
        }
    }
}
