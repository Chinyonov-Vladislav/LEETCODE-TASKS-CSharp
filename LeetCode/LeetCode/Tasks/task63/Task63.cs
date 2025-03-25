using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task63
{
    /*
     63. Уникальные пути II
    Вам дан m x n целочисленный массив grid. Робот изначально находится в верхнем левом углу (т. е. grid[0][0]). 
    Робот пытается переместиться в нижний правый угол (т. е. grid[m - 1][n - 1]). В любой момент времени робот может двигаться только вниз или вправо.
    Препятствие и свободное пространство обозначаются как 1 или 0 соответственно в grid. Путь, по которому движется робот, не может включать ни один квадрат, являющийся препятствием.
    Верните количество возможных уникальных путей, по которым робот может добраться до правого нижнего угла.
    Тестовые примеры генерируются таким образом, чтобы ответ был меньше или равен 2 * 10^9.
    Ограничения:
        m == obstacleGrid.length
        n == obstacleGrid[i].length
        1 <= m, n <= 100
        obstacleGrid[i][j] является 0 или 1.
     */
    public class Task63 : InfoBasicTask
    {
        public Task63(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] obstacleGrid = new int[][] {
                new int[] { 0,0,0 },
                new int[] { 0,1,0 },
                new int[] { 0,0,0 }
            };
            printTwoDimensionalArray(obstacleGrid, "Двумерный массив с препятствиями (1 - препятствие)");
            if (isValid(obstacleGrid))
            {
                int res = uniquePathsWithObstacles(obstacleGrid);
                Console.WriteLine($"Количество уникальных путей = {res}");
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
        private bool isValid(int[][] obstacleGrid)
        {
            int lowLimit = 1;
            int highLimit = 100;
            int countRows = obstacleGrid.Length;
            if (countRows < lowLimit || countRows > highLimit)
            {
                return false;
            }
            int countColumns = obstacleGrid[0].Length;
            foreach (int[] arr in obstacleGrid)
            {
                if(arr.Length<lowLimit || arr.Length>highLimit || arr.Length != countColumns)
                {
                    return false;
                }
                foreach (int valueCell in arr)
                {
                    if (valueCell < 0 || valueCell > 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private int uniquePathsWithObstacles(int[][] obstacleGrid)
        {
            int countRows = obstacleGrid.Length;
            int countColumns = obstacleGrid[0].Length;
            if (countRows == 1 && countColumns == 1)
            {
                if (obstacleGrid[0][0] == 1)
                {
                    return 0;
                }
                return 1;
            }
            if (obstacleGrid[0][0] == 1)
            {
                return 0;
            }
            int[][] dp = new int[countRows][];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[countColumns];
            }
            dp[0][0] = 0;
            bool isFindObstacle = false;
            for (int indexRow = 1; indexRow < countRows; indexRow++)
            {
                if (!isFindObstacle)
                {
                    if (obstacleGrid[indexRow][0] == 1)
                    {
                        dp[indexRow][0] = 0;
                        isFindObstacle = true;
                    }
                    else
                    {
                        dp[indexRow][0] = 1;
                    }
                }
                else
                {
                    dp[indexRow][0] = 0;
                }
            }
            isFindObstacle = false;
            for (int indexColumn = 1; indexColumn < countColumns; indexColumn++)
            {
                if (!isFindObstacle)
                {
                    if (obstacleGrid[0][indexColumn] == 1)
                    {
                        dp[0][indexColumn] = 0;
                        isFindObstacle = true;
                    }
                    else
                    {
                        dp[0][indexColumn] = 1;
                    }
                }
                else
                {
                    dp[0][indexColumn] = 0;
                }
            }
            for (int indexRow = 1; indexRow < countRows; indexRow++)
            {
                for (int indexColumn = 1; indexColumn < countColumns; indexColumn++)
                {
                    if (obstacleGrid[indexRow][indexColumn] == 1)
                    {
                        dp[indexRow][indexColumn] = 0;
                    }
                    else
                    {
                        dp[indexRow][indexColumn] = dp[indexRow][indexColumn - 1] + dp[indexRow - 1][indexColumn];
                    }
                }
            }
            return dp[countRows - 1][countColumns - 1];
        }
    }
}
