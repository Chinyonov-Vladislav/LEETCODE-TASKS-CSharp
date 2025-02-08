using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1646
{
    /*
     1646. Получить максимум в сгенерированном массиве
    Вам будет задано целое число n. Целочисленный массив длины nums, проиндексированный с 0, длиной n+1 генерируется следующим образом:
        nums[0] = 0
        nums[1] = 1
        nums[2 * i] = nums[i] когда 2 <= 2 * i <= n
        nums[2 * i + 1] = nums[i] + nums[i + 1] когда 2 <= 2 * i + 1 <= n
    Верните максимальное значение в сгенерированном массиве
    https://leetcode.com/problems/get-maximum-in-generated-array/description/
     */
    public class Task1646 : InfoBasicTask
    {
        public Task1646(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int n = 7;
            Console.WriteLine($"Значение числа n = {n}");
            int max = getMaximumGenerated(n);
            Console.WriteLine($"Максимальное значение в сгенерированном массиве = {max}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int getMaximumGenerated(int n)
        {
            int max = Int32.MinValue;
            int[] array = new int[n+1];
            for (int i = 0; i < array.Length; i++)
            {
                if (i == 0 || i == 1)
                {
                    array[i] = i;
                }
                if (2 <= 2 * i && 2 * i <= n)
                {
                    array[2 * i] = array[i];
                }
                if (2 <= 2 * i + 1 && 2 * i + 1 <= n)
                {
                    array[2 * i + 1] = array[i] + array[i + 1];
                }
            }
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            return max;
        }
    }
}
