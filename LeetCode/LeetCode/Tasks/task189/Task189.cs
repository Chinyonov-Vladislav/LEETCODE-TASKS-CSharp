using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task189
{
    /*
     189. Повернуть массив
    Дан целочисленный массив nums, поверните его вправо на k шагов, где k — неотрицательное число.
    Ограничения:
        1 <= nums.length <= 10^5
        -2^31 <= nums[i] <= 2^31 - 1
        0 <= k <= 10^5
    https://leetcode.com/problems/rotate-array/description/
     */
    public class Task189 : InfoBasicTask
    {
        private enum TypeSolution
        {
            None,
            Slow,
            Fast,
            Both
        }
        public Task189(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            printArray(nums);
            int k = 3;
            Console.WriteLine($"Значение шагов для поворота вправо = {k}");
            if (isValid(nums, k))
            {
                TypeSolution typeSolution = askUserTypeSolution();
                switch (typeSolution)
                {
                    case TypeSolution.Slow:
                        rotate(nums,k);
                        printArray(nums, "Решение, полученное с помощью медленного алгоритма: ");
                        break;
                    case TypeSolution.Fast:
                        optimalAlgorithm(nums,k);
                        printArray(nums, "Решение, полученное с помощью быстрого алгоритма: ");
                        break;
                    case TypeSolution.Both:
                        int[] copyNum = new int[nums.Length];
                        for (int i = 0; i < nums.Length; i++)
                        {
                            copyNum[i] = nums[i];
                        }
                        rotate(nums, k);
                        printArray(nums, "Решение, полученное с помощью медленного алгоритма: ");
                        optimalAlgorithm(copyNum, k);
                        printArray(copyNum, "Решение, полученное с помощью быстрого алгоритма: ");
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
        private void rotate(int[] nums, int k)
        {
            k = k % nums.Length;
            for (int step = 0; step < k; step++)
            {
                int temp = nums[nums.Length-1];
                for (int index = nums.Length - 2; index >= 0; index--)
                {
                    nums[index + 1] = nums[index];
                }
                nums[0] = temp;
            }
        }
        private bool isValid(int[] nums, int k)
        {
            int lowLimit = 1;
            int highLimit = (int)Math.Pow(10, 5);
            if (nums.Length < lowLimit || nums.Length > highLimit)
            {
                return false;
            }
            lowLimit = 0;
            if (k < lowLimit || k > highLimit)
            {
                return false;
            }
            return true;
        }
        private void optimalAlgorithm(int[] nums, int k)
        {
            k = k%nums.Length;
            reverse(nums, 0, nums.Length - 1);
            reverse(nums, 0, k - 1);
            reverse(nums, k, nums.Length - 1);
        }
        private void reverse(int[] nums, int left, int right)
        {
            while (left <= right)
            {
                (nums[left], nums[right]) = (nums[right], nums[left]);
                left++;
                right--;
            }
        }
        private TypeSolution askUserTypeSolution()
        {
            while (true)
            {
                Console.WriteLine("Выберите тип решения :\n" +
                    "1 - Медленный (пошаговый сдвиг элементов массива)\n" +
                    "2 - Быстрый (трюк с переворотом массива: переворот массива, переворот первых k элементов, переворот оставшейся части)\n" +
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
