using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3402
{
    /*
     3402. Минимум операций для того, чтобы столбцы строго увеличивались
    Вам дана матрица m x n grid состоящая из неотрицательных целых чисел.
    За одну операцию вы можете увеличить значение любого grid[i][j] на 1.
    Верните минимальное количество операций, необходимых для того, чтобы все столбцы были grid строго возрастающими.
    Ограничения:
        m == grid.length
        n == grid[i].length
        1 <= m, n <= 50
        0 <= grid[i][j] < 2500
    https://leetcode.com/problems/minimum-operations-to-make-columns-strictly-increasing/description/
     */
    public class Task3402 : InfoBasicTask
    {
        public Task3402(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] grid = new int[][] { 
                new int[]{ 3,2,1 },
                new int[]{ 2,1,0 },
                new int[]{ 1, 2, 3 }
            };
            printTwoDimensionalArray(grid, "Исходный двумерный массив: ");
            if (isValid(grid))
            {
                int min = minimumOperations(grid);
                Console.WriteLine($"Минимальное количество операций увеличения элемента двумерного массива на 1 для того, чтобы элементы в столбце были строго возрастающими = {min}");
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
        private bool isValid(int[][] grid)
        {
            int m = grid.Length;
            if (m < 1 || m > 50)
            {
                return false;
            }
            int n = grid[0].Length;
            foreach (int[] row in grid)
            {
                if (row.Length != n)
                {
                    return false;
                }
            }
            if (n < 1 || n > 50)
            {
                return false;
            }
            foreach (int[] row in grid)
            {
                foreach (int item in row)
                {
                    if (item < 0 || item >= 2500)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private int minimumOperations(int[][] grid)
        {
            int count = 0;
            int countRows = grid.Length;
            int countCols = grid[0].Length;
            for (int indexColumn = 0; indexColumn < countCols; indexColumn++)
            {
                for (int indexRow = 1; indexRow < countRows; indexRow++)
                {
                    if (grid[indexRow][indexColumn] <= grid[indexRow - 1][indexColumn])
                    {
                        int difference = grid[indexRow - 1][indexColumn] - grid[indexRow][indexColumn] + 1;
                        count += difference;
                        grid[indexRow][indexColumn] += difference;
                    }
                    
                }
            }
            return count;
        }
    }
}
