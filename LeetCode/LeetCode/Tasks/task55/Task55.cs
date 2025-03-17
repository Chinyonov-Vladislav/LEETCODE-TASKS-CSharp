using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task55
{
    /*
     55. Игра в прыжки
    Вам дан целочисленный массив nums. Изначально вы находитесь в массиве по первому индексу, и каждый элемент массива представляет собой максимальную длину вашего прыжка в этой позиции.
    Вернитесь, true если сможете добраться до последнего индекса, или false в противном случае.
    Ограничения:
        1 <= nums.length <= 10^4
        0 <= nums[i] <= 10^5
    https://leetcode.com/problems/jump-game/description/
     */
    public class Task55 : InfoBasicTask
    {
        private enum TypeSolution
        {
            Recursive = 1,
            Greedy = 2
        }
        public Task55(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 2, 3, 1, 1, 4 };
            printArray(nums);
            if (isValid(nums))
            {
                int choiceUserTypeSolution = askUserTypeSolution();
                if (choiceUserTypeSolution > 0)
                {
                    bool result = canJump(nums, choiceUserTypeSolution == 1 ? TypeSolution.Recursive : TypeSolution.Greedy);
                    Console.WriteLine(result ? "Возможо добраться до последнего индекса" : "Невозможо добраться до последнего индекса");
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
            int highLimit = (int)Math.Pow(10, 4);
            if (nums.Length < lowLimit || nums.Length > highLimit)
            {
                return false;
            }
            lowLimit = 0;
            highLimit = (int)Math.Pow(10, 5);
            foreach (int num in nums)
            {
                if (num < lowLimit || num > highLimit)
                {
                    return false;
                }
            }
            return true;
        }
        private bool canJump(int[] nums, TypeSolution type)
        {
            if (type == TypeSolution.Recursive)
            {
                int currentIndex = 0;
                int lastIndex = nums.Length - 1;
                return recursive(nums, currentIndex, lastIndex);
            }
            return greedy(nums);
        }
        private bool greedy(int[] nums)
        {
            int maxReach = 0;
            for (int i = 0; i < nums.Length; i++) {
                if (i > maxReach)
                {
                    return false;
                }
                maxReach = Math.Max(maxReach, nums[i]+i);
            }
            if (maxReach >= nums.Length - 1)
            {
                return true;
            }
            return false;
        }
        private bool recursive(int[] nums, int currentIndex, int lastIndex)
        {
            if (currentIndex == lastIndex)
            {
                return true;
            }
            if (nums[currentIndex] == 0)
            {
                return false;
            }
            for (int i = 1; i <= nums[currentIndex]; i++)
            {
                int nextIndex = currentIndex + i;
                if (nextIndex < nums.Length)
                {
                    if (recursive(nums, nextIndex, lastIndex))
                    {
                        return true;
                    }
                }
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
    }
}
