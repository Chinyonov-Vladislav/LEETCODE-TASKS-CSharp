using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task674
{
    /*
     674. Самая длинная непрерывная возрастающая подпоследовательность
     Учитывая несортированный массив целых чисел nums, верните длину самой длинной непрерывной возрастающей подпоследовательности (т. е. подмассива). 
    Подпоследовательность должна быть строго возрастающей.
    Непрерывная возрастающая подпоследовательность определяется двумя индексами l и r (l < r), такими что [nums[l], nums[l + 1], ..., nums[r - 1], nums[r]] и для каждого l <= i < rnums[i] < nums[i + 1].
    https://leetcode.com/problems/longest-continuous-increasing-subsequence/description/
     */
    public class Task674 : InfoBasicTask
    {
        public Task674(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 3, 5, 4, 7 };
            nums = new int[] { 2,2,2,2,2 };
            printArray(nums, "Исходный массив: ");
            Console.WriteLine($"Самая длинная непрерывная возрастающая подпоследовательность = {findLengthOfLCIS(nums)}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int findLengthOfLCIS(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 1;
            }
            int currentLength = 1;
            int maxLength = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[i - 1])
                {
                    currentLength++;
                }
                else
                {
                    if (maxLength < currentLength)
                    {
                        maxLength = currentLength;
                    }
                    currentLength = 1;
                }
            }
            if (maxLength < currentLength)
            {
                maxLength = currentLength;
            }
            return maxLength;
        }
    }
}
