using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1512
{
    /*
     1512. Количество хороших пар
    Учитывая массив целых чисел nums, верните количествохороших пар.
    Пара (i, j) называется хорошей, если nums[i] == nums[j] и i < j.
    https://leetcode.com/problems/number-of-good-pairs/description/
     */
    public class Task1512 : InfoBasicTask
    {
        public Task1512(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 2, 3, 1, 1, 3 };
            printArray(nums, "Исходный массив: ");
            int countGoodPair = numIdenticalPairs(nums);
            Console.WriteLine($"Количество хороших пар в массиве = {countGoodPair}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int numIdenticalPairs(int[] nums)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
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
            int countGoodPair = 0;
            foreach (var pair in dict)
            {
                countGoodPair+= pair.Value * (pair.Value - 1) / 2;
            }
            return countGoodPair;
        }
    }
}
