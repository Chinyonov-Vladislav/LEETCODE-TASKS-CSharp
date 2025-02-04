using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1260
{
    /*
     1260. Сдвиг 2D Сетки
    Задано значение 2D grid размера m x n и целое число k. Вам нужно сдвинуть grid k времена.
    За один цикл работы:
        Элемент в grid[i][j] перемещается в grid[i][j + 1].
        Элемент в grid[i][n - 1] перемещается в grid[i + 1][0].
        Элемент в grid[m - 1][n - 1] перемещается в grid[0][0].
    Верните 2D-сетку после применения операции сдвига k раз.
    https://leetcode.com/problems/shift-2d-grid/description/
     */
    public class Task1260 : InfoBasicTask
    {
        public Task1260(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] grid = new int[][] {
                new int[] {3,8,1,9 },
                new int[] {19,7,2,5 },
                new int[] {4,6,11,10 },
                new int[] {12,0,21,13 },
            };
            printTwoDimensionalArray(grid, "Исходная матрица");
            int k = 4;
            Console.WriteLine($"Количество сдвигов = {k}");
            IList<IList<int>> result = shiftGrid(grid, k);
            printTwoDimensionalListInt(result, "Результирующий двумерный список");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private IList<IList<int>> shiftGrid(int[][] grid, int k)
        {
            int countRows = grid.Length; 
            int countColumns = grid[0].Length;
            for (int i = 0; i < k; i++)
            {
                for (int indexRow = 0; indexRow < countRows; indexRow++)
                {
                    (grid[indexRow][0], grid[indexRow][countColumns - 1]) = (grid[indexRow][countColumns - 1], grid[indexRow][0]);
                }
                printTwoDimensionalListInt(grid, "ПУНКТ 1");
                for (int indexRow = countRows - 1; indexRow > 0; indexRow--)
                {
                    (grid[indexRow][0], grid[indexRow-1][0]) = (grid[indexRow-1][0], grid[indexRow][0]);
                }
                for (int indexColumn = countColumns - 1; indexColumn > 1; indexColumn--)
                {
                    for (int indexRow = 0; indexRow < countRows; indexRow++)
                    {
                        (grid[indexRow][indexColumn], grid[indexRow][indexColumn - 1]) = (grid[indexRow][indexColumn - 1], grid[indexRow][indexColumn]);
                    }
                }
            }
            IList<IList<int>> result = new List<IList<int>>();
            for (int i = 0; i < grid.Length; i++)
            {
                result.Add(new List<int>());
                for (int j = 0; j < grid[i].Length; j++)
                {
                    result[result.Count-1].Add(grid[i][j]);
                }
            }
            return result;
        }
    }
}
