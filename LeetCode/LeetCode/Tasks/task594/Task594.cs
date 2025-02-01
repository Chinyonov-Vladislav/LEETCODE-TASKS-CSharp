using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task594
{
    /*
     594. Самая длинная гармоничная последовательность
        Мы определяем гармоничный массив как массив, в котором разница между максимальным и минимальным значениями ровна 1.
        Учитывая целочисленный массив nums, верните длину его самого длинной гармоничной поподпоследовательности среди всех его возможных подпоследовательностей.
        https://leetcode.com/problems/longest-harmonious-subsequence/description/
     */
    public class Task594 : InfoBasicTask
    {
        public Task594(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] numbers = new int[] { 1, 3, 2, 2, 5, 2, 3, 7 };
            int longestHarmonicSubsequence = findLHS(numbers);
            Console.WriteLine($"Длина самой длинной гармоничной подпоследовательности равна = {longestHarmonicSubsequence}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int findLHS(int[] nums)
        {
            int max = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int centerNumber = nums[i];
                int leftNumber = nums[i] - 1;
                int rightNumber = nums[i] + 1;
                int countCenter = 1;
                int countLeft = 0;
                int countRight = 0;
                for (int j = i+1; j < nums.Length; j++)
                {
                    if (nums[j] == centerNumber)
                    {
                        countCenter++;
                    }
                    else if (nums[j] == leftNumber)
                    {
                        countLeft++;
                    }
                    else if (nums[j] == rightNumber)
                    {
                        countRight++;
                    }
                }
                if (countCenter + countLeft > max && countLeft != 0)
                {
                    max = countCenter + countLeft;
                }
                if (countCenter + countRight > max && countRight != 0)
                {
                    max = countCenter + countRight;
                }
            }
            return max;
        }
        private int bestSolution(int[] nums) // скопировано с leetcode
        {
            var dict = new Dictionary<int, int>();
            for (var i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    dict[nums[i]]++;
                }
                else
                {
                    dict.Add(nums[i], 1);
                }
            }
            var max = 0;
            foreach (var keyValuePair in dict)
            {
                if (dict.ContainsKey(keyValuePair.Key + 1))
                {
                    max = Math.Max(max, keyValuePair.Value + dict[keyValuePair.Key + 1]);
                }
            }

            return max;
        }
    }
}
