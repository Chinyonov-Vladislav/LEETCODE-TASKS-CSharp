using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task540
{
    /*
     540. Одиночный элемент в отсортированном массиве
    Вам дан отсортированный массив, состоящий только из целых чисел, в котором каждый элемент встречается ровно дважды, за исключением одного элемента, который встречается ровно один раз.
    Возвращает единственный элемент, который появляется только один раз.
    Ваше решение должно выполняться во O(log n) времени и O(1) пространстве.
    Ограничения:
        1 <= nums.length <= 10^5
        0 <= nums[i] <= 10^5
    https://leetcode.com/problems/single-element-in-a-sorted-array/description/
     */
    public class Task540 : InfoBasicTask
    {
        public Task540(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 2, 2, 3, 3 };
            printArray(nums);
            if (isValid(nums))
            {
                int res = singleNonDuplicate(nums);
                Console.WriteLine($"Результат = {res}");
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
            int lowLimitLengthNums = 1;
            int highLimitLengthNums = (int)Math.Pow(10,5);
            int lowLimitValueNums = 0;
            int highLimitValueNums = (int)Math.Pow(10, 5);
            if (nums.Length < lowLimitLengthNums || nums.Length > highLimitLengthNums)
            {
                return false;
            }
            Dictionary<int,int> dict = new Dictionary<int,int>();
            foreach (int num in nums)
            {
                if (num < lowLimitValueNums || num > highLimitValueNums)
                {
                    return false;
                }
                if (dict.ContainsKey(num))
                {
                    dict[num]++;
                }
                else
                {
                    dict.Add(num, 1);
                }
            }
            int countOne = 0;
            int countTwo = 0;
            foreach (var pair in dict)
            {
                if (pair.Value == 2)
                {
                    countTwo++;
                }
                if (pair.Value == 1)
                {
                    countOne++;
                }
            }
            if (nums.Length != countTwo * 2 + countOne)
            {
                return false;
            }
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < nums[i - 1])
                {
                    return false;
                }
            }
            return true;
        }
        private int singleNonDuplicate(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (mid > 0 && mid < nums.Length - 1)
                {
                    if (nums[mid] != nums[mid - 1] && nums[mid] != nums[mid + 1])
                    {
                        return nums[mid];
                    }
                    else if (nums[mid] == nums[mid - 1])
                    {
                        if ((mid - 1) % 2 == 0 && mid % 2 != 0)
                        {
                            left = mid + 1;
                        }
                        if ((mid - 1) % 2 != 0 && mid % 2 == 0)
                        {
                            right = mid - 1;
                        }
                    }
                    else
                    {
                        if ((mid + 1) % 2 == 0 && mid % 2 != 0)
                        {
                            right = mid - 1;

                        }
                        if ((mid + 1) % 2 != 0 && mid % 2 == 0)
                        {
                            left = mid + 1;
                        }
                    }
                }
                else if (mid == 0)
                {
                    if (nums[mid] != nums[mid + 1])
                    {
                        return nums[mid];
                    }
                }
                else
                {
                    if (nums[mid] != nums[mid - 1])
                    {
                        return nums[mid];
                    }
                }
                
            }
            return nums[left];
        }
    }
}
