using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task221
{
    /*
     221. Максимальная площадь
    Учитывая m x n двоичную matrix матрицу, заполненную 0 и 1's, найдите наибольший квадрат, содержащий только 1's, и верните его площадь.
    Ограничения:
        m == matrix.length
        n == matrix[i].length
        1 <= m, n <= 300
        matrix[i][j] является '0' или '1'.
    https://leetcode.com/problems/maximal-square/description/
     */
    public class Task221 : InfoBasicTask
    {
        private enum TypeSolution
        {
            Nothing = 0,
            Slow = 1,
            Fast = 2,
            Both = 3
        }
        public Task221(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            char[][] matrix = new char[][] {
                new char[] { '1', '0', '1', '0', '0' },
                new char[] { '1', '0', '1', '1', '1' },
                new char[] { '1', '1', '1', '1', '1' },
                new char[] { '1', '0', '0', '1', '0' }
            };
            Console.WriteLine("Исходная двумерная матрица");
            printTwoDimensionalArray(matrix);
            if (isValid(matrix))
            {
                TypeSolution choiceUserTypeSolution = askUserTypeSolution();
                if (choiceUserTypeSolution != TypeSolution.Nothing)
                {
                    switch (choiceUserTypeSolution)
                    {
                        case TypeSolution.Slow:
                            int resSlow =  maximalSquare(matrix);
                            Console.WriteLine($"Решение с помощью медленного метода: наибольшая площадь квадрата в матрице со всеми 1 = {resSlow}");
                            break;
                        case TypeSolution.Fast:
                            int resFast = optimalAlgorithm(matrix);
                            Console.WriteLine($"Решение с помощью быстрого метода: наибольшая площадь квадрата в матрице со всеми 1 = {resFast}");
                            break;
                        case TypeSolution.Both:
                            Stopwatch stopwatch = new Stopwatch();
                            stopwatch.Start();
                            int resSlowBoth = maximalSquare(matrix);
                            stopwatch.Stop();
                            long elapsedMillisecondsFirstMethod = stopwatch.ElapsedMilliseconds;
                            stopwatch.Start();
                            int resFastBoth = optimalAlgorithm(matrix);
                            stopwatch.Stop();
                            long elapsedMillisecondsSecondMethod = stopwatch.ElapsedMilliseconds;
                            Console.WriteLine($"Решение с помощью медленного метода: наибольшая площадь квадрата в матрице со всеми 1 = {resSlowBoth}. Время выполнения = {elapsedMillisecondsFirstMethod} мс.");
                            Console.WriteLine($"Решение с помощью быстрого метода: наибольшая площадь квадрата в матрице со всеми 1 = {resFastBoth}. Время выполнения = {elapsedMillisecondsSecondMethod} мс.");
                            break;
                    }
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
        private bool isValid(char[][] matrix)
        {
            int lowLimitSizeMatrix = 1;
            int highLimitSizeMatrix = 300;
            List<char> acceptedValues = new List<char>() { '0', '1' };
            int countRows = matrix.Length;
            if (countRows < lowLimitSizeMatrix || countRows > highLimitSizeMatrix)
            {
                return false;
            }
            int countColumns = matrix[0].Length;
            foreach (char[] arr in matrix)
            {
                if (arr.Length < lowLimitSizeMatrix || arr.Length > highLimitSizeMatrix || arr.Length != countColumns)
                {
                    return false;
                }
                foreach (char c in arr)
                {
                    if (!acceptedValues.Contains(c))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private int maximalSquare(char[][] matrix)
        {
            int maxSquare = 0;
            int countRows = matrix.Length;
            int countColumns = matrix[0].Length;
            int maxSize = Math.Min(countRows, countColumns);
            int currentSize = 1;
            while (currentSize <= maxSize)
            {
                bool isFind = false;
                for (int i = 0; i < countRows - currentSize + 1; i++)
                {
                    for (int j = 0; j < countColumns - currentSize + 1; j++)
                    {
                        HashSet<char> tmp = new HashSet<char>();
                        for (int indexRow = i; indexRow < i + currentSize; indexRow++)
                        {
                            for (int indexColumn = j; indexColumn < j + currentSize; indexColumn++)
                            {
                                tmp.Add(matrix[indexRow][indexColumn]);
                            }
                        }
                        if (tmp.Count == 1)
                        {
                            if (tmp.Contains('1'))
                            {
                                isFind = true;
                            }
                        }
                        if (isFind)
                        {
                            break;
                        }
                    }
                    if (isFind)
                    {
                        break;
                    }
                }
                if (isFind)
                {
                    maxSquare = currentSize * currentSize;
                }
                currentSize++;
            }
            return maxSquare;
        }
        private int optimalAlgorithm(char[][] matrix)
        {
            int maxSide = 0;
            int countRows = matrix.Length;
            int countColumns = matrix[0].Length;
            int[][] dp = new int[countRows + 1][];
            for (int i = 0; i < countRows + 1; i++)
            {
                dp[i] = new int[countColumns + 1];
            }
            for (int i = 1; i <= countRows; i++)
            {
                for (int j = 1; j <= countColumns; j++)
                {
                    if (matrix[i - 1][j - 1] == '1')
                    {
                        dp[i][j] = Math.Min(dp[i - 1][j], Math.Min(dp[i][j - 1], dp[i - 1][j - 1])) + 1;
                        maxSide = Math.Max(maxSide, dp[i][j]);
                    }
                }
            }
            return maxSide * maxSide;
        }
        private TypeSolution askUserTypeSolution()
        {
            while (true)
            {
                Console.WriteLine("Выберите тип решения :\n" +
                    "1 - Медленный\n" +
                    "2 - Быстрый\n" +
                     "3 - Протестировать оба варианта\n" +
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
                        case 1:
                            return TypeSolution.Slow;
                        case 2:
                            return TypeSolution.Fast;
                        case 3:
                            return TypeSolution.Both;
                        default:
                            return TypeSolution.Nothing;
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
