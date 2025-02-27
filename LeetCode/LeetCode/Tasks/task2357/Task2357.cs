using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2357
{
    /*
     2357. Обнулить массив, вычтя равные суммы
    Вам дан неотрицательный целочисленный массив nums. За одну операцию вы должны:
        Выберите положительное целое число x такое, что x меньше или равно наименьшему ненулевому элементу в nums.
        Вычтите x из каждого положительного элемента в nums.
    Верните минимальное количество операций, чтобы сделать каждый элемент в nums равным 0.
    Ограничения:
        1 <= nums.length <= 100
        0 <= nums[i] <= 100
    https://leetcode.com/problems/make-array-zero-by-subtracting-equal-amounts/description/
     */
    public class Task2357 : InfoBasicTask
    {
        public Task2357(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array = new int[] { 1, 5, 0, 3, 5 };
            printArray(array);
            int count = minimumOperations(array);
            Console.WriteLine($"Минимальное количество операций для зануления массива = {count}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int minimumOperations(int[] nums)
        {
            int count = 0;
            while (true)
            {
                Array.Sort(nums);
                bool isAllZeros = true;
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] != 0)
                    {
                        int selectedValue = nums[i];
                        count++;
                        for (int j = 0; j < nums.Length; j++)
                        {
                            if (nums[j] != 0)
                            {
                                nums[j] -= selectedValue;
                                if (nums[j] != 0)
                                {
                                    isAllZeros = false;
                                }
                            }
                        }
                        break;
                    }
                }
                if (isAllZeros)
                {
                    break;
                }
            }
            return count;
        }
        // скопировано с leetcode
        private int bestSolution(int[] nums)
        {
            var d = new List<int>();
            foreach (int n in nums)
            {
                if (!d.Contains(n) && n > 0)
                {
                    d.Add(n);
                }
            }
            return d.Count;
        }
    }
}
