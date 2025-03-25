using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task53
{
    /*
     53. Максимальный подмассив
    Дан целочисленный массив nums, найдите подмассив с наибольшей суммой и верните его сумму.
    Ограничения:
        1 <= nums.length <= 10^5
        -10^4 <= nums[i] <= 10^4
    https://leetcode.com/problems/maximum-subarray/description/
     */
    public class Task53 : InfoBasicTask
    {
        public Task53(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            printArray(nums);
            if (isValid(nums))
            {
                int res = maxSubArray(nums);
                Console.WriteLine($"Максимальная суммма подмассива = {res}");
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
            int highLimit = (int)Math.Pow(10,5);
            if (nums.Length < lowLimit || nums.Length > highLimit)
            {
                return false;
            }
            lowLimit = -1* (int)Math.Pow(10, 4);
            highLimit = (int)Math.Pow(10, 4);
            foreach (int num in nums)
            {
                if (num < lowLimit || num > highLimit)
                {
                    return false;
                }
            }
            return true;
        }
        private int maxSubArray(int[] nums)
        {
            int res = nums[0];
            int maxEnding = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                maxEnding = Math.Max(maxEnding + nums[i], nums[i]);
                res = Math.Max(res, maxEnding);
            }
            return res;
        }
    }
}
