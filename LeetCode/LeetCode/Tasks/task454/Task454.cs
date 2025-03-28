using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task454
{
    /*
     454. 4Сум II
    Учитывая четыре массива целых чисел nums1, nums2, nums3 и nums4 все длины n, верните количество кортежей (i, j, k, l) такое, что:
        0 <= i, j, k, l < n
        nums1[i] + nums2[j] + nums3[k] + nums4[l] == 0
    Ограничения:
        n == nums1.length
        n == nums2.length
        n == nums3.length
        n == nums4.length
        1 <= n <= 200
        -2^28 <= nums1[i], nums2[i], nums3[i], nums4[i] <= 2^28
    https://leetcode.com/problems/4sum-ii/description/
     */
    public class Task454 : InfoBasicTask
    {
        public Task454(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums1 = new int[] { 1, 2 };
            int[] nums2 = new int[] { -2, -1 };
            int[] nums3 = new int[] { -1, 2 };
            int[] nums4 = new int[] { 0, 2 };
            printArray(nums1, "Массив №1: ");
            printArray(nums2, "Массив №2: ");
            printArray(nums3, "Массив №3: ");
            printArray(nums4, "Массив №4: ");
            if (isValid(nums1, nums2, nums3, nums4))
            {
                int res = fourSumCount(nums1, nums2, nums3, nums4);
                Console.WriteLine($"Количество кортежей индексов из 4 (по одному из каждого массива), таких что сумма элементов по индексам равна 0 = {res}");
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
        private bool isValid(int[] nums1, int[] nums2, int[] nums3, int[] nums4)
        {
            int length = nums1.Length;
            if (nums2.Length != length || nums3.Length != length || nums4.Length != length)
            {
                return false;
            }
            if (length < 1 || length > 200)
            {
                return false;
            }
            int lowLimit = -1 * (int)Math.Pow(2, 28);
            int highLimit = (int)Math.Pow(2, 28);
            List<int[]> nums = new List<int[]>() { nums1, nums2, nums3, nums4 };
            foreach (int[] numArr in nums)
            {
                foreach (int item in numArr)
                {
                    if (item < lowLimit || item > highLimit)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private int fourSumCount(int[] nums1, int[] nums2, int[] nums3, int[] nums4)
        {
            Array.Sort(nums1);
            Array.Sort(nums2);
            Array.Sort(nums3);
            Array.Sort(nums4);
            Dictionary<int, int> dict1 = new Dictionary<int, int>();
            Dictionary<int, int> dict2 = new Dictionary<int, int>();
            for (int i = 0; i < nums1.Length; i++)
            {
                for (int j = 0; j < nums1.Length; j++)
                {
                    int firstSum = nums1[i]+nums2[j];
                    int secondSum = nums3[i]+nums4[j];
                    if (dict1.ContainsKey(firstSum))
                    {
                        dict1[firstSum]++;
                    }
                    else
                    {
                        dict1.Add(firstSum, 1);
                    }
                    if (dict2.ContainsKey(secondSum))
                    {
                        dict2[secondSum]++;
                    }
                    else
                    {
                        dict2.Add(secondSum, 1);
                    }
                }
            }
            int count = 0;
            foreach (var pair in dict1)
            {
                int secondKey = pair.Key * -1;
                if (dict2.ContainsKey(secondKey))
                {
                    count += pair.Value * dict2[secondKey];
                }
            }
            return count;
        }
    }
}
