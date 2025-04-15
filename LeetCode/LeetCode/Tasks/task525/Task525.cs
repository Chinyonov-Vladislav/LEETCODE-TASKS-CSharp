using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task525
{
    /*
     525. Непрерывный массив
    Учитывая двоичный массив nums, верните максимальную длину непрерывного подмассива с равным количеством 0 и 1.
    Ограничения:
        1 <= nums.length <= 10^5
        nums[i] является либо 0, либо 1.
    https://leetcode.com/problems/contiguous-array/description/
     */
    public class Task525 : InfoBasicTask
    {
        public Task525(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 0, 1, 1, 1, 1, 1, 0, 0, 0 };
            printArray(nums);
            if (isValid(nums))
            {
                int res = findMaxLength(nums);
                Console.WriteLine($"Максимальная длина подмассива, состоящего из равного количества 0 и 1 = {res}");
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
            int lowLimitLengthNum = 1;
            int highLimitLengthNum = (int)Math.Pow(10,5);
            if (nums.Length < lowLimitLengthNum || nums.Length > highLimitLengthNum)
            {
                return false;
            }
            List<int> acceptedValuesForNum = new List<int>() { 0,1 };
            foreach (int num in nums)
            {
                if (!acceptedValuesForNum.Contains(num))
                {
                    return false;
                }
            }
            return true;
        }
        private int findMaxLength(int[] nums)
        {
            Dictionary<int,int> dict= new Dictionary<int,int>();
            int currentPrefixSum = 0;
            dict.Add(0, -1);
            int max = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    currentPrefixSum--;
                }
                else
                {
                    currentPrefixSum++;
                }
                if (dict.ContainsKey(currentPrefixSum))
                {
                    int length = i - dict[currentPrefixSum];
                    if (length > max)
                    {
                        max = length;
                    }
                }
                else
                {
                    dict.Add(currentPrefixSum, i);
                }
            }
            return max;
        }
    }
}
