using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3423
{
    /*
     3423. Максимальная разница между соседними элементами в циклическом массиве
    Для кругового массива nums найдите максимальную абсолютную разницу между соседними элементами.
    Примечание: в циклическом массиве первый и последний элементы являются смежными.
    Ограничения:
        2 <= nums.length <= 100
        -100 <= nums[i] <= 100
    https://leetcode.com/problems/maximum-difference-between-adjacent-elements-in-a-circular-array/description/
     */
    public class Task3423 : InfoBasicTask
    {
        public Task3423(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { -5, -10, -5 };
            printArray(nums);
            if(isValid(nums))
            {
                int max = maxAdjacentDistance(nums);
                Console.WriteLine($"Максимальная абсолютная разница между соседними элементами = {max}");
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
            if (nums.Length < 2 || nums.Length > 100)
            {
                return false;
            }
            foreach (int num in nums) {
                if (num < -100 || num > 100)
                {
                    return false;
                }
            }
            return true;
        }
        private int maxAdjacentDistance(int[] nums)
        {
            int max = Math.Abs(nums[nums.Length - 1] - nums[0]);
            for (int i = 1; i < nums.Length; i++)
            {
                int localMax = 0;
                if (i == nums.Length - 1)
                {
                    localMax = Math.Abs(nums[i-1] - nums[i]);
                }
                else
                {
                    localMax = Math.Abs(nums[i-1] - nums[i]);
                }
                if (localMax > max)
                {
                    max = localMax;
                }
            }
            return max;
        }
    }
}
