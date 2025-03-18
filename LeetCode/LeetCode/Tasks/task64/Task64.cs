using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task64
{
    /*
     64. Минимальная сумма пути
    Дана матрица m x n grid с неотрицательными числами. 
    Найдите путь из левого верхнего угла в правый нижний угол, который минимизирует сумму всех чисел на этом пути.
    Примечание: в любой момент времени вы можете двигаться только вниз или вправо.
    Ограничения:
        m == grid.length
        n == grid[i].length
        1 <= m, n <= 200
        0 <= grid[i][j] <= 200
    https://leetcode.com/problems/minimum-path-sum/description/
     */
    public class Task64 : InfoBasicTask
    {
        private enum TypeSolution
        {
            Recursive = 1,
            Optimal = 2
        }
        public Task64(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] grid = new int[][] {
                new int[] { 1,2, 3 },
                new int[] {4,5,6}
            };
            printTwoDimensionalArray(grid, "Исходная двумерная матрица");
            if (isValid(grid))
            {
                int choiceUser = askUserTypeSolution();
                if (choiceUser > 0)
                {
                    int res = minPathSum(grid, choiceUser == 1 ? TypeSolution.Recursive : TypeSolution.Optimal);
                    Console.WriteLine($"Стоимость минимального пути = {res}");
                }
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
            int countRows = grid.Length;
            int lowLimit = 1;
            int highLimit = 200;
            if (countRows < lowLimit || countRows > highLimit)
            {
                return true;
            }
            int lowLimitValueCell = 0;
            int highLimitValueCell = 200;
            int countColumns = grid[0].Length;
            foreach (int[] row in grid)
            {
                if (row.Length < lowLimit || row.Length > highLimit)
                {
                    return false;
                }
                foreach(int cellValue in row)
                {
                    if (cellValue < lowLimitValueCell || cellValue > highLimitValueCell)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private int askUserTypeSolution()
        {
            while (true)
            {
                Console.WriteLine("Выберите тип решения :\n" +
                    "1 - Рекурсивный\n" +
                    "2 - Оптимальный\n" +
                    "0 - Отменить выполнения задачи");
                Console.Write("Ваш выбор: ");
                try
                {
                    int choiceUser = Int32.Parse(Console.ReadLine());
                    if (choiceUser < 0 || choiceUser > 2)
                    {
                        throw new FormatException();
                    }
                    return choiceUser;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введено неверное значение. Повторите попытку!");
                }
            }
        }

        private int minPathSum(int[][] grid, TypeSolution type)
        {
            if (type == TypeSolution.Recursive)
            {
                int sum = 0;
                int currentX = 0;
                int currentY = 0;
                int countRows = grid.Length;
                int countColumns = grid[0].Length;
                return recursive(grid, currentX, currentY, countRows, countColumns, sum);
            }
            else
            {
                return optimalAlgorithm(grid);
            }
        }
        private int recursive(int[][] grid, int currentX, int currentY, int countRows, int countColumns, int sum)
        {
            sum += grid[currentX][currentY];
            if (currentX == countRows - 1 && currentY == countColumns - 1)
            {
                return sum;
            }
            int firstMin = int.MaxValue;
            if (currentX + 1<countRows)
            {
                firstMin = recursive(grid, currentX + 1, currentY, countRows, countColumns, sum);
            }
            int secondMin = int.MaxValue;
            if (currentY + 1 < countColumns)
            {
                secondMin = recursive(grid, currentX, currentY + 1, countRows, countColumns, sum);
            }
            return Math.Min(firstMin, secondMin);
        }
        private int optimalAlgorithm(int[][] grid)
        {
            int countRows = grid.Length;
            int countColumns = grid[0].Length;
            int[][] dp = new int[countRows][];
            for (int i = 0; i < countRows; i++)
            {
                dp[i] = new int[countColumns];
            }
            dp[0][0] = grid[0][0];
            for (int indexColumn = 1; indexColumn < countColumns; indexColumn++)
            {
                dp[0][indexColumn] = dp[0][indexColumn - 1] + grid[0][indexColumn];
            }
            for (int indexRow = 1; indexRow < countRows; indexRow++)
            {
                dp[indexRow][0] = dp[indexRow - 1][0] + grid[indexRow][0];
            }
            for (int indexRow = 1; indexRow < countRows; indexRow++)
            {
                for (int indexColumm = 1; indexColumm < countColumns; indexColumm++)
                {
                    dp[indexRow][indexColumm] = Math.Min(dp[indexRow - 1][indexColumm], dp[indexRow][indexColumm - 1]) + grid[indexRow][indexColumm];
                }
            }
            return dp[countRows - 1][countColumns - 1];
        }
    }
}
