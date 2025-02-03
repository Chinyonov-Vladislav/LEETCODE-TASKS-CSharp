using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1185
{
    /*
     1185. День недели
    Учитывая дату, верните соответствующий день недели для этой даты.
    Входные данные задаются в виде трех целых чисел, представляющих day, month и year соответственно.
    Верните ответ в виде одного из следующих значений {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"}.
    https://leetcode.com/problems/day-of-the-week/description/
     */
    public class Task1185 : InfoBasicTask
    {
        public Task1185(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int day = 31, month = 8, year = 2019;
            Console.WriteLine($"День = {day} Месяц = {month} Год = {year}");
            string dayOfWeek = dayOfTheWeek(day, month, year);
            Console.WriteLine($"День недели = {dayOfWeek}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string dayOfTheWeek(int day, int month, int year)
        {
            Dictionary<uint, string> days = new Dictionary<uint, string>() {
                {0,"Sunday" },
                {1,"Monday" },
                {2,"Tuesday" },
                {3,"Wednesday" },
                {4,"Thursday" },
                {5,"Friday" },
                {6,"Saturday" },
            };
            Dictionary<uint, uint> monthsAndDates = new Dictionary<uint, uint>()
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
            uint totalDays = 4;
            for (int startYear = 1971; startYear < year; startYear++)
            {
                if ((startYear % 100 == 0 && startYear % 400 == 0) || (startYear % 4 == 0 && startYear % 100 != 0))
                {
                    totalDays += 366;
                }
                else
                {
                    totalDays += 365;
                }
            }
            for (uint i = 1; i < month; i++)
            {
                if (i == 2 && ((year % 100 == 0 && year % 400 == 0) || (year % 4 == 0 && year % 100 != 0)))
                {
                    totalDays += monthsAndDates[i] + 1;
                }
                else
                {
                    totalDays += monthsAndDates[i];
                }
            }
            totalDays += (uint)day;
            return days[totalDays % 7];
        }
    }
}
