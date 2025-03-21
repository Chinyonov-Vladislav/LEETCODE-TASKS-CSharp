using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task198
{
    /*
     198. Грабитель дома
    Вы — профессиональный грабитель, который планирует ограбить дома на улице. 
    В каждом доме спрятано определённое количество денег, и единственное, что мешает вам ограбить каждый из них, — это то, что в соседних домах подключены системы безопасности, и они автоматически свяжутся с полицией, если в одну и ту же ночь будут взломаны два соседних дома.
    Учитывая целочисленный массив nums с количеством денег в каждом доме, верните максимальную сумму денег, которую вы можете ограбить сегодня вечером не привлекая внимания полиции.
     */
    public class Task198 : InfoBasicTask
    {
        private enum ConcreteTypeSolution
        {
            Recursive = 1,
            Fast = 2
        }
        private enum TypeSolution
        {
            Nothing = 0,
            Recursive = 1,
            Fast = 2,
            Both = 3
        }
        public Task198(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 2, 7, 9, 3, 1 };
            printArray(nums);
            if (isValid(nums))
            {
                TypeSolution choiceUser = askUserTypeSolution();
                int res = 0;
                switch (choiceUser)
                {
                    case TypeSolution.Recursive:
                        res = rob(nums, ConcreteTypeSolution.Recursive);
                        Console.WriteLine($"Решение с помощью рекурсивного метода: максимальная сумма ограбления = {res}");
                        break;
                    case TypeSolution.Fast:
                        res = rob(nums, ConcreteTypeSolution.Fast);
                        Console.WriteLine($"Решение с помощью быстрого метода: максимальная сумма ограбления = {res}");
                        break;
                    case TypeSolution.Both:
                        res = rob(nums, ConcreteTypeSolution.Recursive);
                        Console.WriteLine($"Решение с помощью рекурсивного метода: максимальная сумма ограбления = {res}");
                        res = rob(nums, ConcreteTypeSolution.Fast);
                        Console.WriteLine($"Решение с помощью быстрого метода: максимальная сумма ограбления = {res}");
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
            int lowLimit = 1;
            int highLimit = 100;
            if (nums.Length < lowLimit || nums.Length > highLimit)
            {
                return false;
            }
            lowLimit = 0;
            highLimit = 400;
            foreach (int num in nums)
            {
                if (num < lowLimit || num > highLimit)
                {
                    return false;
                }
            }
            return true;
        }
        private int rob(int[] nums, ConcreteTypeSolution typeSolution)
        {
            switch (typeSolution)
            {
                case ConcreteTypeSolution.Recursive:
                    int max = 0;
                    for (int i = 0; i < nums.Length; i++)
                    {
                        int localMax = recursive(nums[i], nums[i], i, nums);
                        if (localMax > max)
                        {
                            max = localMax;
                        }
                    }
                    return max;
                case ConcreteTypeSolution.Fast:
                    return bestSolution(nums);
                default:
                    return 0;
            }
        }
        private int recursive(int max, int localMax, int currentIndex, int[] nums)
        {
            if (localMax > max)
            {
                max = localMax;
            }
            for (int index = currentIndex + 2; index < nums.Length; index++)
            {
                max = recursive(max, localMax + nums[index], index, nums);
            }
            return max;
        }

        private int bestSolution(int[] nums)
        {
            if (nums.Length == 1)
            {
                return nums[0];
            }
            int[] dp = new int[nums.Length+1];
            for (int i = 0; i <= nums.Length; i++)
            {
                if (i == 0)
                {
                    dp[i] = 0;
                }
                else if (i == 1)
                {
                    dp[i] = nums[i - 1];
                }
                else
                {
                    dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[i - 1]);
                }
            }
            return dp[nums.Length];
        }
        private TypeSolution askUserTypeSolution()
        {
            while (true)
            {
                Console.WriteLine("Выберите тип решения :\n" +
                    "1 - Рекурсивный\n" +
                    "2 - Быстрый\n" +
                     "3 - Протестировать оба метода\n" +
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
                            return TypeSolution.Nothing;
                        case 1:
                            return TypeSolution.Recursive;
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
