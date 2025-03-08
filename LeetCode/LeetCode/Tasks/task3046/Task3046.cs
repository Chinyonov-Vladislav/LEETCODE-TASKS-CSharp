using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3046
{
    /*
     3046. Разделите массив
    Вам дан целочисленный массив numsчётной длины. Вам нужно разделить массив на две части nums1 и nums2 таким образом, чтобы:
        nums1.length == nums2.length == nums.length / 2.
        nums1 должен содержать отдельные элементы.
        nums2 также должен содержать отдельные элементы.
    Верните trueесли можно разделить массив, иfalse в противном случае.
    Ограничения:
        1 <= nums.length <= 100
        nums.length % 2 == 0 
        1 <= nums[i] <= 100
    https://leetcode.com/problems/split-the-array/description/
     */
    public class Task3046 : InfoBasicTask
    {
        public Task3046(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 1, 2, 2, 3, 4 };
            printArray(nums);
            if (isValid(nums))
            {
                Console.WriteLine(isPossibleToSplit(nums) ? 
                    "Возможно распределить элементы массива на два массива одинаковой длины так, чтобы каждый элемент был уникален в рамках своего массива" :
                    "Невозможно распределить элементы массива на два массива одинаковой длины так, чтобы каждый элемент был уникален в рамках своего массива");
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
            if (nums.Length < 1 || nums.Length > 100)
            {
                return false;
            }
            if (nums.Length % 2 != 0)
            {
                return false;
            }
            foreach (int num in nums)
            {
                if (num < 1 || num > 100)
                {
                    return false;
                }
            }
            return true;
        }
        private bool isPossibleToSplit(int[] nums)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (int num in nums) {
                if (dict.ContainsKey(num))
                {
                    dict[num]++;
                    if (dict[num] > 2)
                    {
                        return false;
                    }
                }
                else
                {
                    dict.Add(num, 1);
                }
            }
            return true;
        }
    }
}
