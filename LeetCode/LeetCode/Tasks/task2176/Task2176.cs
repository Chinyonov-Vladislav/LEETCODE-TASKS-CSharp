using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2176
{
    /*
     2176. Подсчитайте количество равных и делимых пар в массиве
    Дан 0-индексированный целочисленный массив nums, длина которого равна n и целое k.
    Верните количество пар (i,j) таких, что 0 <= i < j < n, nums[i] == nums[j] и (i * j) делится на k
    https://leetcode.com/problems/count-equal-and-divisible-pairs-in-an-array/description/
     */
    public class Task2176 : InfoBasicTask
    {
        public Task2176(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array = new int[] { 3, 1, 2, 2, 2, 1, 3 };
            int k = 2;
            printArray(array, "Исходный массив: ");
            Console.WriteLine($"Значение переменной k = {k}");
            int result = countPairs(array, k);
            Console.WriteLine($"Количество пар = {result}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int countPairs(int[] nums, int k)
        {
            int countPairs = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] == nums[j] && i * j % k == 0)
                    {
                        countPairs++;
                    }
                }
            }
            return countPairs;
        }
    }
}
