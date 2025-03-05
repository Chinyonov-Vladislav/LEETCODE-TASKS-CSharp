using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2908
{
    /*
     2908. Минимальная сумма горных троек I
    Вам предоставляется 0-индексированный массив nums целых чисел.
    Тройка индексов (i, j, k) является горой, если:
        i < j < k
        nums[i] < nums[j] и nums[k] < nums[j]
    Верните минимально возможную сумму горной тройки nums. Если такой тройки не существует, верните -1.
    Ограничения:
        3 <= nums.length <= 50
        1 <= nums[i] <= 50
    https://leetcode.com/problems/minimum-sum-of-mountain-triplets-i/description/
     */
    public class Task2908 : InfoBasicTask
    {
        public Task2908(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 8, 6, 1, 5, 3 };
            printArray(nums);
            if (isValid(nums))
            {
                int min = minimumSum(nums);
                Console.WriteLine(min == -1 ? "Нет минимальной суммы трех значений, подходящих под условие: (i < j < k) и (nums[i] < nums[j] and nums[k] < nums[j])" : $"Минимальная сумма трех значений, подходящих под условие: (i < j < k) и (nums[i] < nums[j] and nums[k] < nums[j]) = {min}");
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
            if (nums.Length < 3 || nums.Length > 50)
            {
                return false;
            }
            foreach (int num in nums)
            {
                if (num < 1 || num > 50)
                {
                    return false;
                }
            }
            return true;
        }
        private int minimumSum(int[] nums)
        {
            List<int> ints = new List<int>();
            for (int i = 0; i < nums.Length - 2; i++)
            {
                int valueI = nums[i];
                for (int j = i+1; j < nums.Length - 1; j++)
                {
                    int valueJ = nums[j];
                    for (int k = j + 1; k < nums.Length; k++)
                    {
                        int valueK = nums[k];
                        if (valueJ > valueI && valueJ > valueK)
                        {
                            int sum = valueI + valueJ + valueK;
                            if (ints.Count == 0)
                            {
                                ints.Add(sum);
                            }
                            else
                            {
                                if (sum < ints[0])
                                {
                                    ints.Clear();
                                    ints.Add(sum);
                                }
                            }
                        }
                    }
                }
            }
            if (ints.Count == 0)
            {
                return -1;
            }
            return ints[0];
        }
    }
}
