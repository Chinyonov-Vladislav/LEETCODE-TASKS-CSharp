using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3033
{
    /*
     3033. Модифицируйте матрицу
    Учитывая целочисленную матрицу с индексацией 0 m x n matrix, создайте новую матрицу с индексацией 0 под названием answer. Сделайте answer равной matrix, затем замените каждый элемент значением -1 с максимальным элементом в соответствующем столбце.
    Верните матрицу answer.
    Ограничения:
        m == matrix.length
        n == matrix[i].length
        2 <= m, n <= 50
        -1 <= matrix[i][j] <= 100
        Входные данные формируются таким образом, что каждый столбец содержит хотя бы одно неотрицательное целое число.
    https://leetcode.com/problems/modify-the-matrix/description/
     */
    public class Task3033 : InfoBasicTask
    {
        public Task3033(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] matrix = new int[][] {
                new int[] { 1,2,-1 },
                 new int[] {4,-1,6 },
                  new int[] {7,8,9 },
            };
            printTwoDimensionalArray(matrix, "Исходная двумерная матрица");
            if (isValid(matrix))
            {
                int[][] res = modifiedMatrix(matrix);
                printTwoDimensionalArray(res, "Результирующая двумерная матрица");
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
            int countRows = matrix.Length;
            if (countRows < 2 || countRows > 50)
            {
                return false;
            }
            int countColumns = matrix[0].Length;
            foreach (int[] row in matrix)
            {
                if (row.Length != countColumns)
                {
                    return false;
                }
            }
            if (countColumns < 2 || countColumns > 50)
            {
                return false;
            }
            for (int indexColumn = 0; indexColumn < countColumns; indexColumn++)
            {
                bool existPositive = false;
                for (int indexRow = 0; indexRow < countRows; indexRow++)
                {
                    if (matrix[indexRow][indexColumn] >= 0)
                    {
                        existPositive = true;
                    }
                    if (matrix[indexRow][indexColumn] < -1 || matrix[indexRow][indexColumn] > 100)
                    {
                        return false;
                    }
                }
                if (!existPositive)
                {
                    return false;
                }
            }
            return true;
        }
        private int[][] modifiedMatrix(int[][] matrix)
        {
            int countRows = matrix.Length;
            int countColumns = matrix[0].Length;
            int[] maxInColumn = new int[countColumns];
            for (int indexColumn = 0; indexColumn < countColumns; indexColumn++)
            {
                int max = matrix[0][indexColumn];
                for (int indexRow = 1; indexRow < countRows; indexRow++)
                {
                    if (matrix[indexRow][indexColumn] > max)
                    {
                        max = matrix[indexRow][indexColumn];
                    }
                }
                maxInColumn[indexColumn] = max;
            }
            int[][] answer = new int[countRows][];
            for (int indexRow = 0; indexRow < answer.Length; indexRow++)
            {
                answer[indexRow] = new int[countColumns];
                for (int indexColumn = 0; indexColumn < answer[indexRow].Length; indexColumn++)
                {
                    if (matrix[indexRow][indexColumn] == -1)
                    {
                        answer[indexRow][indexColumn] = maxInColumn[indexColumn];
                    }
                    else
                    {
                        answer[indexRow][indexColumn] = matrix[indexRow][indexColumn];
                    }
                }
            }
            return answer;
        }
    }
}
