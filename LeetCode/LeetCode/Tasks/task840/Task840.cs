using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task840
{
    /*
     840. Магические квадраты в сетке
    Магический квадрат — это 3 x 3 сетка, заполненная разными числами от 1 до 9, в которой сумма чисел в каждой строке, столбце и на обеих диагоналях одинакова.
    Если дано row x col grid целых чисел, то сколько существует 3 x 3 магических квадратов?
    Примечание: в то время как магический квадрат может содержать только числа от 1 до 9, grid может содержать числа до 15
    Ограничения:
        row == grid.length
        col == grid[i].length
        1 <= row, col <= 10
        0 <= grid[i][j] <= 15
    https://leetcode.com/problems/magic-squares-in-grid/description/
     */
    public class Task840 : InfoBasicTask
    {
        public Task840(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] grid = new int[][] {
                new int[] { 4,3,8,4 },
                new int[] { 9,5,1,9 },
                new int[] { 2,7,6,2 },
            };
            printTwoDimensionalArray(grid, "Исходная двумерная матрица");
            if (isValid(grid))
            {
                int res = numMagicSquaresInside(grid);
                Console.WriteLine($"Количество магических квадратов (Магический квадрат — это 3 x 3 сетка, заполненная разными числами от 1 до 9, в которой сумма чисел в каждой строке, столбце и на обеих диагоналях одинакова) = {res}");
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
            int lowLimitDimension = 1;
            int highLimitDimension = 10;
            int lowLimitValueCell = 0;
            int highLimitValueCell = 15;
            int countRows = grid.Length;
            if (countRows < lowLimitDimension || countRows > highLimitDimension)
            {
                return false;
            }
            int countCols = grid[0].Length;
            foreach (int[] row in grid)
            {
                if (row.Length < lowLimitDimension || row.Length > highLimitDimension || row.Length != countCols)
                {
                    return false;
                }
                foreach (int val in row)
                {
                    if (val < lowLimitValueCell || val > highLimitValueCell)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private int numMagicSquaresInside(int[][] grid)
        {
            int countMagicSquare = 0;
            int countRows = grid.Length;
            int countCols = grid[0].Length;
            for (int indexRow = 0; indexRow < countRows - 2; indexRow++)
            {
                for (int indexColumn = 0; indexColumn < countCols - 2; indexColumn++)
                {
                    HashSet<int> sums = new HashSet<int>();;
                    bool existValueOutsideRange = false;
                    bool[] arr = new bool[9];
                    int lowLimitRange = 1;
                    int highLimitRange = 9;
                    // сумма по строкам
                    for (int indexRowInSquare = indexRow; indexRowInSquare < indexRow + 3; indexRowInSquare++)
                    {
                        for (int indexColumnInSquare = indexColumn; indexColumnInSquare < indexColumn + 3; indexColumnInSquare++)
                        {
                            if (grid[indexRowInSquare][indexColumnInSquare] < lowLimitRange || grid[indexRowInSquare][indexColumnInSquare] > highLimitRange)
                            {
                                existValueOutsideRange = true;
                            }
                            else
                            {
                                arr[grid[indexRowInSquare][indexColumnInSquare] - 1] = true;
                            }
                        }
                    }
                    if (existValueOutsideRange)
                    {
                        continue;
                    }
                    bool allValuesFind = true;
                    foreach (bool flag in arr)
                    {
                        if (!flag)
                        {
                            allValuesFind = false;
                            break;
                        }
                    }
                    if (!allValuesFind)
                    {
                        continue;
                    }
                    // сумма по строкам
                    for (int indexRowInSquare = indexRow; indexRowInSquare < indexRow + 3; indexRowInSquare++)
                    {
                        int currentSum = 0;
                        for (int indexColumnInSquare = indexColumn; indexColumnInSquare < indexColumn + 3; indexColumnInSquare++)
                        {
                            currentSum += grid[indexRowInSquare][indexColumnInSquare];
                        }
                        sums.Add(currentSum);
                    }
                    // сумма по столбцам
                    for (int indexColumnInSquare = indexColumn; indexColumnInSquare <= indexColumn + 2; indexColumnInSquare++)
                    {
                        int currentSum = 0;
                        for (int indexRowInSquare = indexRow; indexRowInSquare <= indexRow + 2; indexRowInSquare++)
                        {
                            currentSum += grid[indexRowInSquare][indexColumnInSquare];
                        }
                        sums.Add(currentSum);
                    }
                    // сумма по главной диагонали
                    int sumOnMainDiagonal = grid[indexRow][indexColumn] + grid[indexRow+1][indexColumn + 1] + grid[indexRow + 2][indexColumn + 2];
                    int sumOnSecondaryDiagonal = grid[indexRow][indexColumn+2] + grid[indexRow + 1][indexColumn + 1] + grid[indexRow+2][indexColumn];
                    sums.Add(sumOnMainDiagonal);
                    sums.Add(sumOnSecondaryDiagonal);
                    if (sums.Count == 1)
                    {
                        countMagicSquare++;
                    }
                }
            }
            return countMagicSquare;
        }
    }
}
