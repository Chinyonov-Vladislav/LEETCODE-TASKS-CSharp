using LeetCode.Basic;
using System;

namespace LeetCode.Tasks.task561
{
    /*
     561. Раздел массива
    Дан целочисленный массив nums из 2n целых чисел.
    Сгруппируйте эти числа в n пары (a1, b1), (a2, b2), ..., (an, bn) так, чтобы сумма min(ai, bi) для всех i была максимальной.
    Верните максимальную сумму.
    https://leetcode.com/problems/array-partition/
     */
    public class Task561 : InfoBasicTask
    {
        public Task561(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 6, 2, 6, 5, 1, 2 };
            int maxSumPair = arrayPairSum(nums);
            printArray(nums, "Исходный массив: ");
            Console.WriteLine($"Максимальная сумма пар в массиве = {arrayPairSum(nums)}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int arrayPairSum(int[] nums)
        {
            int result = 0;
            Array.Sort(nums);
            for (int i = 1; i < nums.Length; i += 2)
            {
               result+=Math.Min(nums[i], nums[i-1]);
            }
            return result;
        }
        private int bestSolution(int[] nums)
        {
            int[] count = new int[20001];
            foreach (int num in nums)
            {
                count[num + 10000]++;
            }
            int sum = 0, isPair = 1;
            for (int i = 0; i < 20001; i++)
            {
                while (count[i] > 0)
                {
                    if (isPair % 2 == 1)
                    { sum += i - 10000; }
                    isPair++;
                    count[i]--;
                }
            }
            return sum;
        }
    }
}
