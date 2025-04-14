using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task396
{
    /*
     396. Функция поворота
    Вам предоставляется целочисленный массив nums длины n.
    Предположим, что arrk — это массив, полученный путём поворота nums на k позиций по часовой стрелке. Мы определяем функцию поворота F для nums следующим образом:
        F(k) = 0 * arrk[0] + 1 * arrk[1] + ... + (n - 1) * arrk[n - 1].
    Возвращает максимальное значение F(0), F(1), ..., F(n-1).
    Тестовые примеры генерируются таким образом, чтобы ответ помещался в 32-битное целое число.
    Ограничения:
        n == nums.length
        1 <= n <= 10^5
        -100 <= nums[i] <= 100
     */
    public class Task396 : InfoBasicTask
    {
        private enum TypeSolution
        {
            None,
            Slow,
            Fast,
            Both
        }
        public Task396(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array = new int[] { 4, 3, 2, 6 };
            printArray(array);
            if (isValid(array))
            {
                int res = 0;
                TypeSolution choiceUser = askUserTypeSolution();
                switch (choiceUser)
                {
                    case TypeSolution.Slow:
                        res = maxRotateFunctionFirstMethod(array);
                        Console.WriteLine($"Решение с помощью медленного алгоритма: максимальное значение = {res}");
                        break;
                    case TypeSolution.Fast:
                        res = maxRotateFunctionSecondMethod(array);
                        Console.WriteLine($"Решение с помощью медленного алгоритма: максимальное значение = {res}");
                        break;
                    case TypeSolution.Both:
                        res = maxRotateFunctionFirstMethod(array);
                        Console.WriteLine($"Решение с помощью медленного алгоритма: максимальное значение = {res}");
                        res = maxRotateFunctionSecondMethod(array);
                        Console.WriteLine($"Решение с помощью медленного алгоритма: максимальное значение = {res}");
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
        private bool isValid(int[] nums)
        {
            int lowLimitLengthNums = 1;
            int highLimitLengthNums = (int)Math.Pow(10, 5);
            int lowLimitValueNum = -100;
            int highLimitValueNum = 100;
            if (nums.Length < lowLimitLengthNums || nums.Length > highLimitLengthNums)
            {
                return false;
            }
            foreach (int num in nums)
            {
                if (num < lowLimitValueNum || num > highLimitValueNum)
                {
                    return false;
                }
            }
            return true;
        }
        private int maxRotateFunctionSecondMethod(int[] nums)
        {
            int max = 0;
            int totalSum = nums.Sum();
            int[] dp = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0)
                {
                    int val = 0;
                    for (int j = 0; j < nums.Length; j++)
                    {
                        val += nums[j] * j;
                    }
                    dp[i] = val;
                    max = val;
                }
                else
                {
                    dp[i] = dp[i - 1] + totalSum - nums.Length * nums[nums.Length - i];
                    if (dp[i] > max)
                    {
                        max = dp[i];
                    }
                }
            }
            return max;
        }

        private int maxRotateFunctionFirstMethod(int[] nums)
        {
            int countRows = nums.Length + 1;
            int countColumns = nums.Length + 1;
            int[][] dp = new int[countRows][];
            for (int i = 0; i < countRows; i++)
            {
                dp[i] = new int[countColumns];
            }
            for (int indexColumn = 1; indexColumn < countColumns; indexColumn++)
            {
                dp[0][indexColumn] = nums[indexColumn - 1];
            }
            int number = 0;
            for (int indexRow = 1; indexRow < countRows; indexRow++)
            {
                dp[indexRow][0] = number;
                number++;
            }
            int maxSum = 0;
            for (int startColumnIndex = 1; startColumnIndex < countColumns; startColumnIndex++)
            {
                int localSum = 0;
                int currentColumnIndex = startColumnIndex;
                for (int indexRow = 1; indexRow < countRows; indexRow++)
                {
                    if (currentColumnIndex >= countColumns)
                    {
                        currentColumnIndex = (currentColumnIndex % countColumns) + 1;
                    }
                    dp[indexRow][currentColumnIndex] = dp[indexRow][0] * dp[0][currentColumnIndex];
                    localSum += dp[indexRow][currentColumnIndex];
                    currentColumnIndex++;
                }
                if (startColumnIndex == 1)
                {
                    maxSum = localSum;
                }
                else
                {
                    if (localSum > maxSum)
                    {
                        maxSum = localSum;
                    }
                }
            }
            return maxSum;
        }
        private TypeSolution askUserTypeSolution()
        {
            while (true)
            {
                Console.WriteLine("Выберите тип решения :\n" +
                    "1 - Медленный (ассимптотическая сложность: O(n^2))\n" +
                    "2 - Быстрый (ассимптотическая сложность: O(n))\n" +
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
                        case 0:
                            return TypeSolution.None;
                        case 1:
                            return TypeSolution.Slow;
                        case 2:
                            return TypeSolution.Fast;
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
