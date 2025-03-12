using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3427
{
    /*
     3427. Сумма подмассивов переменной длины
    Вам дан целочисленный массив nums размером n. Для каждого индекса i где 0 <= i < n определите подмассив nums[start ... i] где start = max(0, i - nums[i]).
    Верните общую сумму всех элементов подмассива, определённого для каждого индекса в массиве.
    Ограничения:
        1 <= n == nums.length <= 100
        1 <= nums[i] <= 1000
    https://leetcode.com/problems/sum-of-variable-length-subarrays/description/
     */
    public class Task3427 : InfoBasicTask
    {
        public Task3427(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] sum = new int[] { 3, 1, 1, 2 };
            printArray(sum);
            if (isValid(sum))
            {
                int res = subarraySum(sum);
                Console.WriteLine($"Результат = {res}");
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
        private bool isValid(int[] sum)
        {
            if (sum.Length < 1 || sum.Length > 100)
            {
                return false;
            }
            foreach (int item in sum) {
                if (item < 1 || item > 1000)
                {
                    return false;
                }
            }
            return true;
        }
        private int subarraySum(int[] nums)
        {
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int start = Math.Max(0, i - nums[i]);
                for (int j = start; j <= i; j++)
                {
                    sum += nums[j];
                }
            }
            return sum;
        }
    }
}
