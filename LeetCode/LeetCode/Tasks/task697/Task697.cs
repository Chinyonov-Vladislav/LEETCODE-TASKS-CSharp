using LeetCode.Basic;
using System;
using System.Collections.Generic;

namespace LeetCode.Tasks.task697
{
    /*
     697. Степень массива
    Если задан непустой массив неотрицательных целых чисел nums, то степень этого массива определяется как максимальная частота появления любого из его элементов.
    Ваша задача — найти наименьшую возможную длину (непрерывного) подмассива nums с той же степенью, что и nums.
     https://leetcode.com/problems/degree-of-an-array/description/
     */
    public class Task697 : InfoBasicTask
    {
        public Task697(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 2, 2, 3, 1 };
            int[] nums1 = new int[] { 1, 2, 2, 3, 1, 4, 2 };
            int minLength = findShortestSubArray(nums);
            Console.WriteLine($"Наименьшая возможная длина непрерывного подмассива с такой же степенью, как и исходный массив = {minLength}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int findShortestSubArray(int[] nums)
        {
            int degreeArray = Int32.MinValue;
            Dictionary<int, int[]> frequencies = new Dictionary<int, int[]>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (frequencies.ContainsKey(nums[i]))
                {
                    frequencies[nums[i]][0]++;
                    frequencies[nums[i]][2] = i;
                }
                else
                {
                    frequencies.Add(nums[i], new int[] { 1, i, i });
                }
                if (frequencies[nums[i]][0] > degreeArray)
                {
                    degreeArray = frequencies[nums[i]][0];
                }
            }
            int minLengthSubArrayWithSameDegree = Int32.MaxValue;
            foreach (var item in frequencies)
            {
                if (item.Value[0] == degreeArray)
                {
                    int lengthSubArray = item.Value[2] - item.Value[1] + 1;
                    if (lengthSubArray < minLengthSubArrayWithSameDegree)
                    {
                        minLengthSubArrayWithSameDegree = lengthSubArray;
                    }
                }
            }
            return minLengthSubArrayWithSameDegree;
        }
    }
}
