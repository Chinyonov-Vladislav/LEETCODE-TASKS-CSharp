using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task54
{
    /*
     54. Спиральная матрица
    Учитывая m x n matrix, верните все элементы matrix в порядке спирали.
    Ограничения:
        m == matrix.length
        n == matrix[i].length
        1 <= m, n <= 10
        -100 <= matrix[i][j] <= 100
    https://leetcode.com/problems/spiral-matrix/description/
     */
    public class Task54 : InfoBasicTask
    {
        public Task54(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] matrix = new int[][] {
                new int[] {1,2,3,4 },
                new int[] {5,6,7,8},
                new int[] {9,10,11,12},
                new int[] {13,14,15,16 },
                new int[] {17,18,19,20 },
                new int[] {21,22,23,24 },
            };
            printTwoDimensionalArray(matrix, "Исходная двумерная матрица");
            if (isValid(matrix))
            {
                IList<int> res = spiralOrder(matrix);
                printIListInt(res, "Результат: ");
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
            int lowLimitMatrixItemValue = -100;
            int highLimitMatrixItemValue = 100;
            int lowLimit = 1;
            int highLimit = 10;
            int countRows = matrix.Length;
            if (countRows < lowLimit || countRows > highLimit)
            {
                return false;
            }
            int countColumns = matrix[0].Length;
            foreach (int[] row in matrix)
            {
                if (row.Length < lowLimit || row.Length > highLimit)
                {
                    return false;
                }
                foreach (int item in row)
                {
                    if (item < lowLimitMatrixItemValue || item > highLimitMatrixItemValue)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private IList<int> spiralOrder(int[][] matrix)
        {
            IList<int> result = new List<int>();
            int countRows = matrix.Length;
            int countColumns = matrix[0].Length;
            bool[][] visited = new bool[countRows][];
            for (int i = 0; i < visited.Length; i++)
            {
                visited[i] = new bool[countColumns];
            }
            int halfCountRows = countRows / 2;
            int halfCountColumns = countColumns / 2;
            int half = Math.Min(halfCountRows, halfCountColumns);
            for (int i = 0; i <= half; i++)
            {
                int currentIndexRow = i;
                int currentIndexColumn = i;
                while (currentIndexColumn < countColumns && !visited[currentIndexRow][currentIndexColumn])
                {
                    visited[currentIndexRow][currentIndexColumn] = true;
                    result.Add(matrix[currentIndexRow][currentIndexColumn]);
                    currentIndexColumn++;
                }
                currentIndexColumn--;
                currentIndexRow++;
                while (currentIndexRow < countRows && !visited[currentIndexRow][currentIndexColumn])
                {
                    visited[currentIndexRow][currentIndexColumn] = true;
                    result.Add(matrix[currentIndexRow][currentIndexColumn]);
                    currentIndexRow++;
                }
                currentIndexRow--;
                currentIndexColumn--;
                while (currentIndexColumn >= 0 && !visited[currentIndexRow][currentIndexColumn])
                {
                    visited[currentIndexRow][currentIndexColumn] = true;
                    result.Add(matrix[currentIndexRow][currentIndexColumn]);
                    currentIndexColumn--;
                }
                currentIndexColumn++;
                currentIndexRow--;
                while (currentIndexRow >= 0 && !visited[currentIndexRow][currentIndexColumn])
                {
                    visited[currentIndexRow][currentIndexColumn] = true;
                    result.Add(matrix[currentIndexRow][currentIndexColumn]);
                    currentIndexRow--;
                }
            }
            return result;
        }
    }
}
