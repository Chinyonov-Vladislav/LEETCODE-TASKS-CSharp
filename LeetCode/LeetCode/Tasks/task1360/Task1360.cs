using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1360
{
    /*
     1360. Количество дней между двумя датами
    Напишите программу для подсчета количества дней между двумя датами.
    Две даты указаны в виде строк, их формат — YYYY-MM-DD как показано в примерах.
    https://leetcode.com/problems/number-of-days-between-two-dates/description/
     */
    public class Task1360 : InfoBasicTask
    {
        public Task1360(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string date1 = "2020-01-15";
            string date2 = "2019-12-31";
            Console.WriteLine($"Дата №1 = \"{date1}\"");
            Console.WriteLine($"Дата №2 = \"{date2}\"");
            int countDaysBetweenDates = daysBetweenDates(date1, date2);
            Console.WriteLine($"Количество дней между датой №1 и датой №2 = {countDaysBetweenDates}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int daysBetweenDates(string date1, string date2)
        {
            string[] partsOfDate1 = date1.Split('-');
            string[] partsOfDate2 = date2.Split('-');
            int daysBetweenStartDateAndDate1 = getCountDaysFromStartDate(Convert.ToInt32(partsOfDate1[0]), Convert.ToInt32(partsOfDate1[1]), Convert.ToInt32(partsOfDate1[2]));
            int daysBetweenStartDateAndDate2 = getCountDaysFromStartDate(Convert.ToInt32(partsOfDate2[0]), Convert.ToInt32(partsOfDate2[1]), Convert.ToInt32(partsOfDate2[2]));
            return Math.Abs(daysBetweenStartDateAndDate1-daysBetweenStartDateAndDate2);
        }
        private int getCountDaysFromStartDate(int year, int month, int day)
        {
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
            int totalDays = 0;
            for (int startYear = 1900; startYear < year; startYear++)
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
            for (int i = 1; i < month; i++)
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
            totalDays += day;
            return totalDays;
        }
    }
}
