using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1984
{
    /*
     1984. Минимальная разница между максимальным и минимальным значениями K
    Вам дан нумерованный от 0 целочисленный массив nums, где nums[i] обозначает оценку ith ученика. Вам также дано целое число k.
    Выберите оценки любых k учеников из массива так, чтобы разница между самой высокой и самой низкой из k оценок была минимальной.
    Верните минимально возможную разницу.
    https://leetcode.com/problems/minimum-difference-between-highest-and-lowest-of-k-scores/description/
     */
    public class Task1984 : InfoBasicTask
    {
        public Task1984(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 9, 4, 1, 7 };
            int k = 2;
            printArray(nums, "Исходный массив: ");
            Console.WriteLine($"Значение переменной k = {k}");
            int minDiff = minimumDifference(nums, k);
            Console.WriteLine($"Минимальная разница между {k} оценок из массива = {minDiff}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int minimumDifference(int[] nums, int k)
        {
            if(nums.Length == 1)
            {
                return 0;
            }
            Array.Sort(nums);
            Array.Reverse(nums);
            int minDifference = Int32.MaxValue;
            for (int i = 0; i <= nums.Length - k; i++)
            {
                int localMinDifference = nums[i] - nums[i+k-1];
                if (localMinDifference < minDifference)
                {
                    minDifference = localMinDifference;
                }
            }
            return minDifference;
        }
    }
}
