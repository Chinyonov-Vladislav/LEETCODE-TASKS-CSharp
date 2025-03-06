using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3162
{
    /*
     3162. Найдите количество хороших пар I
    Вам даны 2 целочисленных массива nums1 и nums2 длиной n и m соответственно. Вам также дано положительное целое число k.
    Пара (i, j) называется хорошей, если nums1[i] делится на nums2[j] * k (0 <= i <= n - 1, 0 <= j <= m - 1).
    Возвращает общее количество хороших пар.
    Ограничения:
        1 <= n, m <= 50
        1 <= nums1[i], nums2[j] <= 50
        1 <= k <= 50
    https://leetcode.com/problems/find-the-number-of-good-pairs-i/description/
     */
    public class Task3162 : InfoBasicTask
    {
        public Task3162(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums1 = new int[] { 1, 3, 4 };
            int[] nums2 = new int[] { 1, 3, 4 };
            int k = 1;
            printArray(nums1, "Массив №1: ");
            printArray(nums2, "Массив №2: ");
            Console.WriteLine($"Значение переменной k = {k}");
            if (isValid(nums1, nums2, k))
            {
                int count = numberOfPairs(nums1, nums2, k);
                Console.WriteLine($"Количество пар = {count}");
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
        private bool isValid(int[] nums1, int[] nums2, int k)
        {
            if (nums1.Length < 1 || nums1.Length > 50 || nums2.Length < 1 || nums2.Length > 50)
            {
                return false;
            }
            foreach (int num in nums1) {
                if (num < 1 || num > 50)
                {
                    return false;
                }
            }
            foreach (int num in nums2)
            {
                if (num < 1 || num > 50)
                {
                    return false;
                }
            }
            if (k < 1 || k > 50)
            {
                return false;
            }
            return true;
        }
        private int numberOfPairs(int[] nums1, int[] nums2, int k)
        {
            int count = 0;
            for (int i = 0; i < nums1.Length; i++)
            {
                for (int j = 0; j < nums2.Length; j++)
                {
                    if (nums1[i] % (nums2[j] * k) == 0)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
