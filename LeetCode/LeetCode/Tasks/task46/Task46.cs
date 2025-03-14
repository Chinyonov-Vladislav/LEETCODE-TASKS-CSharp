using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task46
{
    /*
     46. Перестановки
    Учитывая массив nums из различных целых чисел, верните все возможные перестановки. Вы можете возвращать ответ в любом порядке.
    Ограничения:
        1 <= nums.length <= 6
        -10 <= nums[i] <= 10
        Все целые числа nums являются уникальными.
    https://leetcode.com/problems/permutations/description/
     */
    public class Task46 : InfoBasicTask
    {
        public Task46(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 2, 3 };
            printArray(nums);
            if (isValid(nums))
            {
                IList<IList<int>> result = permute(nums);
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
            if (nums.Length < 1 || nums.Length > 6)
            {
                return false;
            }
            foreach (int num in nums) {
                if (num < -10 || num > 10)
                {
                    return false;
                }
            }
            HashSet<int> set = new HashSet<int>(nums);
            if (set.Count != nums.Length)
            {
                return false;
            }
            return true;
        }
        private IList<IList<int>> permute(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            doPermute(nums, 0, nums.Length - 1, result);
            return result;
        }
        private void doPermute(int[] nums, int start, int end, IList<IList<int>> list)
        {
            if (start == end)
            {
                list.Add(new List<int>(nums));
            }
            else
            {
                for (var i = start; i <= end; i++)
                {
                    (nums[start], nums[i]) = (nums[i], nums[start]);
                    doPermute(nums, start + 1, end, list);
                    (nums[start], nums[i]) = (nums[i], nums[start]);
                }
            }
        }
    }
}
