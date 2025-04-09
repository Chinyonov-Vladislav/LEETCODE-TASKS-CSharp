using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task304
{
    public class NumMatrix
    {
        private int[][] prefixSum;
        public NumMatrix(int[][] matrix)
        {
            int countRows = matrix.Length;
            int countCols = matrix[0].Length;
            prefixSum = new int[countRows][];
            for (int i = 0; i < prefixSum.Length; i++)
            {
                prefixSum[i] = new int[countCols];
            }
            prefixSum[0][0] = matrix[0][0];
            for (int i = 1; i < countCols; i++) //заполнение первой строки
            {
                prefixSum[0][i] = prefixSum[0][i - 1] + matrix[0][i];
            }
            for (int i = 1; i < countRows; i++) //заполнение первого столбца
            {
                prefixSum[i][0] = prefixSum[i - 1][0] + matrix[i][0];
            }
            for (int i = 1; i < countRows; i++)
            {
                for (int j = 1; j < countCols; j++)
                {
                    prefixSum[i][j] = prefixSum[i - 1][j] +
                                prefixSum[i][j - 1] -
                                prefixSum[i - 1][j - 1] +
                                matrix[i][j];
                }
            }

        }

        public int SumRegion(int row1, int col1, int row2, int col2)
        {
            int countRow = prefixSum.Length;
            int countCols = prefixSum[0].Length;
            int sum = prefixSum[row2][col2];
            int firstNewRow = row1 - 1;
            int firstNewCol = col2;
            if (firstNewRow >= 0 && firstNewRow < countRow && firstNewCol >= 0 && firstNewCol < countCols)
            {
                sum -= prefixSum[firstNewRow][firstNewCol];
            }
            int secondNewRow = row2;
            int secondNewCol = col1 - 1;
            if (secondNewRow >= 0 && secondNewRow < countRow && secondNewCol >= 0 && secondNewCol < countCols)
            {
                sum -= prefixSum[secondNewRow][secondNewCol];
            }
            int thirdNewRow = row1 - 1;
            int thirdNewCol = col1 - 1;
            if (thirdNewRow >= 0 && thirdNewRow < countRow && thirdNewCol >= 0 && thirdNewCol < countCols)
            {
                sum += prefixSum[thirdNewRow][thirdNewCol];
            }
            return sum;
        }
    }
}
