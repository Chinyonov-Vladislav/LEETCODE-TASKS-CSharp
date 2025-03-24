using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task398
{
    public class Solution
    {
        private Dictionary<int, List<int>> dict;
        private Random random;
        public Solution(int[] nums)
        {
            random = new Random();
            dict = new Dictionary<int, List<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    dict[nums[i]].Add(i);
                }
                else
                {
                    dict.Add(nums[i], new List<int>() { i});
                }
            }
        }

        public int Pick(int target)
        {
            List<int> indexs = dict[target];
            return indexs[random.Next(0, indexs.Count)];
        }
    }
}
