using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2824
{
    /*
     2824. Подсчитайте пары, сумма которых меньше целевого значения
    Учитывая нумерованный с 0 целочисленный массив nums длиной n и целое число target, верните количество пар (i, j) где 0 <= i < j < n и nums[i] + nums[j] < target.
    Ограничения:
        1 <= nums.length == n <= 50
        -50 <= nums[i], target <= 50
    https://leetcode.com/problems/count-pairs-whose-sum-is-less-than-target/description/
     */
    public class Task2824 : InfoBasicTask
    {
        public Task2824(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            IList<int> nums = new List<int>() { -1, 1, 2, 3, 1 };
            printIListInt(nums, "Исходный список целых чисел: ");
            int target = 2;
            Console.WriteLine($"Целевое число = {target}");
            if (isValid(nums, target))
            {
                int res = countPairs(nums, target);
                Console.WriteLine($"Количество пар чисел, которые в сумме меньше {target} = {res}");
            }
            else {
                Console.WriteLine("Исходные данные не валидны!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(IList<int> nums, int target)
        {
            if (nums.Count < 1 || nums.Count > 50)
            {
                return false;
            }
            if (target < -50 || target > 50)
            {
                return false;
            }
            foreach (int item in nums)
            {
                if (item < -50 || item > 50)
                {
                    return false;
                }
            }
            return true;
        }
        private int countPairs(IList<int> nums, int target)
        {
            int count = 0;
            for (int i = 0; i < nums.Count - 1; i++)
            {
                for (int j = i + 1; j < nums.Count; j++)
                {
                    if (nums[i] + nums[j] < target)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
