using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2956
{
    /*
     2956. Найдите общие элементы между двумя массивами
    Вам даны два целочисленных массива nums1 и nums2 размером n и m соответственно. Вычислите следующие значения:
        answer1 : количество индексов, i таких, nums1[i] которые nums2 существуют в nums2.
        answer2 : количество индексов, i таких, nums2[i] которые nums1 существуют в nums1.
    Возврат[answer1,answer2].
    Ограничения:
        n == nums1.length
        m == nums2.length
        1 <= n, m <= 100
        1 <= nums1[i], nums2[i] <= 100
    https://leetcode.com/problems/find-common-elements-between-two-arrays/description/
     */
    public class Task2956 : InfoBasicTask
    {
        public Task2956(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums1 = new int[] { 2, 3, 2 };
            int[] nums2 = new int[] { 1, 2 };
            printArray(nums1, "Массив чисел №1: ");
            printArray(nums2, "Массив чисел №2: ");
            if (isValid(nums1, nums2))
            {
                int[] res = findIntersectionValues(nums1, nums2);
                Console.WriteLine(res[0] == 0 && res[1] == 0 ? "Между двумя массивами нет общих чисел" : $"Количество общих чисел между 1 и 2 массивом = {res[0]}\nКоличество общих чисел между 2 и 1 массивом = {res[1]}");
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
            int n = nums1.Length;
            int m = nums2.Length;
            if (n < 1 || n > 100 || m < 1 || m > 100)
            {
                return false;
            }
            foreach (int num in nums1) {
                if (num < 1 || num > 100)
                {
                    return false;
                }
            }
            foreach (int num in nums2)
            {
                if (num < 1 || num > 100)
                {
                    return false;
                }
            }
            return true;
        }
        private int[] findIntersectionValues(int[] nums1, int[] nums2)
        {
            int[] result = new int[] { 0, 0 };
            foreach (int num1 in nums1)
            {
                foreach (int num2 in nums2) {
                    if (num1 == num2)
                    {
                        result[0]++;
                        break;
                    }
                }
            }
            foreach (int num2 in nums2)
            {
                foreach (int num1 in nums1)
                {
                    if (num1 == num2)
                    {
                        result[1]++;
                        break;
                    }
                }
            }
            return result;
        }
    }
}
