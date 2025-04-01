using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task48
{
    /*
     48. Поворот изображения
    Вам дан n x n 2D-объект matrix в виде изображения, поверните изображение на 90 градусов (по часовой стрелке).
    Вам нужно повернуть изображение на месте, то есть изменить входную двумерную матрицу напрямую. НЕ выделяйте другую двумерную матрицу и не выполняйте поворот.
    Ограничения:
        n == matrix.length == matrix[i].length
        1 <= n <= 20
        -1000 <= matrix[i][j] <= 1000
    https://leetcode.com/problems/rotate-image/description/
     */
    public class Task48 : InfoBasicTask
    {
        public Task48(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] matrix = new int[][] {
                new int[] {1,2,3 },
                new int[] {4,5,6 },
                new int[] {7,8,9 }
            };
            printTwoDimensionalArray(matrix, "Исходная двумерная матрица");
            if (isValid(matrix))
            {
                rotate(matrix);
                printTwoDimensionalArray(matrix, "Матрица, повернутая на 90 градусов");
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
            int highLimit = 20;
            int lowLimitCellValue = -1000;
            int highLimitCellValue = 1000;
            int n = matrix.Length;
            if (n < lowLimit || n > highLimit)
            {
                return false;
            }
            foreach (int[] row in matrix)
            {
                if (row.Length != n)
                {
                    return false;
                }
                foreach (int item in row)
                {
                    if (item < lowLimitCellValue || item > highLimitCellValue)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private void rotate(int[][] matrix)
        {
            int countRowsAndColumns = matrix.Length;
            for (int index = 0; index < matrix.Length; index++)
            {
                int currentIndexRow = index+1;
                int currentIndexColumn = index;
                while (currentIndexRow < countRowsAndColumns)
                {
                    (matrix[currentIndexRow][currentIndexColumn], matrix[currentIndexColumn][currentIndexRow]) = (matrix[currentIndexColumn][currentIndexRow], matrix[currentIndexRow][currentIndexColumn]);
                    currentIndexRow++;
                }
            }
            int indexStartColumn = 0;
            int indexLastColumn = countRowsAndColumns - 1;
            while (indexStartColumn < indexLastColumn)
            {
                for (int indexRow = 0; indexRow < countRowsAndColumns; indexRow++)
                {
                    (matrix[indexRow][indexStartColumn], matrix[indexRow][indexLastColumn]) = (matrix[indexRow][indexLastColumn], matrix[indexRow][indexStartColumn]);
                }
                indexStartColumn++;
                indexLastColumn--;
            }
        }
    }
}
