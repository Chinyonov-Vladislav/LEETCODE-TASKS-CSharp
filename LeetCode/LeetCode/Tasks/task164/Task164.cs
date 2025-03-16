using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task164
{
    /*
     164. Максимальная разница
    Учитывая целочисленный массив nums, верните максимальную разницу между двумя последовательными элементами в отсортированном виде. Если массив содержит менее двух элементов, верните 0.
    Вы должны написать алгоритм, который работает за линейное время и использует линейное дополнительное пространство.
    Ограничения:
        1 <= nums.length <= 10^5
        0 <= nums[i] <= 10^9
    https://leetcode.com/problems/maximum-gap/description/
     */
    public class Task164 : InfoBasicTask
    {
        public Task164(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 3, 6, 9, 1 };
            printArray(nums);
            if (isValid(nums))
            {
                int max = maximumGap(nums);
                Console.WriteLine($"Максимальная разница между двумя соседними элементами в отсортированном массиве = {max}");
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
            int highLimit = (int)Math.Pow(10, 5);
            if (nums.Length < 1 || nums.Length > highLimit)
            {
                return false;
            }
            int lowLimit = 0;
            highLimit = (int)Math.Pow(10, 9);
            foreach (int num in nums) {
                if (num < lowLimit || num > highLimit)
                {
                    return false;
                }
            }
            return true;
        }
        private int maximumGap(int[] nums)
        {
            if (nums.Length < 2)
            {
                return 0;
            }
            Array.Sort(nums);
            int max = nums[1] - nums[0];
            for (int index = 2; index < nums.Length; index++)
            {
                int diff = nums[index] - nums[index - 1];
                if (diff > max)
                {
                    max = diff;
                }
            }
            return max;
        }
    }
}
