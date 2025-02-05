using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1351
{
    /*
     1351. Подсчет отрицательных чисел в отсортированной матрице
    Учитывая, что матрица m x n grid отсортирована в порядке неубывания как по строкам, так и по столбцам, верните количество отрицательных чисел в grid.
     https://leetcode.com/problems/count-negative-numbers-in-a-sorted-matrix/description/
     */
    public class Task1351 : InfoBasicTask
    {
        public Task1351(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] grid = new int[][] {
                new int[] {3,-1,-3,-3,-3},
                new int[] {2,-2,-3,-3,-3},
                new int[] {1,-2,-3,-3,-3},
                new int[] { 0, -3, -3, -3, -3 }
            };
            printTwoDimensionalArray(grid, "Исходная матрица");
            int countNegativeItems = countNegativesSecondMethod(grid);
            Console.WriteLine($"Количество отрицательных элементов в матрице = {countNegativeItems}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int countNegativesFirstMethod(int[][] grid)
        {
            int count = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = grid[i].Length - 1; j >= 0; j--)
                {
                    if (grid[i][j] < 0)
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return count;
        }
        private int countNegativesSecondMethod(int[][] grid)
        {
            int count = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                count+= binarySeacrhCountNegativeElementsInRow(grid[i]);
            }
            return count;
        }
        private int binarySeacrhCountNegativeElementsInRow(int[] row)
        {
            int left = 0;
            int right = row.Length - 1;
            int countNegative = 0;
            if (row[right] >= 0)
            {
                return countNegative;
            }
            while (left <= right)
            {
                if (row[left] < 0 && row[right] < 0)
                {
                    countNegative += right - left + 1;
                    break;
                }
                int mid = left + (right - left) / 2;
                if (row[mid] >= 0)
                {
                    left = mid + 1;
                }
                else
                {
                    countNegative += right - mid + 1;
                    right = mid-1;
                }
            }
            return countNegative;
        }
    }
}
