using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1848
{
    /*
     1848. Минимальное расстояние до целевого элемента
    Дан целочисленный массив nums (с индексацией от 0) и два целых числа target и start. Найдите индекс i такой, что nums[i] == target и abs(i - start) минимальны. Обратите внимание, что abs(x) — это абсолютное значение x.
    Возврат abs(i - start).
    Гарантируется, что target существует в nums.
    https://leetcode.com/problems/minimum-distance-to-the-target-element/description/
     */
    public class Task1848 : InfoBasicTask
    {
        public Task1848(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5 };
            int target = 5;
            int start = 3;
            printArray(array, "Исходный массив: ");
            Console.WriteLine($"Целовое значение = {target}");
            Console.WriteLine($"Старт = {start}");
            int result = getMinDistance(array, target, start);
            Console.WriteLine($"Минимальное расстояние до целевого элемента ABS(i - start) = {result}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int getMinDistance(int[] nums, int target, int start)
        {
            int min = int.MaxValue;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == target)
                {
                    int absValue = Math.Abs(i - start);
                    if (absValue < min)
                    {
                        min = absValue;
                    }
                }
            }
            return min;
        }
    }
}
