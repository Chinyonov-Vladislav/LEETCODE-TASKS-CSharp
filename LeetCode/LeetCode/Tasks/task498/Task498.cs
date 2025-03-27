using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task498
{
    /*
     498. Диагональный обход матрицы
    Учитывая матрицу m x n mat, верните массив всех элементов матрицы в диагональном порядке.
    Ограничения:
        m == mat.length
        n == mat[i].length
        1 <= m, n <= 104
        1 <= m * n <= 104
        -10^5 <= mat[i][j] <= 10^5
    https://leetcode.com/problems/diagonal-traverse/description/
     */
    public class Task498 : InfoBasicTask
    {
        public Task498(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] mat = new int[][]{
                new int[] { 1,2 },
                new int[] {4,5 },
                new int[] {7,8 }
            };
            printTwoDimensionalArray(mat, "Исходная двумерная матрица");
            if (isValid(mat))
            {
                int[] res = findDiagonalOrder(mat);
                printArray(res, "Элементы матрицы в диагональном порядке: ");
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
        private bool isValid(int[][] mat)
        {
            int lowLimitCountDimension = 1;
            int highLimitCountDimension = (int)Math.Pow(10,4);
            int lowLimitCellValue = -1 * (int)Math.Pow(10, 5);
            int highLimitCellValue = (int)Math.Pow(10, 5);
            int countRows = mat.Length;
            if (countRows < lowLimitCountDimension || countRows > highLimitCountDimension)
            {
                return false;
            }
            int countColumns = mat[0].Length;
            foreach (int[] row in mat)
            {
                if (row.Length < lowLimitCountDimension || row.Length > highLimitCountDimension || row.Length != countColumns)
                {
                    return false;
                }
                foreach (int cellValue in row)
                {
                    if (cellValue < lowLimitCellValue || cellValue > highLimitCellValue)
                    {
                        return false;
                    }
                }
            }
            int mult = countRows * countColumns;
            if (mult < lowLimitCountDimension || mult > highLimitCountDimension)
            {
                return false;
            }
            return true;
        }
        private int[] findDiagonalOrder(int[][] mat)
        {
            int countRows = mat.Length;
            int countCols = mat[0].Length;
            int index = 0;
            int[] res = new int[countRows * countCols];
            int indexRow = 0;
            int indexCol = 0;
            int[][] points = new int[countCols + countRows - 1][];
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new int[] { indexRow, indexCol };
                if (indexRow < countRows - 1)
                {
                    indexRow++;
                }
                else
                {
                    indexCol++;
                }
            }
            int numberDiagonal = 0;
            foreach (int[] arr in points)
            {
                indexRow = arr[0];
                indexCol = arr[1];
                if (numberDiagonal % 2 == 0)
                {
                    while (indexRow >= 0 && indexRow < countRows && indexCol>=0 && indexCol<countCols)
                    {
                        res[index] = mat[indexRow][indexCol];
                        index++;
                        indexRow--;
                        indexCol++;
                    }
                }
                else
                {
                    while (indexRow >= 0 && indexRow < countRows && indexCol >= 0 && indexCol < countCols)
                    {
                        indexRow--;
                        indexCol++;
                    }
                    indexRow++;
                    indexCol--;
                    while (indexRow >= 0 && indexRow < countRows && indexCol >= 0 && indexCol < countCols)
                    {
                        res[index] = mat[indexRow][indexCol];
                        index++;
                        indexRow++;
                        indexCol--;
                    }
                }
                numberDiagonal++;
            }
            return res;
        }
    }
}
