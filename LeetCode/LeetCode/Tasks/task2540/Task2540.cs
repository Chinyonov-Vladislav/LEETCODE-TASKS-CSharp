using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2540
{
    /*
     2540. Минимальное общее значение
    Учитывая два массива целых чисел nums1 и nums2, отсортированные в порядке неубывания, возвращают минимальное целое число, общее для обоих массивов. Если среди nums1 и nums2 нет общего целого числа, верните -1.
    Обратите внимание, что целое число называется общим для nums1 и nums2, если в обоих массивах есть хотя бы одно вхождение этого целого числа.
    Ограничения:
        1 <= nums1.length, nums2.length <= 105
        1 <= nums1[i], nums2[j] <= 109
        И nums1 и nums2 отсортированы в неубывающем порядке.
    https://leetcode.com/problems/minimum-common-value/description/
     */
    public class Task2540 : InfoBasicTask
    {
        public Task2540(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums1 = new int[] { 1, 2, 3, 6 };
            int[] nums2 = new int[] { 2, 3, 4, 5 };
            printArray(nums1, "Массив №1: ");
            printArray(nums2, "Массив №2: ");
            if (isValid(nums1, nums2))
            {
                int min = getCommon(nums1, nums2);
                Console.WriteLine(min == -1 ? "Общее наименьшее число между двумя массивами отсутствует" : $"Общее наименьшее число между двумя массивами = {min}");
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
            int upperLimit = (int)Math.Pow(10, 5);
            if (nums1.Length < 1 || nums2.Length > upperLimit)
            {
                return false;
            }
            if (nums2.Length < 1 || nums2.Length > upperLimit)
            {
                return false;
            }
            upperLimit = (int)Math.Pow(10, 9);
            foreach (int num in nums1)
            {
                if (num < 1 || num > upperLimit)
                {
                    return false;
                }
            }
            foreach (int num in nums2)
            {
                if (num < 1 || num > upperLimit)
                {
                    return false;
                }
            }
            for (int i = 1; i < nums1.Length; i++)
            {
                if (nums1[i - 1] > nums1[i])
                {
                    return false;
                }
            }
            for (int i = 1; i < nums2.Length; i++)
            {
                if (nums2[i - 1] > nums2[i])
                {
                    return false;
                }
            }
            return true;
        }
        private int getCommon(int[] nums1, int[] nums2)
        {
            int min = -1;
            HashSet<int> set = new HashSet<int>(nums1);
            for (int i = 0; i < nums2.Length; i++)
            {
                if (set.Contains(nums2[i]))
                {
                    min = nums2[i];
                    break;
                }
            }
            return min;
        }
        // скопировано с leetcode
        private int bestSolution(int[] nums1, int[] nums2)
        {
            int n1 = nums1.Length;
            int n2 = nums2.Length;
            int i1 = 0;
            int i2 = 0;
            while (i1 < n1 && i2 < n2)
            {
                if (nums1[i1] == nums2[i2])
                {
                    return nums2[i2];
                }
                else if (nums1[i1] > nums2[i2])
                {
                    i2++;
                }
                else if (nums1[i1] < nums2[i2])
                {
                    i1++;
                };
            }
            return -1;
        }
    }
}
