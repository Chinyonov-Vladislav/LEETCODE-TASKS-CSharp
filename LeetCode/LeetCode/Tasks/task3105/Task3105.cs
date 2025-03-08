using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3105
{
    /*
     3105. Самый длинный строго возрастающий или строго убывающий подмассив
    Вам будет предоставлен массив целых чисел nums. Верните длину самого длинного подмассива. Подмассив of nums который либо строго увеличиваетсяилистрого уменьшающийся.
     Ограничения:
        1 <= nums.length <= 50
        1 <= nums[i] <= 50
    https://leetcode.com/problems/longest-strictly-increasing-or-strictly-decreasing-subarray/description/
     */
    public class Task3105 : InfoBasicTask
    {
        public Task3105(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 4, 3, 3, 2 };
            printArray(nums);
            if (isValid(nums))
            {
                int max = longestMonotonicSubarray(nums);
                Console.WriteLine($"Максимальная длина строго убывающего или возрастающего подмассива = {max}");
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
            if (nums.Length < 1 || nums.Length > 50)
            {
                return false;
            }
            foreach (int num in nums)
            {
                if (num < 1 || num > 50)
                {
                    return false;
                }
            }
            return true;
        }
        private int longestMonotonicSubarray(int[] nums)
        {
            int maxLength = 1;
            int length = 2;
            while (length != nums.Length + 1)
            {
                for (int i = 0; i <= nums.Length - length; i++)
                {
                    int endIndex = i + length;
                    bool isIncrease = true;
                    bool isDecrease = true;
                    for (int index = i+1; index < endIndex; index++)
                    {
                        if (nums[index - 1] >= nums[index])
                        {
                            isIncrease = false;
                        }
                    }
                    for (int index = i + 1; index < endIndex; index++)
                    {
                        if (nums[index - 1] <= nums[index])
                        {
                            isDecrease = false;
                        }
                    }
                    if ((isIncrease || isDecrease) && length > maxLength)
                    {
                        maxLength = length;
                    }
                }
                length++;
            }
            return maxLength;
        }
    }
}
