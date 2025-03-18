using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task74
{
    /*
     74. Поиск по 2D-матрице
    Вам дается m x n целочисленная матрица matrix со следующими двумя свойствами:
        Каждая строка сортируется в порядке неубывания.
        Первое целое число в каждой строке больше последнего целого числа в предыдущей строке.
    Учитывая целое число target, верните значение, true если target оно находится в matrix или false иначе.
    Вы должны написать решение с O(log(m * n)) временной сложностью.
    Ограничения:
        m == matrix.length
        n == matrix[i].length
        1 <= m, n <= 100
        -10^4 <= matrix[i][j], target <= 10^4
    https://leetcode.com/problems/search-a-2d-matrix/description/
     */
    public class Task74 : InfoBasicTask
    {
        public Task74(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] matrix = new int[][] {
                new int[] { 1,3,5,7 },
                new int[] {10,11,16,20 },
                new int[] {23,30,34,60 }
            };
            int target = 3;
            printTwoDimensionalArray(matrix, "Исходная двумерная матрица");
            Console.WriteLine($"Целевое значение для поиска = {target}");
            if (isValid(matrix, target))
            {
                Console.WriteLine(searchMatrix(matrix, target) ? $"Целевое элемент со значением {target} найден в двумерной матрице" : $"Целевое элемент со значением {target} не найден в двумерной матрице");
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
            if (countRows < 1 || countRows > 100)
            {
                return false;
            }
            int lowLimitItem = -1* (int)Math.Pow(10, 4);
            int highLimitItem = (int)Math.Pow(10, 4);
            int countColumns = matrix[0].Length;
            foreach (int[] row in matrix)
            {
                if (row.Length < 1 || row.Length > 100 || row.Length != countColumns)
                {
                    return false;
                }
                foreach (int item in row)
                {
                    if (item < lowLimitItem || item > highLimitItem)
                    {
                        return false;
                    }
                }
            }
            if (target < lowLimitItem || target > highLimitItem)
            {
                return false;
            }
            for (int indexRow = 0; indexRow < countRows; indexRow++)
            {
                if (indexRow > 0 && matrix[indexRow][0] <= matrix[indexRow - 1][countColumns - 1])
                {
                    return false;
                }
                for (int indexColumn = 1; indexColumn < countColumns; indexColumn++)
                {
                    if (matrix[indexRow][indexColumn] < matrix[indexRow][indexColumn - 1])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private bool searchMatrix(int[][] matrix, int target)
        {
            int countRows = matrix.Length;
            int countCols = matrix[0].Length;
            foreach (int[] row in matrix)
            {
                if (row[0] <= target && target <= row[countCols - 1])
                {
                    int left = 0;
                    int right = row.Length - 1;
                    while (left <= right)
                    {
                        int mid = left + ((right - left) / 2);
                        if (row[mid] == target)
                        {
                            return true;
                        }
                        if (row[mid] < target)
                        {
                            left = mid + 1;
                        }
                        else
                        {
                            right = mid - 1;
                        }
                    }
                    return false;
                }
            }
            return false;
        }
    }
}
