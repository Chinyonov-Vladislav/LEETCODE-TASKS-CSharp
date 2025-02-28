using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2529
{
    /*
     2529. Максимальное количество положительных и отрицательных целых чисел
    Учитывая, что массив nums отсортирован в неубывающем порядке, верните максимальное значение между количеством положительных и количеством отрицательных целых чисел.
    Другими словами, если количество положительных целых чисел в nums равно pos, а количество отрицательных целых чисел равно neg, то верните максимальное значение из pos и neg
    Обратите внимание, что 0 это не является ни положительным, ни отрицательным.
    Ограничения:
        1 <= nums.length <= 2000
        -2000 <= nums[i] <= 2000
        nums сортируется в неубывающем порядке.
    https://leetcode.com/problems/maximum-count-of-positive-integer-and-negative-integer/description/
     */
    public class Task2529 : InfoBasicTask
    {
        public Task2529(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array = new int[] { -3, -2, -1, 0, 0, 1, 2 };
            printArray(array);
            if (isValid(array))
            {
                int res = maximumCount(array);
                Console.WriteLine($"Максимальное количество = {res}");
            }
            else
            {
                Console.WriteLine("Исходные данные не валидны!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(int[] nums)
        {
            if (nums.Length < 1 || nums.Length > 2000)
            {
                return false;
            }
            foreach (int num in nums) {
                if (num < -2000 || num > 2000)
                {
                    return false;
                }
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
        private int maximumCount(int[] nums)
        {
            int countPositive = 0;
            int countNegative = 0;
            int left = 0;
            int right = nums.Length - 1;
            while (left <= right) {
                if (nums[left] == 0 && nums[right] == 0)
                {
                    break;
                }
                if (nums[left] < 0)
                {
                    countNegative++;
                    left++;
                }
                if (nums[right] > 0)
                {
                    countPositive++;
                    right--;
                }
            }
            return Math.Max(countPositive, countNegative);
        }
    }
}
