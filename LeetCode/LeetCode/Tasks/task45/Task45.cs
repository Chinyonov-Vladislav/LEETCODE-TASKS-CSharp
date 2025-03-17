using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task45
{
    /*
     45. Игра в прыжки II
    Вам дан массив целых чисел с индексацией 0nums длиной n. Изначально вы находитесь в позиции nums[0].
    Каждый элемент nums[i] представляет собой максимальную длину прыжка вперёд из индекса i. 
    Другими словами, если вы находитесь в nums[i], вы можете прыгнуть в любое nums[i + j] где:
        0 <= j <= nums[i] и
        i + j < n
    Верните минимальное количество прыжков, чтобы добраться до nums[n - 1]. 
    Тестовые примеры генерируются таким образом, чтобы вы могли добраться до nums[n - 1].
    Ограничения:
        1 <= nums.length <= 10^4
        0 <= nums[i] <= 1000
        Гарантируется, что вы сможете добраться nums[n - 1].
    https://leetcode.com/problems/jump-game-ii/description/
     */
    public class Task45 : InfoBasicTask
    {
        private enum TypeSolution
        {
            Recursive = 1,
            Greedy = 2,
            Both = 3
        }

        public Task45(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 2, 3, 1, 1, 4 };
            printArray(nums);
            if (isValid(nums))
            {
                int choiceUser = askUserTypeSolution();
                switch (choiceUser)
                {
                    case 1:
                        int res1 = jump(nums, TypeSolution.Recursive);
                        Console.WriteLine($"Результат, полученный при помощи рекурсивного алгоритма = {res1}");
                        break;
                    case 2:
                        int res2 = jump(nums, TypeSolution.Greedy);
                        Console.WriteLine($"Результат, полученный при помощи жадного алгоритма = {res2}");
                        break;
                    case 3:
                        int res3 = jump(nums, TypeSolution.Recursive);
                        int res4 = jump(nums, TypeSolution.Greedy);
                        Console.WriteLine($"Результат, полученный при помощи рекурсивного алгоритма = {res3}");
                        Console.WriteLine(res4 == -1 ? "Исходные данные слишком большого размера для использования рекурсивного алгоритма" : $"Результат, полученный при помощи жадного алгоритма = {res4}");
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
            bool canJump = canJumpToEnd(nums);
            if (!canJump)
            {
                return false;
            }
            int lowLimit = 1;
            int highLimit = (int)Math.Pow(10, 4);
            if (nums.Length < lowLimit || nums.Length > highLimit)
            {
                return false;
            }
            lowLimit = 0;
            highLimit = (int)Math.Pow(10, 3);
            foreach (int num in nums)
            {
                if (num < lowLimit || num > highLimit)
                {
                    return false;
                }
            }
            return true;
        }
        private int jump(int[] nums, TypeSolution type)
        {
            if (type == TypeSolution.Recursive)
            {
                int currentIndex = 0;
                int countJump = 0;
                int min = Int32.MaxValue;
                return recursive(nums, currentIndex, countJump, min);
            }
            else
            {
                return greedy(nums);
            }
        }
        private int recursive(int[] nums, int currentIndex, int countJump, int min)
        {
            if (currentIndex == nums.Length - 1)
            {
                return countJump < min ? countJump : min;
            }
            for (int i = nums[currentIndex]; i >= 1; i--)
            {
                int nextIndex = currentIndex + i;
                if (nextIndex < nums.Length)
                {
                    min = recursive(nums, nextIndex, countJump + 1, min);
                }
            }
            return min;
        }
        private int greedy(int[] nums)
        {
            int currentIndex = 0;
            int countJump = 0;
            int farthest = 0;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                farthest = Math.Max(farthest, i + nums[i]);
                if (i >= currentIndex)
                {
                    countJump++;
                    currentIndex = farthest;
                }
            }
            return countJump;
        }
        private bool canJumpToEnd(int[] nums)
        {
            int maxReach = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i > maxReach)
                {
                    return false;
                }
                maxReach = Math.Max(maxReach, nums[i] + i);
            }
            if (maxReach >= nums.Length - 1)
            {
                return true;
            }
            return false;
        }
        private int askUserTypeSolution()
        {
            while (true)
            {
                Console.WriteLine("Выберите тип решения :\n" +
                    "1 - Рекурсивный\n" +
                    "2 - Жадный\n" +
                    "3 - Протестировать оба алгоритма\n" +
                    "0 - Отменить выполнения задачи");
                Console.Write("Ваш выбор: ");
                try
                {
                    int choiceUser = Int32.Parse(Console.ReadLine());
                    if (choiceUser < 0 || choiceUser > 3)
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
    }
}
