using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task47
{
    /*
     47. Перестановки II
    Учитывая набор чисел nums, который может содержать дубликаты, верните все возможные уникальные перестановкив любом порядке.
    Ограничения:
        1 <= nums.length <= 8
        -10 <= nums[i] <= 10
    https://leetcode.com/problems/permutations-ii/description/
     */
    public class Task47 : InfoBasicTask
    {
        public Task47(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] {1,1,2 };
            printArray(nums);
            if (isValid(nums))
            {
                IList<IList<int>> result = permuteUnique(nums);
                Console.WriteLine($"Результат: ");
                printIListIListInt(result);
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
            if (nums.Length < 1 || nums.Length > 8)
            {
                return false;
            }
            foreach (int num in nums) {
                if (num < -10 || num > 10)
                {
                    return false;
                }
            }
            return true;
        }
        private IList<IList<int>> permuteUnique(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Array.Sort(nums);
            bool[] visited = new bool[nums.Length];
            List<int> currentPermutation = new List<int>();
            dfs(nums, 0, visited, currentPermutation, result);
            return result;
        }
        private void dfs(int[] nums, int index, bool[] visited, List<int> currentPermutation, IList<IList<int>> result)
        {
            if (index == nums.Length)
            {
                result.Add(new List<int>(currentPermutation));
                return;
            }
            for (int j = 0; j < nums.Length; ++j)
            {
                if (visited[j] || (j > 0 && nums[j] == nums[j - 1] && !visited[j - 1]))
                {
                    continue;
                }
                visited[j] = true;
                currentPermutation.Add(nums[j]);
                dfs(nums, index + 1,visited, currentPermutation, result);
                currentPermutation.RemoveAt(currentPermutation.Count - 1);
                visited[j] = false;
            }
        }
    }
}
