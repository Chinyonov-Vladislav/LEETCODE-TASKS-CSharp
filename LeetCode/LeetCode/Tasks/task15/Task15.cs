using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task15
{
    /*
     15. 3Sum
    Учитывая целочисленный массив nums, верните все тройки, [nums[i], nums[j], nums[k]] такие что i != j, i != k, и j != k, и nums[i] + nums[j] + nums[k] == 0.
    Обратите внимание, что набор решений не должен содержать повторяющихся триплетов.
    Ограничения:
        3 <= nums.length <= 3000
        -10^5 <= nums[i] <= 10^5
    https://leetcode.com/problems/3sum/description/
     */
    public class Task15 : InfoBasicTask
    {
        public Task15(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] arr = new int[] { -1, 0, 1, 2, -1, -4 };
            printArray(arr);
            if (isValid(arr))
            {
                IList<IList<int>> res = threeSum(arr);
                printIListIListInt(res, "Результат");
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
            int lowLimit = 3;
            int highLimit = 3000;
            if (nums.Length < lowLimit || nums.Length > highLimit)
            {
                return false;
            }
            lowLimit = -1 * (int)Math.Pow(10, 5);
            highLimit = (int)Math.Pow(10, 5);
            foreach (int num in nums)
            {
                if (num < lowLimit || num > highLimit)
                {
                    return false;
                }
            }
            return true;
        }
        private IList<IList<int>> threeSum(int[] nums)
        {
            IList<IList<int>> res = new List<IList<int>>();
            Array.Sort(nums);
            for (int i = 0; i < nums.Length-2; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }
                int target = 0 - nums[i];
                int j = i + 1;
                int k = nums.Length - 1;
                while (j < k)
                {
                    if (target == nums[j] + nums[k])
                    {
                        res.Add(new List<int>() { nums[i], nums[j], nums[k] });
                        k = nums.Length - 1;
                        while (j < k && nums[j] == nums[j + 1])
                        {
                            j++;
                        }
                        j++;
                    }
                    else if (target > nums[j] + nums[k])
                    {
                        j++;
                    }
                    else
                    {
                        k--;
                    }
                }
            }
            return res;
        }
    }
}
