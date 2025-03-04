using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2784
{
    /*
     2784. Проверьте, хорош ли массив
    Вам дан целочисленный массив nums. Мы считаем массив хорошим, если он является перестановкой массива base[n].
    base[n] = [1, 2, ..., n - 1, n, n] (другими словами, это массив длины, n + 1 который содержит 1 to n - 1 ровно один раз, плюс два вхождения n). Например, base[1] = [1, 1] и base[3] = [1, 2, 3, 3].
    Верните true , если данный массив является хорошим, в противном случае верните false.
    Примечание: Перестановка целых чисел представляет собой расположение этих чисел.
    Ограничения:
        1 <= nums.length <= 100
        1 <= num[i] <= 200
    https://leetcode.com/problems/check-if-array-is-good/description/
     */
    public class Task2784 : InfoBasicTask
    {
        public Task2784(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 2, 1, 3 };
            printArray(nums);
            if (isValid(nums))
            {
                Console.WriteLine(isGood(nums) ? "Массив является хорошим" : "Массив не является хорошим");
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
            if (nums.Length < 1 || nums.Length > 100)
            {
                return false;
            }
            foreach (int num in nums)
            {
                if (num < 1 || num > 200)
                {
                    return false;
                }
            }
            return true;
        }
        private bool isGood(int[] nums)
        {
            int max = nums.Max();
            if (nums.Length != max + 1)
            {
                return false;
            }
            Array.Sort(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == nums.Length - 1)
                {
                    if (nums[i] != max)
                    {
                        return false;
                    }
                }
                else
                {
                    if (nums[i] != i +1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
