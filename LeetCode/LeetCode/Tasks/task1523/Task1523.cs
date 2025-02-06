using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1523
{
    /*
     1523. Подсчитывайте нечетные числа в интервальном диапазоне
    Даны два неотрицательных целых числа low и high. Верните количество нечётных чисел между low и high (включительно).
    https://leetcode.com/problems/count-odd-numbers-in-an-interval-range/description/
     */
    public class Task1523 : InfoBasicTask
    {
        public Task1523(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int low = 3;
            int high = 7;
            int countOddsInInverval = countOdds(low, high);
            Console.WriteLine($"Нижняя граница интервала = {low}\nВерхняя граница интервала = {high}\nКоличество нечетных чисел в интервала [{low},{high}] = {countOddsInInverval}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int countOdds(int low, int high)
        {
            int interval = high - low + 1;
            if (interval % 2 != 0)
            {
                if (high % 2 == 0 && low % 2 == 0)
                {
                    return interval / 2;
                }
                return interval / 2 + 1;
            }
            return interval / 2;
        }
    }
}
