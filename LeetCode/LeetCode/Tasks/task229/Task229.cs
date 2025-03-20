using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task229
{
    /*
     229. Элемент большинства II
    Дан целочисленный массив размером n, найдите все элементы, которые встречаются более n/3 раз.
    Ограничения:
        1 <= nums.length <= 5 * 10^4
        -10^9 <= nums[i] <= 10^9
    https://leetcode.com/problems/majority-element-ii/description/
     */
    public class Task229 : InfoBasicTask
    {
        public Task229(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 3, 2, 3 };
            printArray(nums);
            if (isValid(nums))
            {
                IList<int> result = majorityElement(nums);
                printIListInt(result, $"Список чисел, частота появления которых в исходном массиве больше, чем {nums.Length/3}: ");
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
            int lowLimit = 1;
            int highLimit = 5*(int)Math.Pow(10,4);
            if (nums.Length < lowLimit || nums.Length > highLimit)
            {
                return false;
            }
            lowLimit = -1*(int)Math.Pow(10,9);
            highLimit = (int)Math.Pow(10, 9);
            foreach (int num in nums)
            {
                if (num < lowLimit || num > highLimit)
                {
                    return false;
                }
            }
            return true;
        }
        private IList<int> majorityElement(int[] nums)
        {
            IList<int> result = new List<int>();
            int border = nums.Length / 3;
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (dict.ContainsKey(num))
                {
                    dict[num]++;
                }
                else
                {
                    dict.Add(num, 1);
                }
                if (dict[num] > border && !result.Contains(num))
                {
                    result.Add(num);
                }
            }
            return result;
        }
    }
}
