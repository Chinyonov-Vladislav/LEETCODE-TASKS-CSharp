using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2057
{
    /*
     2057. Наименьший индекс с равным значением
    Учитывая целочисленный массив с индексом nums0, верните наименьший индекс i из nums таких, что i mod 10 == nums[i], или -1 если такой индекс не существует.
    x mod y обозначает остаток, когда x делится на y.
    https://leetcode.com/problems/smallest-index-with-equal-value/description/
     */
    public class Task2057 : InfoBasicTask
    {
        public Task2057(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array = new int[] { 4, 3, 2, 1 };
            printArray(array, "Исходный массив: ");
            int index = smallestEqual(array);
            Console.WriteLine(index == -1 ? "Ни один индекс не удовлетворяет условию i mod 10 == nums[i]" : $"Индекс, удовлетворяющий условию i mod 10 == nums[i], равен {index}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int smallestEqual(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (i % 10 == nums[i])
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
