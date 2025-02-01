using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Tasks.task414
{
    /*
     414. Третье максимальное Число
    Учитывая целочисленный массив nums, верните третьеотличное от остальных максимальноечисло в этом массиве. Если третьего максимального числа не существует, верните максимальное число.
     */
    public class Task414 : InfoBasicTask
    {
        public Task414(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 2, 2, 3, 1 };
            printArray(nums, "Исходный массив: ");
            Console.WriteLine($"Третий максимум в массиве = {thirdMax(nums)}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        public int thirdMax(int[] nums)
        {
            List<int> result = new HashSet<int>(nums).ToList();
            result.Sort();
            return result.Count < 3 ? result[result.Count - 1] : result[result.Count - 3];
        }
    }
}
