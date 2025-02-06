using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1480
{
    /*
     1480. Текущая сумма 1d массива
    Учитывая массив nums. Мы определяем промежуточную сумму массива как runningSum[i] = sum(nums[0]…nums[i]).
    Верните текущую сумму nums.
    https://leetcode.com/problems/running-sum-of-1d-array/description/
     */
    public class Task1480 : InfoBasicTask
    {
        public Task1480(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 3, 1, 2, 10, 1 };
            printArray(nums, "Исходный массив: ");
            int[] result = runningSum(nums);
            printArray(result, "Результирующий массив: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int[] runningSum(int[] nums)
        {
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                nums[i] = sum;
            }
            return nums;
        }
    }
}
