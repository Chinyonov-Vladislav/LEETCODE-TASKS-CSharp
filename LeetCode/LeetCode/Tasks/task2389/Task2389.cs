using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2389
{
    /*
     2389. Самая длинная подпоследовательность с ограниченной суммой
    Вам дан целочисленный массив nums длиной n и целочисленный массив queries длиной m.
    Верните массив answer длины m где answer[i] является максимальным размером подпоследовательности, которую вы можете взять из nums так, чтобы сумма его элементов была меньше или равна queries[i].
    Подпоследовательность — это массив, который можно получить из другого массива, удалив некоторые или все элементы без изменения порядка оставшихся элементов.
    Ограничения:
        n == nums.length
        m == queries.length
        1 <= n, m <= 1000
        1 <= nums[i], queries[i] <= 10^6
    https://leetcode.com/problems/longest-subsequence-with-limited-sum/description/
     */
    public class Task2389 : InfoBasicTask
    {
        public Task2389(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 4, 5, 2, 1 };
            int[] queries = new int[] { 3, 10, 21 };
            printArray(nums, "Массив чисел: ");
            printArray(queries, "Массив запросов: ");
            if (isValid(nums, queries))
            {
                int[] result = answerQueries(nums, queries);
                printArray(result, "Результат: ");
            }
            else
            {
                Console.WriteLine("Не валидные исходные данные!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(int[] nums, int[] queries)
        {
            int n = nums.Length;
            int m = queries.Length;
            if (n < 1 || n > 1000)
            {
                return false;
            }
            if (m < 1 || m > 1000)
            {
                return false;
            }
            int upperLimit = (int)Math.Pow(10, 6);
            foreach (int item in nums) {
                if (item < 1 || item > upperLimit)
                {
                    return false;
                }
            }
            foreach (int item in queries)
            {
                if (item < 1 || item > upperLimit)
                {
                    return false;
                }
            }
            return true;
        }
        private int[] answerQueries(int[] nums, int[] queries)
        {
            int[] result = new int[queries.Length];
            Array.Sort(nums);
            int totalSum = nums.Sum();
            for (int i = 0; i < queries.Length; i++)
            {
                if (totalSum <= queries[i])
                {
                    result[i] = nums.Length;
                }
                else
                {
                    int localSum = 0;
                    for (int j = 0; j < nums.Length; j++)
                    {
                        localSum += nums[j];
                        if (localSum > queries[i])
                        {
                            result[i] = j;
                            break;
                        }
                    }
                }
            }
            return result;
        }
    }
}
