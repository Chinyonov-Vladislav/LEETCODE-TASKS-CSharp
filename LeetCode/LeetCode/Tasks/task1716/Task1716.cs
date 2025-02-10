using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1716
{
    /*
     1716. Рассчитайте деньги в банке Leetcode
    Герси хочет накопить на свою первую машину. Он каждый день кладёт деньги в банк Leetcode.
    Он начинает с того, что откладывает $1 в понедельник, в первый день. 
    Каждый день со вторника по воскресенье он откладывает $1 больше, чем накануне. 
    В каждый последующий понедельник он откладывает $1 больше, чем в предыдущий понедельник.
    Учитывая n, верните общую сумму денег, которая будет у него в банке Leetcode в конце nth дня.
    https://leetcode.com/problems/calculate-money-in-leetcode-bank/description/
     */
    public class Task1716 : InfoBasicTask
    {
        public Task1716(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int n = 20;
            Console.WriteLine($"Количество дней накопления денег = {n}");
            int totalSum = totalMoney(n);
            Console.WriteLine($"Итоговое количество денег в банке после {n} дней = {totalSum}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int totalMoney(int n)
        {
            int totalMoney = 0;
            int currentWeek = 0;
            int currentDay = 1;
            for (int i = 0; i < n; i++)
            {
                totalMoney += currentDay + currentWeek;
                currentDay++;
                if (currentDay > 7)
                {
                    currentDay = 1;
                    currentWeek++;
                }
            }
            return totalMoney;
        }
    }
}
