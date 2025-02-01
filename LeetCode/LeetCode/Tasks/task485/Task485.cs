using LeetCode.Basic;
using System;
using System.Collections.Generic;

namespace LeetCode.Tasks.task485
{
    /*
     485. Максимальное количество последовательных
    Учитывая двоичный массив nums, верните максимальное количество последовательных 1 в массиве.
    https://leetcode.com/problems/max-consecutive-ones/description/
     */
    public class Task485 : InfoBasicTask
    {
        public Task485(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array = new int[] { 1, 0, 1, 1, 0, 1 };
            Console.WriteLine($"Максимальное количество последовательных единиц в массиве = {findMaxConsecutiveOnes(array)}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int findMaxConsecutiveOnes(int[] nums)
        {
            int maxConsecutiveOnes = 0;
            List<int> values = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if ((nums[i] == 1 && i == 0)
                || (nums[i] == 1 && i == nums.Length - 1)
                || (nums[i] == 1 && i > 0 && nums[i - 1] == 0)
                || (nums[i] == 1 && i < nums.Length - 1 && nums[i + 1] == 0))
                {
                    values.Add(i);
                    if (values.Count == 2)
                    {
                        int consecutiveOnes = values[1] - values[0] + 1;
                        if (consecutiveOnes > maxConsecutiveOnes)
                        {
                            maxConsecutiveOnes = consecutiveOnes;
                        }
                        values.Clear();
                    }
                }
                if (nums[i] == 0 && values.Count == 1)
                {
                    if (maxConsecutiveOnes == 0)
                    {
                        maxConsecutiveOnes = 1;
                    }
                    values.Clear();
                }
            }
            if (values.Count == 1 && maxConsecutiveOnes == 0)
            {
                maxConsecutiveOnes = 1;
            }
            return maxConsecutiveOnes;
        }
        private int bestSolution(int[] nums)
        {
            int countOfOnes = 0;
            int maxCountOfOnes = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    countOfOnes++;
                    continue;
                }
                maxCountOfOnes = Math.Max(maxCountOfOnes, countOfOnes);
                countOfOnes = 0;
            }
            return Math.Max(maxCountOfOnes, countOfOnes);
        }
    }
}
