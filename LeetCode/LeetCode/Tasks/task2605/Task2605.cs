using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2605
{
    /*
     2605. Сформируйте наименьшее число из двух массивов уникальных чисел, используя как минимум одну цифру из каждого массива
    Учитывая два массива уникальных цифр nums1 и nums2, верните наименьшее число, содержащее по крайней мере одну цифру из каждого массива.
    Ограничения:
        1 <= nums1.length, nums2.length <= 9
        1 <= nums1[i], nums2[i] <= 9
        Все цифры в каждом массиве являются уникальными.
    https://leetcode.com/problems/form-smallest-number-from-two-digit-arrays/description/
     */
    public class Task2605 : InfoBasicTask
    {
        public Task2605(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] num1 = new int[] { 4, 1, 3 };
            int[] num2 = new int[] { 5, 7 };
            printArray(num1, "Массив №1: ");
            printArray(num2, "Массив №2: ");
            if (isValid(num1, num2))
            {
                int res = minNumber(num1, num2);
                Console.WriteLine($"Наименьшее число, которое может быть сформировано = {res}");
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
        private bool isValid(int[] nums1, int[] nums2)
        {
            if (nums1.Length < 1 || nums1.Length > 9 || nums2.Length < 1 || nums2.Length > 9)
            {
                return false;
            }
            foreach (int num in nums1) {
                if (num < 1 || num > 9)
                {
                    return false;
                }
            }
            foreach (int num in nums2)
            {
                if (num < 1 || num > 9)
                {
                    return false;
                }
            }
            HashSet<int> nums1Set = new HashSet<int>(nums1);
            if (nums1Set.Count != nums1.Length)
            {
                return false;
            }
            HashSet<int> nums2Set = new HashSet<int>(nums2);
            if (nums2Set.Count != nums2.Length)
            {
                return false;
            }
            return true;
        }
        private int minNumber(int[] nums1, int[] nums2)
        {
            HashSet<int> setNums = new HashSet<int>(nums1);
            foreach (int num in nums2) {
                setNums.Add(num);
            }
            if (setNums.Count == nums1.Length+nums2.Length)
            {
                int minNums1 = nums1.Min();
                int minNums2 = nums2.Min();
                if (minNums1 < minNums2)
                {
                    return minNums1 * 10 + minNums2;
                }
                else
                {
                    return minNums2 * 10 + minNums1;
                }
            }
            else
            {
                int min = Int32.MaxValue;
                foreach (var item in nums1)
                {
                    if (nums2.Contains(item) && item < min)
                    {
                        min = item;
                    }
                }
                return min;
            }
        }
    }
}
