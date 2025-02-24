using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2016
{
    /*
     2016. Максимальная разница между увеличивающимися элементами
    Учитывая нумерованный с 0 целочисленный массив nums размером n, найдите максимальную разницу между nums[i] и nums[j] (т. е. nums[j] - nums[i]), такую что 0 <= i < j < n и nums[i] < nums[j].
    Верните максимальную разницу. Если такого i и j не существует, верните -1.
    https://leetcode.com/problems/maximum-difference-between-increasing-elements/description/
     */
    public class Task2016 : InfoBasicTask
    {
        public Task2016(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array = new int[] { 1, 5, 2, 10 };
            printArray(array, "Исходный массив: ");
            int maxDiff = maximumDifference(array);
            Console.WriteLine(maxDiff == -1 ? "Не существует i и j таких, чтобы i < j и nums[i] < nums[j]" : $"Максимальная разница = {maxDiff}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int maximumDifference(int[] nums)
        {
            int maxDifference = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] > nums[i])
                    {
                        int difference = nums[j] - nums[i];
                        if (difference > maxDifference)
                        {
                            maxDifference = difference;
                        }
                    }
                }
            }
            return maxDifference;
        }
        // скопировано с leetcode
        private int bestSolution(int[] nums)
        {
            int min = nums[0];
            int res = -1;
            for (int i = 1; i < nums.Length; i++)
            {
                min = Math.Min(min, nums[i]);
                res = Math.Max(nums[i] - min, res);
            }
            return res == 0 ? -1 : res;
        }
    }
}
