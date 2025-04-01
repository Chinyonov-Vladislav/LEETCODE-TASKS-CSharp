using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task695
{
    /*
     695. Максимальная площадь острова
    Вам дана m x n двоичная матрица grid. Остров — это группа 1 (представляющих сушу) ячеек, соединённых четырьмя направлениями (горизонтальными или вертикальными.) Можно считать, что все четыре края сетки окружены водой.
    Площадь острова — это количество ячеек со значением 1 на острове.
    Верните максимальную площадь острова в grid. Если острова нет, верните 0.
    Ограничения:
        m == grid.length
        n == grid[i].length
        1 <= m, n <= 50
        grid[i][j] является либо 0, либо 1.
    https://leetcode.com/problems/max-area-of-island/description/
     */
    public class Task695 : InfoBasicTask
    {
        public Task695(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] grid = new int[][] {
                new int[] {1,1,0,0,0 },
                 new int[] {1,1,0,0,0 },
                  new int[] {0,0,0,1,1 },
                  new int[] {0,0,0,1,1 },
            };
            printTwoDimensionalArray(grid, "Карта в виде двумерного массива");
            if (isValid(grid))
            {
                int res = maxAreaOfIsland(grid);
                Console.WriteLine($"Площадь наибольшего острова = {res}");
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
            int highLimitDimension = 50;
            int countRows = grid.Length;
            if (countRows < lowLimitDimension || countRows > highLimitDimension)
            {
                return false;
            }
            int countColumns = grid[0].Length;
            foreach (int[] row in grid)
            {
                if (row.Length < lowLimitDimension || row.Length > highLimitDimension || row.Length != countColumns)
                {
                    return false;
                }
                foreach (int item in row)
                {
                    if (item < 0 || item > 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public int maxAreaOfIsland(int[][] grid)
        {
            int countRows = grid.Length;
            int countColumns = grid[0].Length;
            int maxArea = 0;
            bool[][] visited = new bool[countRows][];
            for (int i = 0; i < visited.Length; i++)
            {
                visited[i] = new bool[countColumns];
            }
            for (int indexRow = 0; indexRow < countRows; indexRow++)
            {
                for (int indexColumn = 0; indexColumn < countColumns; indexColumn++)
                {
                    if (grid[indexRow][indexColumn] == 1 && !visited[indexRow][indexColumn])
                    {
                        int localArea = 0;
                        Stack<int[]> queue = new Stack<int[]>();
                        queue.Push(new int[] { indexRow, indexColumn });
                        while (queue.Count > 0)
                        {
                            int[] currentCoordinates = queue.Pop();
                            if (!visited[currentCoordinates[0]][currentCoordinates[1]])
                            {
                                localArea++;
                            }
                            visited[currentCoordinates[0]][currentCoordinates[1]] = true;
                            List<int[]> nextCoordinates = new List<int[]>() {
                                 new int[] { currentCoordinates[0] -1, currentCoordinates[1] },
                                 new int[] { currentCoordinates[0] +1, currentCoordinates[1] },
                                 new int[] { currentCoordinates[0], currentCoordinates[1] +1 },
                                 new int[] { currentCoordinates[0], currentCoordinates[1] -1 } };
                            foreach (int[] nextCoord in nextCoordinates)
                            {
                                int numberNextRow = nextCoord[0];
                                int numberNextColumn = nextCoord[1];
                                if (numberNextRow >= 0 && numberNextRow < grid.Length && numberNextColumn >= 0 && numberNextColumn < grid[numberNextRow].Length)
                                {
                                    if (!visited[numberNextRow][numberNextColumn] && grid[numberNextRow][numberNextColumn] == 1)
                                    {
                                        queue.Push(new int[] { numberNextRow, numberNextColumn });
                                    }
                                }
                            }
                        }
                        if (localArea > maxArea)
                        {
                            maxArea = localArea;
                        }
                    }
                }
            }
            return maxArea;
        }
    }
}
