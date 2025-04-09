using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task209
{
    /*
     209. Сумма подмассива минимального размера
    Учитывая массив натуральных чисел nums и положительное целое число target, верните минимальную длину подмассива, сумма которых больше или равна target. 
    Если такого подмассива нет, верните 0 вместо этого.
    Ограничения:
        1 <= target <= 10^9
        1 <= nums.length <= 10^5
        1 <= nums[i] <= 10^4
    https://leetcode.com/problems/minimum-size-subarray-sum/description/
     */
    public class Task209 : InfoBasicTask
    {
        public Task209(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int target = 7;
            Console.WriteLine($"Целевое число = {target}");
            int[] nums = new int[] { 2, 3, 1, 2, 4, 3 };
            printArray(nums);
            if (isValid(target, nums))
            {
               int res = minSubArrayLen(target, nums);
                Console.WriteLine(res == 0 ? $"Отсутствует подмассив, сумма элементов которого больше или равна {target}" : $"Минимальная длина подмассив, сумма элементов которого больше или равна {target} = {res}");
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
        private bool isValid(int target, int[] nums)
        {
            int lowLimitTarget = 1;
            int highLimitTarget = (int)Math.Pow(10,9);
            if (target < lowLimitTarget || target > highLimitTarget)
            {
                return false;
            }
            int lowLimitNumsLength = 1;
            int highLimitNumsLength = (int)Math.Pow(10, 5);
            if (nums.Length < lowLimitNumsLength || nums.Length > highLimitNumsLength)
            {
                return false;
            }
            int lowLimitValueNum = 1;
            int highLimitValueNum = (int)Math.Pow(10, 4);
            foreach (int num in nums)
            {
                if (num < lowLimitValueNum || num > highLimitValueNum)
                {
                    return false;
                }
            }
            return true;
        }
        private int minSubArrayLen(int target, int[] nums)
        {
            int currentSum = nums[0];
            int left = 0;
            int right = 0;
            int minSize = 0;
            while (right< nums.Length)
            {
                if (currentSum >= target)
                {
                    int localSize = right - left + 1;
                    if (minSize == 0)
                    {
                        minSize = localSize;
                    }
                    else
                    {
                        if (minSize > localSize)
                        {
                            minSize = localSize;
                        }
                    }
                    currentSum -= nums[left];
                    left++;
                }
                else
                {
                    right++;
                    if (right < nums.Length)
                    {
                        currentSum += nums[right];
                    }
                }
            }
            return minSize;
        }
    }
}
