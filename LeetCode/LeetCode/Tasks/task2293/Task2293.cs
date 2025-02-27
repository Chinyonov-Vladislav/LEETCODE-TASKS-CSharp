using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2293
{
    /*
     2293. Минимальная максимальная игра
    Вам дан нумерованный от 0 целочисленный массив nums длиной, являющейся степенью 2.
    Примените следующий алгоритм к nums:
        Пусть n будет длиной nums. Если n == 1, завершите процесс. В противном случае создайте новый нумерованный с 0 целочисленный массив newNums длиной n / 2.
        Для каждого чётного индекса i где 0 <= i < n / 2присвойте значение newNums[i] как min(nums[2 * i], nums[2 * i + 1]).
        Для каждого нечётного индекса i где 0 <= i < n / 2присвойте значение newNums[i] как max(nums[2 * i], nums[2 * i + 1]).
        Замените массив nums на newNums.
        Повторите весь процесс, начиная с шага 1.
    Возвращает последнее число, которое остается в nums после применения алгоритма.
    https://leetcode.com/problems/min-max-game/description/
     */
    public class Task2293 : InfoBasicTask
    {
        public Task2293(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 3, 5, 2, 4, 8, 2, 2 };
            printArray(nums);
            int result = minMaxGame(nums);
            Console.WriteLine($"Последнее число = {result}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int minMaxGame(int[] nums)
        {
            while (nums.Length != 1)
            {
                int indexInsert = 0;
                int[] newNums = new int[nums.Length / 2];
                for (int i = 0; i < nums.Length; i += 2)
                {
                    if (indexInsert % 2 == 0)
                    {
                        int min = Math.Min(nums[i], nums[i + 1]);
                        newNums[indexInsert] = min;
                    }
                    else
                    {
                        int min = Math.Max(nums[i], nums[i + 1]);
                        newNums[indexInsert] = min;
                    }
                    indexInsert++;
                }
                nums = newNums;
            }
            return nums[0];
        }
    }
}
