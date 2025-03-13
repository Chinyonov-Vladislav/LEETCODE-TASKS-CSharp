using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3417
{
    /*
     3417. Зигзагообразный обход сетки с пропуском
    Вам дан m x n двумерный массив grid положительных целых чисел.
    Ваша задача — пройти grid по зигзагообразной траектории, пропуская каждую попеременную ячейку.
    Обход зигзагообразного рисунка определяется следующими действиями:
        Начните с верхней левой ячейки (0, 0).
        Двигайтесь вправо по ряду, пока не достигнете его конца.
        Перейдите на следующий ряд, затем двигайтесь влево до начала ряда.
        Продолжайте чередовать обход справа и слева, пока не пройдёте по всем строкам.
    Обратите внимание, что при обходе вы должны пропускать каждую попеременную ячейку.
    Верните массив целых чисел result, содержащий в порядке следования значения ячеек, посещённых во время зигзагообразного обхода с пропусками.
    Ограничения:
        2 <= n == grid.length <= 50
        2 <= m == grid[i].length <= 50
        1 <= grid[i][j] <= 2500
    https://leetcode.com/problems/zigzag-grid-traversal-with-skip/description/
     */
    public class Task3417 : InfoBasicTask
    {
        public Task3417(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] grid = new int[][]
            {
                new int[] {1,2,3 },
                new int[] {4,5,6 },
                new int[] {7,8,9 },
            };
            printTwoDimensionalArray(grid, "Двумераня матрица");
            if (isValid(grid))
            {
                IList<int> items = zigzagTraversal(grid);
                printIListInt(items, "Список целых чисел, содержащий в порядке следования значения ячеек, посещённых во время зигзагообразного обхода с пропусками каждой попеременной ячейки: ");
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
            if (grid.Length < 2 || grid.Length > 50)
            {
                return false;
            }
            int m = grid[0].Length;
            foreach (int[] row in grid)
            {
                if (row.Length < 2 || row.Length > 50 || m != row.Length)
                {
                    return false;
                }
                foreach (int item in row)
                {
                    if (item < 1 || item > 2500)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private IList<int> zigzagTraversal(int[][] grid)
        {
            IList<int> result = new List<int>();
            bool isLeftToRight = true;
            bool isSkip = false;
            for (int indexRow = 0; indexRow < grid.Length; indexRow++)
            {
                if (isLeftToRight)
                {
                    for (int indexCol = 0; indexCol < grid[indexRow].Length; indexCol++)
                    {
                        if (!isSkip)
                        {
                            result.Add(grid[indexRow][indexCol]);
                        }
                        isSkip = !isSkip;
                    }
                    isLeftToRight = !isLeftToRight;
                }
                else
                {
                    for (int indexCol = grid[indexRow].Length-1; indexCol >= 0; indexCol--)
                    {
                        if (!isSkip)
                        {
                            result.Add(grid[indexRow][indexCol]);
                        }
                        isSkip = !isSkip;
                    }
                    isLeftToRight = !isLeftToRight;
                }
            }
            return result;
        }
    }
}
