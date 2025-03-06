using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3131
{
    /*
     3131. Найдите целое число, добавленное в массив I
    Вам даны два массива равной длины, nums1 и nums2.
    Каждый элемент в nums1 был увеличен (или уменьшен в случае отрицательного значения) на целое число, представленное переменной x.
    В результате nums1 становится равным nums2. Два массива считаются равными, если они содержат одинаковые целые числа с одинаковой частотой.
    Возвращает целое число x.
    Ограничения:
        1 <= nums1.length == nums2.length <= 100
        0 <= nums1[i], nums2[i] <= 1000
        Тестовые примеры генерируются таким образом, что существует целое число x такое, что nums1 может стать равным nums2 путём добавления x к каждому элементу nums1.
    https://leetcode.com/problems/find-the-integer-added-to-array-i/description/
     */
    public class Task3131 : InfoBasicTask
    {
        public Task3131(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums1 = new int[] { 2, 6, 4 };
            int[] nums2 = new int[] { 9, 7, 5 };
            printArray(nums1, "Массив чисел №1: ");
            printArray(nums2, "Массив чисел №2: ");
            if (isValid(nums1, nums2))
            {
                int diff = addedInteger(nums1, nums2);
                Console.WriteLine($"Целое число, добавляемое к каждому элементу массива №1, равно {diff}");
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
        private bool isValid(int[] nums1, int[] nums2)
        {
            if (nums1.Length != nums2.Length)
            {
                return false;
            }
            if (nums1.Length < 1 || nums1.Length > 100 || nums2.Length < 1 || nums2.Length > 100)
            {
                return false;
            }
            foreach (int num in nums1) {
                if (num < 0 || num > 1000)
                {
                    return false;
                }
            }
            foreach (int num in nums2)
            {
                if (num < 0 || num > 1000)
                {
                    return false;
                }
            }
            Array.Sort(nums1);
            Array.Sort(nums2);
            int diff = nums2[0] - nums1[0];
            for (int i = 0; i < nums1.Length; i++)
            {
                if (nums2[i] != nums1[i] + diff)
                {
                    return false;
                }
            }
            return true;
        }
        private int addedInteger(int[] nums1, int[] nums2)
        {
            Array.Sort(nums1);
            Array.Sort(nums2);
            return nums2[0] - nums1[0];
        }
    }
}
