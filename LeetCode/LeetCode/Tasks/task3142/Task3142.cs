using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3142
{
    /*
     3142. Проверьте, удовлетворяет ли сетка условиям
    Вам дана двумерная матрица grid размером m x n. Вам нужно проверить, является ли каждая ячейка grid[i][j]:
        Равен значению ячейки под ним, то есть grid[i][j] == grid[i + 1][j] (если оно существует).
        Отличается от ячейки справа от него, то есть grid[i][j] != grid[i][j + 1] (если она существует).
    Верните true, если все ячейки удовлетворяют этим условиям, в противном случае верните false.
    Ограничения:
        1 <= n, m <= 10
        0 <= grid[i][j] <= 9
    https://leetcode.com/problems/check-if-grid-satisfies-conditions/description/
     */
    public class Task3142 : InfoBasicTask
    {
        public Task3142(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] grid = new int[][] { 
                new int[] { 1,0,2 },
                new int[] {1,0,2 },
            };
            printTwoDimensionalArray(grid, "Двумерная матрица");
            if (isValid(grid))
            {
                Console.WriteLine(satisfiesConditions(grid) ?
                    "Двумерная матрица соответствует условиям: значение каждой ячейки равно значению ячейки под ней и значение каждой ячейки отличается от ячейки справа" :
                    "Двумерная матрица не соответствует условиям: значение каждой ячейки равно значению ячейки под ней и значение каждой ячейки отличается от ячейки справа");
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
            if (grid.Length < 1 || grid.Length > 10)
            {
                return false;
            }
            foreach (int[] row in grid) {
                if (row.Length < 1 || row.Length > 10)
                {
                    return false;
                }
                foreach (int item in row)
                {
                    if (item < 0 || item > 9)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private bool satisfiesConditions(int[][] grid)
        {
            for (int indexRow = 0; indexRow < grid.Length; indexRow++)
            {
                for (int indexColumn = 0; indexColumn < grid[indexRow].Length; indexColumn++)
                {
                    if (indexRow+1 < grid.Length && grid[indexRow][indexColumn] != grid[indexRow + 1][indexColumn])
                    {
                        return false;
                    }
                    if (indexColumn + 1 < grid[indexRow].Length && grid[indexRow][indexColumn] == grid[indexRow][indexColumn+1])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
