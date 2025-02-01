using LeetCode.Basic;
using System;

namespace LeetCode.Tasks.task628
{
    /*
     628. Максимальное произведение трех чисел
    Дан целочисленный массив nums. Найдите три числа, произведение которых максимально, и верните максимальное произведение.
     */
    public class Task628 : InfoBasicTask
    {
        public Task628(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 2, 3, 4 };
            printArray(nums, "Исходный массив: ");
            Console.WriteLine($"Максимальное произведение из трех чисел массива = {maximumProduct(nums)}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int maximumProduct(int[] nums)
        {
            int countNegativeNumber = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < 0)
                {
                    countNegativeNumber++;
                }
            }
            int result = 1;
            Array.Sort(nums); // nums от меньшего к большему
            if (countNegativeNumber <= 1) // если отрицательных элементов нет или не больше одного, остальные - положительные
            {
                int index = nums.Length - 1;
                for (int i = 0; i <= 2; i++)
                {
                    result *= nums[index];
                    index--;
                }
            }
            else
            {
                int firstProduction = nums[0] * nums[1] * nums[nums.Length - 1];
                int secondProduction = nums[nums.Length - 3] * nums[nums.Length - 2] * nums[nums.Length - 1];
                result = firstProduction > secondProduction ? firstProduction : secondProduction;
            }
            return result;
        }
        private int bestSolution(int[] nums)
        {
            int max1 = int.MinValue, max2 = int.MinValue, max3 = int.MinValue, min1 = 0, min2 = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                var num = nums[i];

                if (num < min1)
                {
                    min2 = min1;
                    min1 = num;
                }
                else if (num < min2)
                {
                    min2 = num;
                }

                if (num > max1)
                {
                    max3 = max2;
                    max2 = max1;
                    max1 = num;
                }
                else if (num > max2)
                {
                    max3 = max2;
                    max2 = num;
                }
                else if (num > max3)
                {
                    max3 = num;
                }
            }
            return Math.Max(min1 * min2 * max1, max1 * max2 * max3);
        }
    }
}
