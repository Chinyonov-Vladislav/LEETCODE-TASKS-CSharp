using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2248
{
    /*
     2248. Пересечение нескольких массивов
    Учитывая двумерный целочисленный массив nums где nums[i] является непустым массивом различных положительных целых чисел, верните список целых чисел, которые присутствуют в каждом массиве из nums отсортированных в порядке возрастания.
    https://leetcode.com/problems/intersection-of-multiple-arrays/description/
     */
    public class Task2248 : InfoBasicTask
    {
        public Task2248(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] array = new int[3][] {
                new int[] { 3, 1, 2, 4, 5 },
                new int[] { 1,2,3,4 },
                new int[] { 3,4,5,6 },
            };
            printTwoDimensionalArray(array, "Исходный массив массивов");
            IList<int> result = intersection(array);
            printIListInt(result, "Пересечение массивов: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private IList<int> intersection(int[][] nums)
        {
            IList<int> result = new List<int>();
            int[] freq = new int[1000];
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums[i].Length; j++)
                {
                    freq[nums[i][j] - 1]++;
                }
            }
            for (int i = 0; i < freq.Length; i++)
            {
                if (freq[i] == nums.Length)
                {
                    result.Add(i + 1);
                }
            }
            return result;
        }
    }
}
