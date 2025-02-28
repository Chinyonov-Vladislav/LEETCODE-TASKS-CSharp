using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2574
{
    /*
     2574. Разница в сумме слева и справа
    Вам дан нумерованный от 0 целочисленный массив nums размером n.
    Определите два массива leftSum и rightSum , где:
        leftSum[i] это сумма элементов слева от индекса i в массиве nums. Если такого элемента нет, leftSum[i] = 0.
        rightSum[i] это сумма элементов справа от индекса i в массиве nums. Если такого элемента нет, rightSum[i] = 0.
    Возвращает целочисленный массив answer размера n, где answer[i] = |leftSum[i] - rightSum[i]|.
    Ограничения:
        1 <= nums.length <= 1000
        1 <= nums[i] <= 10^5
    https://leetcode.com/problems/left-and-right-sum-differences/description/
     */
    public class Task2574 : InfoBasicTask
    {
        public Task2574(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 10, 4, 8, 3 };
            printArray(nums);
            if (isValid(nums))
            {
                int[] result = leftRightDifference(nums);
                printArray(result, "Результирующий массив: ");
            }
            else
            {
                Console.WriteLine("Исходные данные не валидны!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(int[] nums)
        {
            if (nums.Length < 1 || nums.Length > 1000)
            {
                return false;
            }
            int upperLimit = (int)Math.Pow(10, 5);
            foreach (var num in nums)
            {
                if (num < 1 || num > upperLimit)
                {
                    return false;
                }
            }
            return true;
        }
        private int[] leftRightDifference(int[] nums)
        {
            int[] leftSum = new int[nums.Length];
            int totalSum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                leftSum[i] = totalSum;
                totalSum += nums[i];
            }
            int[] rightSum = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                totalSum-= nums[i];
                rightSum[i] = totalSum;
            }
            int[] result = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                result[i] = Math.Abs(leftSum[i] - rightSum[i]);
            }
            return result;
        }
    }
}
