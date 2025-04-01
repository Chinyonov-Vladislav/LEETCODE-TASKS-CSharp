using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task18
{
    /*
     18. 4Sum
    Учитывая массив nums целых чисел n, верните массив всехуникальныхчетвёрок [nums[a], nums[b], nums[c], nums[d]], таких что:
        0 <= a, b, c, d < n
        a, b, c и d являются различными.
        nums[a] + nums[b] + nums[c] + nums[d] == target
    Вы можете вернуть ответ в любом порядке.
    Ограничения:
        1 <= nums.length <= 200
        -10^9 <= nums[i] <= 10^9
        -10^9 <= target <= 10^9
    https://leetcode.com/problems/4sum/description/
     */
    public class Task18 : InfoBasicTask
    {
        public Task18(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 0, -1, 0, -2, 2 };
            int target = 0;
            printArray(nums);
            Console.WriteLine($"Целевая сумма = {target}");
            if (isValid(nums, target))
            {
                IList<IList<int>> res = fourSum(nums, target);
                printIListIListInt(res, $"Результирующий список списков целых уникальных 4 чисел, которые в сумме дают число {target}");
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
        private bool isValid(int[] nums, int target)
        {
            int lowLimit = 1;
            int highLimit = 200;
            if (nums.Length < lowLimit || nums.Length > highLimit)
            {
                return false;
            }
            lowLimit = -1 * (int)Math.Pow(10, 9);
            highLimit = (int)Math.Pow(10, 9);
            foreach (int num in nums)
            {
                if (num<lowLimit || num>highLimit)
                {
                    return false;
                }
            }
            if (target < lowLimit || target > highLimit)
            {
                return false;
            }
            return true;
        }
        private IList<IList<int>> fourSum(int[] nums, int target)
        {
            IList<IList<int>> res = new List<IList<int>>();
            Array.Sort(nums);
            for (int a = 0; a < nums.Length - 3; a++)
            {
                if (a > 0 && nums[a] == nums[a - 1])
                {
                    continue;
                }
                for (int b = a + 1; b < nums.Length - 2; b++)
                {
                    if (b > a+1 && nums[b] == nums[b - 1])
                    {
                        continue;
                    }
                    int c = b + 1;
                    int d = nums.Length - 1;
                    while (c < d)
                    {

                        long sum = (long)nums[a] + (long)nums[b] + (long)nums[c] + (long)nums[d];
                        if (sum == target)
                        {
                            res.Add(new List<int>() { nums[a], nums[b], nums[c], nums[d] });
                            d = nums.Length - 1;
                            while (c < d && nums[c] == nums[c + 1])
                            {
                                c++;
                            }
                            c++;
                        }
                        else if (sum > target)
                        {
                            d--;
                        }
                        else
                        {
                            c++;
                        }
                    }
                }
            }
            return res;
        }
    }
}
