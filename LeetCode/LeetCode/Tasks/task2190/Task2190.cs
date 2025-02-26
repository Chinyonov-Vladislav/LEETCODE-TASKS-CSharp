using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2190
{
    /*
     2190. Наиболее часто встречающееся число после ключа в массиве
    Вам дан нумерованный от 0 целочисленный массив nums. Вам также дано целое число key, которое присутствует в nums.
    Для каждого уникального целого числа target в numsподсчитайте количество раз, когда target непосредственно следует за key в nums. Другими словами, подсчитайте количество индексов i таких, что:
        0 <= i <= nums.length - 2,
        nums[i] == key и,
        nums[i + 1] == target.
    Верните значение target с максимальным количеством. Тестовые примеры будут сгенерированы таким образом, что target с максимальным количеством будет уникальным.
    https://leetcode.com/problems/most-frequent-number-following-key-in-an-array/description/
     */
    public class Task2190 : InfoBasicTask
    {
        public Task2190(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array = new int[] { 1, 100, 200, 1, 100 };
            printArray(array, "Исходный массив: ");
            int key = 1;
            Console.WriteLine($"Ключ = {key}");
            int result = mostFrequent(array, key);
            Console.WriteLine($"Наиболее часто следуемое число за ключом = {result}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int mostFrequent(int[] nums, int key)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i <= nums.Length - 2; i++)
            {
                if (nums[i] == key)
                {
                    int target = nums[i + 1];
                    if (dict.ContainsKey(target))
                    {
                        dict[target]++;
                    }
                    else
                    {
                        dict.Add(target, 1);
                    }
                }
            }
            return dict.OrderByDescending(x => x.Value).First().Key;
        }
    }
}
