using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task62
{
    /*
     62. Уникальные пути
    На сетке m x n находится робот. Изначально робот находится в верхнем левом углу (то есть в grid[0][0]). Робот пытается переместиться в нижний правый угол (то есть в grid[m - 1][n - 1]). В любой момент времени робот может перемещаться только вниз или вправо.
    Учитывая два целых числа m и n, верните количество возможных уникальных путей, по которым робот может добраться до правого нижнего угла.
    Тестовые примеры генерируются таким образом, чтобы ответ был меньше или равен 2 * 109.
    https://leetcode.com/problems/unique-paths/description/
     */
    public class Task62 : InfoBasicTask
    {
        private enum TypeSolution
        {
            None = 0,
            Recursive = 1,
            DynamicProgramming = 2,
            Both = 3
        }
        public Task62(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int m = 3;
            int n = 7;
            if (isValid(m, n))
            {
                int countUniquePaths = 0;
                TypeSolution typeSolution = askUserTypeSolution();
                switch (typeSolution)
                {
                    case TypeSolution.Recursive:
                        countUniquePaths = uniquePaths(m, n);
                        Console.WriteLine($"Результат, полученный с помощью рекурсивного метода: количество уникальных путей = {countUniquePaths}");
                        break;
                    case TypeSolution.DynamicProgramming:
                        countUniquePaths = optimalAlgorithm(m, n);
                        Console.WriteLine($"Результат, полученный с помощью метода динамического программирования: количество уникальных путей = {countUniquePaths}");
                        break;
                    case TypeSolution.Both:
                        countUniquePaths = uniquePaths(m, n);
                        Console.WriteLine($"Результат, полученный с помощью рекурсивного метода: количество уникальных путей = {countUniquePaths}");
                        countUniquePaths = optimalAlgorithm(m, n);
                        Console.WriteLine($"Результат, полученный с помощью метода динамического программирования: количество уникальных путей = {countUniquePaths}");
                        break;
                        
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
        private bool isValid(int m, int n)
        {
            int lowLimit = 1;
            int highLimit = 100;
            if (m < lowLimit || m > highLimit || n < lowLimit || n > highLimit)
            {
                return false;
            }
            return true;
        }
        private int uniquePaths(int m, int n)
        {
            int indexX = 0;
            int indexY = 0;
            return move(indexX, indexY, m, n);
        }
        private int move(int currentX, int currentY, int m, int n, int totalUniquePaths = 0)
        {
            if (m - 1 == currentX && n - 1 == currentY)
            {
                return totalUniquePaths += 1;
            }
            if (currentX >= m || currentY >= n)
            {
                return totalUniquePaths;
            }
            totalUniquePaths = move(currentX+1, currentY, m, n, totalUniquePaths) + move(currentX, currentY+1, m, n, totalUniquePaths);
            return totalUniquePaths;
        }

        private int optimalAlgorithm(int m, int n)
        {
            if (m == 1 && n == 1)
            {
                return 1;
            }
            int[][] dp = new int[m][];
            for(int i=0;i<dp.Length;i++)
            {
                dp[i] = new int[n];
            }
            dp[0][0] = 0;
            for (int indexRow = 1; indexRow < m; indexRow++)
            {
                dp[indexRow][0] = 1;
            }
            for (int indexColumn = 1; indexColumn < n; indexColumn++)
            {
                dp[0][indexColumn] = 1;
            }
            for (int indexRow = 1; indexRow < m; indexRow++)
            {
                for (int indexColumn = 1; indexColumn < n; indexColumn++)
                {
                    dp[indexRow][indexColumn] = dp[indexRow][indexColumn - 1] + dp[indexRow - 1][indexColumn];
                }
            }
            return dp[m - 1][n - 1];
        }
        private TypeSolution askUserTypeSolution()
        {
            while (true)
            {
                Console.WriteLine("Выберите тип решения :\n" +
                    "1 - Рекурсивный\n" +
                    "2 - Динамическое программирование\n" +
                    "3 - Протестировать оба метода\n"+
                    "0 - Отменить выполнения задачи");
                Console.Write("Ваш выбор: ");
                try
                {
                    int choiceUser = Int32.Parse(Console.ReadLine());
                    if (choiceUser < 0 || choiceUser > 3)
                    {
                        throw new FormatException();
                    }
                    switch (choiceUser)
                    {
                        case 0:
                            return TypeSolution.None;
                        case 1:
                            return TypeSolution.Recursive;
                        case 2:
                            return TypeSolution.DynamicProgramming;
                        case 3:
                            return TypeSolution.Both;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введено неверное значение. Повторите попытку!");
                }
            }
        }
    }
}
