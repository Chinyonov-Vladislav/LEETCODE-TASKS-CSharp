using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2341
{
    /*
     2341. Максимальное количество пар в массиве
    Вам дан нумерованный с 0 целочисленный массив nums. За одну операцию вы можете сделать следующее:
        Выберите два целых числа в nums, которые равны.
        Удалите оба целых числа из nums, образуя пару.
        Операция выполняется на nums столько раз, сколько это возможно.
    Возврат в 0-индексированный массив целых чисел answer размером 2 где answer[0] - число пар, которые формируются и answer[1] количество оставшихся целых чисел, nums после того, как делают операцию столько раз, сколько возможно.
    https://leetcode.com/problems/maximum-number-of-pairs-in-array/description/
     */
    public class Task2341 : InfoBasicTask
    {
        public Task2341(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array = new int[] { 1, 3, 2, 1, 3, 2, 2 };
            printArray(array);
            int[] result = numberOfPairs(array);
            Console.WriteLine($"Количество пар = {result[0]}. Количество оставшихся различных чисел = {result[1]}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int[] numberOfPairs(int[] nums)
        {
            Dictionary<int,int> dict = new Dictionary<int, int>();
            foreach (int item in nums)
            {
                if (dict.ContainsKey(item))
                {
                    dict[item]++;
                }
                else
                {
                    dict.Add(item, 1);
                }
            }
            int countPairs = 0;
            int remain = 0;
            foreach (var pair in dict)
            {
                if (pair.Value % 2 != 0)
                {
                    remain++;
                }
                countPairs += pair.Value / 2;
            }
            return new int[] { countPairs, remain };
        }
    }
}
