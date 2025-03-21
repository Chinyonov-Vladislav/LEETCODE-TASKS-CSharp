using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task213
{
    /*
     213. Грабитель домов II
    Вы — профессиональный грабитель, который планирует ограбить дома на улице. 
    В каждом доме спрятано определённое количество денег. 
    Все дома на этой улице расположены по кругу. 
    Это значит, что первый дом является соседом последнего. 
    В то же время в соседних домах установлена система безопасности, и она автоматически свяжется с полицией, если в одну и ту же ночь будут взломаны два соседних дома.
    Учитывая целочисленный массив nums с количеством денег в каждом доме, верните максимальную сумму денег, которую вы можете ограбить сегодня вечером не привлекая внимания полиции.
    Ограничения:
        1 <= nums.length <= 100
        0 <= nums[i] <= 1000
    https://leetcode.com/problems/house-robber-ii/description/
     */
    public class Task213 : InfoBasicTask
    {
        private enum TypeSolution
        {
            Nothing = 0,
            FirstMethod = 1,
            SecondMethod = 2,
            Both = 3
        }
        public Task213(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 2, 3, 1 };
            printArray(nums);
            if (isValid(nums))
            {
                TypeSolution solution = askUserTypeSolution();
                int res = 0;
                switch (solution)
                {
                    case TypeSolution.FirstMethod:
                        res = rob(nums);
                        Console.WriteLine($"Решение с помощью метода c выделением дополнительной памяти под подмассив: максимальная сумма ограбления = {res}");
                        break;
                    case TypeSolution.SecondMethod:
                        res = robSecondMethod(nums);
                        Console.WriteLine($"Решение с помощью метода без выделения дополнительной памяти под подмассив: максимальная сумма ограбления = {res}");
                        break;
                    case TypeSolution.Both:
                        res = rob(nums);
                        Console.WriteLine($"Решение с помощью метода c выделением дополнительной памяти под подмассив: максимальная сумма ограбления = {res}");
                        res = robSecondMethod(nums);
                        Console.WriteLine($"Решение с помощью метода без выделения дополнительной памяти под подмассив: максимальная сумма ограбления = {res}");
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
            highLimit = 1000;
            foreach (int num in nums)
            {
                if (num < lowLimit || num > highLimit)
                {
                    return false;
                }
            }
            return true;
        }
        private int rob(int[] nums)
        {
            if (nums.Length == 1)
            {
                return nums[0];
            }
            int[] firstCopyArr = new int[nums.Length - 1];
            for (int i = 0; i < nums.Length-1; i++)
            {
                firstCopyArr[i] = nums[i];
            }
            int firstTryRob = solution(firstCopyArr);
            int[] secondCopyArr = new int[nums.Length - 1];
            for (int i = 1; i < nums.Length; i++)
            {
                secondCopyArr[i-1] = nums[i];
            }
            int secondTryRob = solution(secondCopyArr);
            return Math.Max(firstTryRob, secondTryRob);
        }

        private int solution(int[] nums)
        {
            int[] dp = new int[nums.Length + 1];
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

        private int robSecondMethod(int[] nums)
        {
            if (nums.Length == 1)
            {
                return nums[0];
            }
            int[] dp = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
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
            int firstTryRob = dp[nums.Length - 1];
            dp = new int[nums.Length];
            for (int i = 1; i <= nums.Length; i++)
            {
                if (i == 1)
                {
                    dp[i - 1] = 0;
                }
                else if (i == 2)
                {
                    dp[i - 1] = nums[i - 1];
                }
                else
                {
                    dp[i - 1] = Math.Max(dp[i - 2], dp[i - 3] + nums[i - 1]);
                }
            }
            int secondTryRob = dp[nums.Length - 1];
            return Math.Max(firstTryRob, secondTryRob);
        }
        private TypeSolution askUserTypeSolution()
        {
            while (true)
            {
                Console.WriteLine("Выберите тип решения :\n" +
                    "1 - С выделением дополнительной памяти под подмассив\n" +
                    "2 - Без выделением дополнительной памяти под подмассив\n" +
                    "3 - Протестировать оба решения\n" +
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
                            return TypeSolution.FirstMethod;
                        case 2:
                            return TypeSolution.SecondMethod;
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
