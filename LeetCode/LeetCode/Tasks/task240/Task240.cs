using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task240
{
    /*
     240. Поиск в 2D-матрице II
    Напишите эффективный алгоритм поиска значения target в m x n целочисленной матрице matrix. Эта матрица обладает следующими свойствами:
        Целые числа в каждой строке сортируются по возрастанию слева направо.
        Целые числа в каждом столбце отсортированы по возрастанию сверху вниз.
     Ограничения:
        m == matrix.length
        n == matrix[i].length
        1 <= n, m <= 300
        -10^9 <= matrix[i][j] <= 10^9
        Все целые числа в каждой строке отсортированы в порядке возрастания.
        Все целые числа в каждом столбце отсортированы в порядке возрастания.
        -10^9 <= target <= 10^9
     */
    public class Task240 : InfoBasicTask
    {
        public Task240(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] matrix = new int[][] {
                new int[] { 1,4,7,11,15 },
                new int[] { 2,5,8,12,19 },
                new int[] { 3,6,9,16,22 },
                new int[] { 10,13,14,17,24 },
                new int[] { 18,21,23,26,30 },
            };
            printTwoDimensionalArray(matrix, "Исходная двумерная матрица");
            int target = 5;
            Console.WriteLine($"Искомое значение = {target}");
            if (isValid(matrix, target))
            {
                Console.WriteLine(searchMatrix(matrix, target) ? $"Значение {target} было найдено в двумерной матрице" : $"Значение {target} не было найдено в двумерной матрице");
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
        private bool isValid(int[][] matrix, int target)
        {
            int countRows = matrix.Length;
            int lowLimitDimension = 1;
            int highLimitDimension = 300;
            int lowLimitValueInMatrix = -1*(int)Math.Pow(10,9);
            int highLimitValueInMatrix =  (int)Math.Pow(10, 9);
            int lowLimitTarget = -1 * (int)Math.Pow(10, 9);
            int highLimitTarget = (int)Math.Pow(10, 9);
            if (countRows < lowLimitDimension || countRows > highLimitDimension)
            {
                return false;
            }
            int countColumns = matrix[0].Length;
            foreach (int[] row in matrix)
            {
                if (row.Length != countColumns && countColumns < lowLimitDimension || countColumns > highLimitDimension)
                {
                    return false;
                }
                foreach (int itemVal in row)
                {
                    if (itemVal < lowLimitValueInMatrix || itemVal > highLimitValueInMatrix)
                    {
                        return false;
                    }
                }
            }
            for (int indexRow = 0; indexRow < countRows; indexRow++)
            {
                int[] row = matrix[indexRow];
                for (int i = 1; i < row.Length; i++)
                {
                    if (row[i - 1] >= row[i])
                    {
                        return false;                    
                    }
                }
            }
            for (int indexColumn = 0; indexColumn < countColumns; indexColumn++)
            {
                for (int indexRow = 1; indexRow < countRows; indexRow++)
                {
                    if (matrix[indexRow-1][indexColumn] >= matrix[indexRow][indexColumn])
                    {
                        return false;
                    }
                }
            }
            if (target < lowLimitTarget || target > highLimitTarget)
            {
                return false;
            }
            return true;
        }
        private bool searchMatrix(int[][] matrix, int target)
        {
            for (int indexRow = 0; indexRow < matrix.Length; indexRow++)
            {
                int[] row = matrix[indexRow];
                int left = 0;
                int right = row.Length - 1;
                while (left <= right)
                {
                    int mid = left + (right - left) / 2;
                    if (row[mid] == target)
                    {
                        return true;
                    }
                    else if (row[mid] > target)
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
            }
            return false;
        }
        // скопировано с leetcode
        private bool bestSolution(int[][] matrix, int target)
        {
            int rowCount = matrix.Length - 1;
            int colCount = matrix[0].Length - 1;

            int rowPosition = 0;
            int colPosition = colCount;

            while (rowPosition <= rowCount && colPosition >= 0)
            {
                if (matrix[rowPosition][colPosition] == target)
                {
                    return true;
                }
                if (matrix[rowPosition][colPosition] < target)
                {
                    rowPosition++;
                }
                else
                {
                    colPosition--;
                }
            }
            return false;
        }
    }
}
