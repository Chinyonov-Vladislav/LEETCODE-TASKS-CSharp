using LeetCode.Basic;
using System;
using System.Collections.Generic;

namespace LeetCode.Tasks.task219
{
    /*
     219. Содержит дубликат II
    Учитывая целочисленный массив nums и целое число k, верните true если в массиве есть два разных индекса i и j таких, что nums[i] == nums[j] и abs(i - j) <= k.
     */
    public class Task219 : InfoBasicTask
    {
        public Task219(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 2, 3, 1, 2, 3 };
            int k = 2;
            Console.WriteLine(containsNearbyDuplicate(nums, k) ? "Есть индексы i и j, которые соответствуют правилам" : "Нет индексов i и j, которые соответствуют правилам");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool containsNearbyDuplicate(int[] nums, int k)
        {
            if (nums.Length == new HashSet<int>(nums).Count)
            {
                return false;
            }
            if (nums.Length < 2)
            {
                return false;
            }
            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    dict[nums[i]].Add(i);
                }
                else
                {
                    dict.Add(nums[i], new List<int>() { i });
                }
            }
            foreach (var item in dict)
            {
                List<int> currentIndexs = item.Value;
                for (int i = 0; i < currentIndexs.Count; i++)
                {
                    for (int j = 0; j < currentIndexs.Count; j++)
                    {
                        if (i == j)
                        {
                            continue;
                        }
                        if (Math.Abs(currentIndexs[i] - currentIndexs[j]) <= k)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
