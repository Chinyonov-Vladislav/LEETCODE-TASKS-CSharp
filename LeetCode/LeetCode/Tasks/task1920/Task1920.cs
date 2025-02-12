using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1920
{
    /*
     1920. Построение массива из перестановки
    Учитывая нумерацию с нуля nums (нумерацию с индексацией 0), создайте массив ans той же длины, где ans[i] = nums[nums[i]] для каждого 0 <= i < nums.length и верните его.
    Перестановка с нулевого элемента nums — это массив различных целых чисел от 0 до nums.length - 1 (включительно).
    https://leetcode.com/problems/build-array-from-permutation/description/
     */
    public class Task1920 : InfoBasicTask
    {
        public Task1920(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array = new int[] { 0, 2, 1, 5, 3, 4 };
            printArray(array, "Исходный массив: ");
            int[] result = buildArray(array);
            printArray(result, "Результирующий массив: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int[] buildArray(int[] nums)
        {
            int[] result = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                result[i] = nums[nums[i]];
            }
            return result;
        }
    }
}
