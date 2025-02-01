using LeetCode.Basic;
using System;
using System.Collections.Generic;

namespace LeetCode.Tasks.task350
{
    /*
     350. Пересечение двух массивов II
    Даны два целочисленных массива nums1 и nums2. Верните массив их пересечений. Каждый элемент в результате должен встречаться столько раз, сколько он встречается в обоих массивах, и вы можете возвращать результат в любом порядке.
     */
    public class Task350 : InfoBasicTask
    {
        public Task350(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums1 = new int[] { 43, 85, 49, 2, 83, 2, 39, 99, 15, 70, 39, 27, 71, 3, 88, 5, 19, 5, 68, 34, 7, 41, 84, 2, 13, 85, 12, 54, 7, 9, 13, 19, 92 };
            int[] nums2 = new int[] { 10, 8, 53, 63, 58, 83, 26, 10, 58, 3, 61, 56, 55, 38, 81, 29, 69, 55, 86, 23, 91, 44, 9, 98, 41, 48, 41, 16, 42, 72, 6, 4, 2, 81, 42, 84, 4, 13 };
            int[] result = intersect(nums1, nums2);
            printArray(result, "Результат: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int[] intersect(int[] nums1, int[] nums2)
        {
            Dictionary<int, int> dictNums1 = new Dictionary<int, int>();
            Dictionary<int, int> dictNums2 = new Dictionary<int, int>();
            foreach (int num in nums1) {
                if (dictNums1.ContainsKey(num))
                {
                    dictNums1[num]++;
                }
                else
                {
                    dictNums1[num]=1;
                }
            }
            foreach (int num in nums2)
            {
                if (dictNums2.ContainsKey(num))
                {
                    dictNums2[num]++;
                }
                else
                {
                    dictNums2[num] = 1;
                }
            }
            int totalCount = 0;
            Dictionary<int, int> common = new Dictionary<int, int>();
            foreach (var pair1 in dictNums1)
            {
                if (dictNums2.ContainsKey(pair1.Key))
                {
                    if (pair1.Key == 2)
                    {
                        Console.WriteLine($"Количество в первом массиве = {dictNums1[pair1.Key]} | Количество во втором массиве = {dictNums2[pair1.Key]}");
                    }
                    int count = pair1.Value > dictNums2[pair1.Key] ? dictNums2[pair1.Key] : pair1.Value;
                    common.Add(pair1.Key, count);
                    totalCount += count;
                }
            }
            int index = 0;
            int[] result = new int[totalCount];
            foreach (var pair in common)
            {
                for (int i = 0; i < pair.Value; i++)
                {
                    result[index] = pair.Key;
                    index++;
                }
            }
            return result;
        }
        private int[] bestSolution(int[] nums1, int[] nums2)
        {
            int[] freq = new int[1001];
            foreach (int n in nums1)
            {
                freq[n]++;
            }
            List<int> result = new List<int>();

            foreach (int num in nums2)
            {
                if (freq[num] >= 1)
                {
                    freq[num]--;
                    result.Add(num);

                }
            }

            return result.ToArray();
        }
    }
}
