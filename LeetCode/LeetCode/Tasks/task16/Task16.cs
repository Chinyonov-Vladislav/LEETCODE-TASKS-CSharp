using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace LeetCode.Tasks.task16
{
    /*
     16. 3Sum Ближайший
    Дан целочисленный массив nums длины n и целое число target. Найдите три целых числа в nums так, чтобы их сумма была максимально близка к target.
    Возвращает сумму трех целых чисел.
    Вы можете предположить, что каждый входной сигнал будет иметь только одно решение.
    Ограничения:
        3 <= nums.length <= 500
        -1000 <= nums[i] <= 1000
        -10^4 <= target <= 10^4
    https://leetcode.com/problems/3sum-closest/description/
     */
    public class Task16 : InfoBasicTask
    {
        public Task16(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { -1, 2, 1, -4 };
            printArray(nums);
            int target = 1;
            Console.WriteLine($"Целевая сумма = {target}");
            if (isValid(nums, target))
            {
                int res = threeSumClosest(nums, target);
                Console.WriteLine($"Сумма, наиболее близкая к цели ({target}) = {res}");
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
        private bool isValid(int[] nums, int target)
        {
            int lowLimit = 3;
            int highLimit = 500;
            if (nums.Length < lowLimit || nums.Length > highLimit)
            {
                return false;
            }
            lowLimit = -1000;
            highLimit = 1000;
            foreach (int num in nums)
            {
                if (num < lowLimit || num > highLimit)
                {
                    return false;
                }
            }
            lowLimit= - 1 * (int)Math.Pow(10, 4);
            highLimit = (int)Math.Pow(10, 4);
            if (target < lowLimit || target > highLimit)
            {
                return false;
            }
            return true;
        }
        private int threeSumClosest(int[] nums, int target)
        {
            int minDistance = int.MaxValue;
            int sum = 0;
            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 2; i++)
            {
                int left = i + 1;
                int right = nums.Length - 1;
                while (left < right)
                {
                    int currentSum = nums[i] + nums[left] + nums[right];
                    int currentDistance = Math.Abs(currentSum - target);
                    if (currentDistance < minDistance)
                    {
                        minDistance = currentDistance;
                        sum = currentSum;
                    }
                    if (currentSum == target)
                    {
                        return currentSum;
                    }
                    else if (currentSum < target)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }
            return sum;
        }
    }
}
