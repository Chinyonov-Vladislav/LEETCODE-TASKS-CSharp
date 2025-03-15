using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task78
{
    /*
     78. Подмножества
    Учитывая целочисленный массив numsуникальных элементов, верните все возможные подмножества (множество всех подмножеств).
    Набор решений не должен содержать повторяющиеся подмножества. Верните решение в любом порядке.
    Ограничения:
        1 <= nums.length <= 10
        -10 <= nums[i] <= 10
        Все числа nums являются уникальными.
    https://leetcode.com/problems/subsets/description/
     */
    public class Task78 : InfoBasicTask
    {
        public Task78(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 2, 3 };
            printArray(nums);
            if (isValid(nums))
            {
                IList<IList<int>> result = subsets(nums);
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
            if (nums.Length < 1 || nums.Length > 10)
            {
                return false;
            }
            foreach (int num in nums) {
                if (num < 10 || num > 10)
                {
                    return false;
                }
            }
            return true;
        }
        private IList<IList<int>> subsets(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>() { new List<int>() };
            foreach (int num in nums) {
                IList<IList<int>> newSubsets = new List<IList<int>>();
                foreach (IList<int> subset in result)
                {
                    IList<int> newSubset = new List<int>(subset);
                    newSubset.Add(num);
                    newSubsets.Add(newSubset);
                }
                foreach (var newSubset in newSubsets)
                {
                    result.Add(newSubset);
                }
            }
            return result;
        }
    }
}
