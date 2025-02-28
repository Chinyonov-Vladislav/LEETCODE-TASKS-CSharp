using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.Task2475
{
    /*
     2475. Количество неравных триплетов в массиве
    Вам дан массив с индексацией от 0 положительных целых чисел nums. Найдите количество троек (i, j, k), удовлетворяющих следующим условиям:
        0 <= i < j < k < nums.length
        nums[i], nums[j], и nums[k] являются попарно различными.
        Другими словами, nums[i] != nums[j], nums[i] != nums[k] и nums[j] != nums[k].
    Возвращает количество троек, удовлетворяющих условиям.
    Ограничения:
        3 <= nums.length <= 100
        1 <= nums[i] <= 1000
    https://leetcode.com/problems/number-of-unequal-triplets-in-array/description/
     */
    public class Task2475 : InfoBasicTask
    {
        public Task2475(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 4, 4, 2, 4, 3 };
            printArray(nums);
            if (isValid(nums))
            {
                int count = unequalTriplets(nums);
                Console.WriteLine($"Количество неравных триплетов в массиве = {count}");
            }
            else
            {
                Console.WriteLine("Невалидные исходные данные!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(int[] nums)
        {
            if (nums.Length < 3 || nums.Length > 1000)
            {
                return false;
            }
            foreach (int num in nums) {
                if (num < 1 || num > 1000)
                {
                    return false;
                }
            }
            return true;
        }
        private int unequalTriplets(int[] nums)
        {
            int count = 0;
            for (int i = 0; i < nums.Length - 2; i++)
            {
                for (int j = i + 1; j < nums.Length - 1; j++)
                {
                    for (int k = j + 1; k < nums.Length; k++)
                    {
                        if (nums[i] != nums[j] && nums[i] != nums[k] && nums[j] != nums[k])
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }
    }
}
