using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3318
{
    /*
     3318. Найдите X-сумму всех подмассивов длиной K
    Вам дан массив nums целых чисел n и два целых числа k и x.
    X-сумма массива вычисляется следующим образом:
        Подсчитайте вхождения всех элементов в массив.
        Сохраняйте только вхождения наиболее часто встречающихся x элементов. Если у двух элементов одинаковое количество вхождений, более часто встречающимся считается элемент с большим значением.
        Вычислите сумму результирующего массива.
    Обратите внимание, что если в массиве меньше x различных элементов, то его x-сумма равна сумме элементов массива.
    Верните целочисленный массив answer длиной n - k + 1, где answer[i] — x-суммаподмассива nums[i..i + k - 1].
    https://leetcode.com/problems/find-x-sum-of-all-k-long-subarrays-i/description/
     */
    public class Task3318 : InfoBasicTask
    {
        public Task3318(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 1, 2, 2, 3, 4, 2, 3 };
            int k = 6;
            int x = 2;
            printArray(nums);
            Console.WriteLine($"Значение переменной k = {k}\nЗначение переменной x = {2}");
            if (isValid(nums,k,x))
            {
                int[] res = findXSum(nums, k, x);
                printArray(res, "Результирующий массив: ");
            }
            else
            {
                printInfoNotValidData();
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(int[] nums, int k, int x)
        {
            if (nums.Length < 1 || nums.Length > 50)
            {
                return false;
            }
            foreach (int num in nums)
            {
                if (num < 1 || num > 50)
                {
                    return false;
                }
            }
            if (!(1 <= x && x <= k && x <= nums.Length))
            {
                return false;
            }
            return true;
        }
        private int[] findXSum(int[] nums, int k, int x)
        {
            int[] answer = new int[nums.Length - k + 1];
            for (int i = 0; i < answer.Length; i++)
            {
                Dictionary<int, int> freq = new Dictionary<int, int>();
                int totalSum = 0;
                HashSet<int> set = new HashSet<int>();
                for (int j = i; j <= i + k - 1; j++)
                {
                    totalSum += nums[j];
                    set.Add(nums[j]);
                    if (freq.ContainsKey(nums[j]))
                    {
                        freq[nums[j]]++;
                    }
                    else
                    {
                        freq.Add(nums[j], 1);
                    }
                }
                if (set.Count >= x)
                {
                    totalSum = 0;
                    Dictionary<int, int> orderedFreq = freq.OrderByDescending(item => item.Value).ThenByDescending(item => item.Key).ToDictionary(item => item.Key, item => item.Value);
                    int count = 0;
                    foreach (var pair in orderedFreq)
                    {
                        Console.WriteLine($"KEY = {pair.Key} | VALUE = {pair.Value}");
                        totalSum += pair.Key * pair.Value;
                        count++;
                        if (count == x)
                        {
                            break;
                        }
                    }
                }
                answer[i] = totalSum;
            }
            return answer;
        }
    }
}
