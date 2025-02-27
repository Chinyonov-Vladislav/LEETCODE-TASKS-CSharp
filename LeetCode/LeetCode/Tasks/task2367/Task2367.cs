using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2367
{
    /*
     2367. Количество арифметических троек
    Вам дан нумерованный с 0 строго возрастающий целочисленный массив nums и положительное целое число diff. 
    Тройка (i, j, k) является арифметической тройкой, если выполняются следующие условия:
        i < j < k,
        nums[j] - nums[i] == diff, и
        nums[k] - nums[j] == diff.
    Возвращает количество уникальных арифметических троек.
    https://leetcode.com/problems/number-of-arithmetic-triplets/description/
     */
    public class Task2367 : InfoBasicTask
    {
        public Task2367(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 0, 1, 4, 6, 7, 10 };
            printArray(nums);
            int diff = 3;
            Console.WriteLine($"Значение разницы = {diff}");
            int count = arithmeticTriplets(nums, diff);
            Console.WriteLine($"Количество уникальных арифметических троек = {count}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int arithmeticTriplets(int[] nums, int diff)
        {
            int count = 0;
            for (int i = 0; i < nums.Length - 2; i++)
            {
                for (int j = i+1; j < nums.Length - 1; j++)
                {
                    for (int k = j + 1; k < nums.Length; k++)
                    {
                        if (nums[j] - nums[i] == diff && nums[k] - nums[j] == diff)
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }
        // скопировано с leetcode
        private int bestSolution(int[] nums, int diff)
        {

            int count = 0;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if (nums[i] - nums[j] == diff)
                    {
                        for (int k = j - 1; k >= 0; k--)
                        {
                            if (nums[j] - nums[k] == diff)
                            {
                                count++;
                            }
                        }
                    }
                }
            }

            return count;
        }
    }
}
