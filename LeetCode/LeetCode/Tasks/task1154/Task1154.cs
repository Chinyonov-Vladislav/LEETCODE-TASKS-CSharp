using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1154
{
    /*
     1154. День в году
    Учитывая строку date с датой по григорианскому календарю, отформатированную как YYYY-MM-DD, верните номер дня в году.
    https://leetcode.com/problems/day-of-the-year/description/
     */
    public class Task1154 : InfoBasicTask
    {
        public Task1154(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string date = "2019-02-10";
            Console.WriteLine($"Дата = {date}");
            Console.WriteLine($"День года = {dayOfYear(date)}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int dayOfYear(string date)
        {
            int numberDate = 0;
            Dictionary<int, int> monthsAndDates = new Dictionary<int, int>()
            {
                { 1, 31},
                { 2, 28},
                { 3, 31},
                { 4, 30},
                { 5, 31},
                { 6, 30},
                { 7, 31},
                { 8, 31},
                { 9, 30},
                { 10, 31},
                { 11, 30},
                { 12, 31}
            };
            string[] partOfDate = date.Split('-');
            int year = Convert.ToInt32(partOfDate[0]);
            int month = Convert.ToInt32(partOfDate[1]);
            int day = Convert.ToInt32(partOfDate[2]);
            for (int i = 1; i < month; i++)
            {
                if (i == 2 && ((year % 100 == 0 && year % 400 == 0) || ( year % 4 == 0 && year % 100 != 0)))
                {
                    numberDate += monthsAndDates[i] + 1;
                }
                else
                {
                    numberDate += monthsAndDates[i];
                }
            }
            return numberDate + day;
        }
    }
}
