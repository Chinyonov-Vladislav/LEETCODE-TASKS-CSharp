using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3471
{
    /*
     3471. Найдите самое большое почти отсутствующее целое число
    Вам будет предоставлен целочисленный массив nums и целое число k.
    Целое число x почти отсутствует в nums если x встречается ровно в одном подмассиве размера k в nums.
    Верните наибольшее почти отсутствующее целое число из nums. Если такого целого числа не существует, верните -1.
    Подмассив — это непрерывная последовательность элементов внутри массива.
    Ограничения:
        1 <= nums.length <= 50
        0 <= nums[i] <= 50
        1 <= k <= nums.length
    https://leetcode.com/problems/find-the-largest-almost-missing-integer/description/
     */
    public class Task3471 : InfoBasicTask
    {
        public Task3471(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 3, 9, 2, 1, 7 };
            int k = 3;
            printArray(nums);
            Console.WriteLine($"Длина подмассива = {k}");
            if (isValid(nums, k))
            {
                int maxItem = largestInteger(nums, k);
                Console.WriteLine($"Самое большое число, которое встречается в подмассиве длиной {k} = {maxItem}");
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
        private bool isValid(int[] nums, int k)
        {
            if (nums.Length < 1 || nums.Length > 50)
            {
                return false;
            }
            foreach (int num in nums) {
                if (num < 0 || num > 50)
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
        private int largestInteger(int[] nums, int k)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i <= nums.Length - k; i++)
            {
                HashSet<int> set = new HashSet<int>();
                for (int j = i; j < i + k; j++)
                {
                    set.Add(nums[j]);
                }
                foreach (int item in set)
                {
                    if (dict.ContainsKey(item))
                    {
                        dict[item]++;
                    }
                    else
                    {
                        dict.Add(item, 1);
                    }
                }
            }
            Dictionary<int, int> filteredDict = dict.Where(x => x.Value == 1).ToDictionary(i => i.Key, i => i.Value);
            if (filteredDict.Count == 0)
            {
                return -1;
            }
            return filteredDict.Keys.Max();
        }
    }
}
