using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1413
{
    /*
     1413. Минимальное значение для получения положительной суммы
    Учитывая массив целых чисел nums, вы начинаете с начального положительного значения startValue.
    На каждой итерации вы вычисляете пошаговую сумму начального значения плюс элементы в nums (слева направо).
    Верните минимальное положительное значение начального значения, при котором сумма шагов не будет меньше 1.
    https://leetcode.com/problems/minimum-value-to-get-positive-step-by-step-sum/description/
     */
    public class Task1413 : InfoBasicTask
    {
        public Task1413(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { -3, 6, 2, 5, 8, 6 };
            printArray(nums, "Исходный массив: ");
            int min = minStartValue(nums);
            Console.WriteLine($"Минимальное положительное значение начального значения, при котором сумма шагов не будет меньше 1 = {min}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int minStartValue(int[] nums)
        {
            List<int> prefixSum = new List<int> ();
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0)
                {
                    prefixSum.Add(nums[i]);
                }
                else
                {
                    prefixSum.Add(nums[i] + prefixSum[prefixSum.Count - 1]);
                }
            }
            int minPrefixSum = prefixSum.Min();
            if (minPrefixSum >= 0)
            {
                return 1;
            }
            else
            {
                return minPrefixSum * (-1) + 1;
            }
        }
        //скопировано с leetcode
        private int bestSolution(int[] nums)
        {
            var lowestNumer = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                nums[i] += nums[i - 1];
                if (nums[i] < lowestNumer)
                {
                    lowestNumer = nums[i];
                }
            }
            var lowestAmountNeeded = lowestNumer * -1 + 1;
            return Math.Max(1, lowestAmountNeeded);
        }
    }
}
