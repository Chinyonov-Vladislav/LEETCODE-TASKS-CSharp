using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task215
{
    /*
     215. K-й по величине элемент в массиве
    Учитывая целочисленный массив nums и целое число k, верните самый kth большой элемент в массиве.
    Обратите внимание, что это kth самый большой элемент в отсортированном порядке, а не kth отдельный элемент.
    Можете ли вы решить эту проблему без сортировки?
    Ограничения:
        1 <= k <= nums.length <= 10^5
        -10^4 <= nums[i] <= 10^4
    https://leetcode.com/problems/kth-largest-element-in-an-array/description/
     */
    public class Task215 : InfoBasicTask
    {
        public Task215(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 3, 2, 1, 5, 6, 4 };
            int k = 2;
            printArray(nums);
            Console.WriteLine($"Значение переменной k (самой большой элемент в отсортированном порядке) = {k}");
            if (isValid(nums, k))
            {
                int res = findKthLargest(nums, k);
                Console.WriteLine($"{k} самый большой элемент в массиве = {res}");
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
        private bool isValid(int[] nums, int k)
        {
            int lowLimitValueNum = -1* (int)Math.Pow(10, 4); ;
            int highLimitValueNum = (int)Math.Pow(10,4);
            int lowLimitLengthNums = 1;
            int highLimitLengthNums = (int)Math.Pow(10,5);
            if (!(lowLimitLengthNums <= k && k <= nums.Length && nums.Length <= highLimitLengthNums))
            {
                return false;
            }
            foreach (int num in nums)
            {
                if (num < lowLimitValueNum || num > highLimitValueNum)
                {
                    return false;
                }
            }
            return true;
        }
        private int findKthLargest(int[] nums, int k)
        {
            Array.Sort(nums);
            return nums[nums.Length - k];
        }
    }
}
