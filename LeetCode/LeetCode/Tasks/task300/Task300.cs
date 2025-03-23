using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task300
{
    /*
     300. Самая длинная возрастающая подпоследовательность
    Учитывая целочисленный массив nums, верните длину самой длинной строго возрастающей подпоследовательности.
    Ограничения:
        1 <= nums.length <= 2500
        -10^4 <= nums[i] <= 10^4
    https://leetcode.com/problems/longest-increasing-subsequence/description/
     */
    public class Task300 : InfoBasicTask
    {
        public Task300(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 0, 1, 0, 3, 2, 3 };
            printArray(nums);
            if (isValid(nums))
            {
                int res = lengthOfLIS(nums);
                Console.WriteLine($"Длина наибольшей строго возрастающей подпоследовательности = {res}");
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
            int highLimit = 2500;
            if (nums.Length < lowLimit || nums.Length > highLimit)
            {
                return false;
            }
            lowLimit = -1 * (int)Math.Pow(10, 4);
            highLimit = (int)Math.Pow(10, 4);
            foreach (int num in nums)
            {
                if(num<lowLimit || num>highLimit)
                {
                    return false;
                }
            }
            return true;
        }
        private int lengthOfLIS(int[] nums)
        {
            int[] dp = new int[nums.Length];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = 1;
            }
            for (int i = 1; i <nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }
                printArray(dp);
            }
            return dp.Max();
        }
    }
}
