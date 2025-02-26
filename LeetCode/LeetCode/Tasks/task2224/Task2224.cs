using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2224
{
    /*
     2224. Минимальное количество операций для преобразования времени
    Вам даны две строки current и correct, представляющие два 24-часовых периода.
    24-часовое время отображается в формате "HH:MM", где HH находится между 00 и 23, а MM находится между 00 и 59. Самое раннее 24-часовое время — 00:00, а самое позднее — 23:59.
    За одну операцию вы можете увеличить время current на 1, 5 15 или 60 минуты. Вы можете выполнять эту операцию любое количество раз.
    Возвращает минимальное количество операций,необходимых для преобразования current в correct.
    https://leetcode.com/problems/minimum-number-of-operations-to-convert-time/description/
     */
    public class Task2224 : InfoBasicTask
    {
        public Task2224(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string currentTime = "02:30";
            string correctTime = "04:35";
            Console.WriteLine($"Текущее время: \"{currentTime}\"\nКорректное время: \"{correctTime}\"");
            if (isValid(currentTime, correctTime))
            {
                int countOper = convertTime(currentTime, correctTime);
                Console.WriteLine($"Количество операций для преобразования текущего время в корректное = {countOper}");
            }
            else
            {
                Console.WriteLine("Некорректно указаны строковые значения текущего или корректного времени");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(string current, string correct)
        {
            int hoursCurrent = Int32.Parse(current.Substring(0, 2));
            int minutesCurrent = Int32.Parse(current.Substring(3));
            int hoursCorrect = Int32.Parse(correct.Substring(0, 2));
            int minutesCorrect = Int32.Parse(correct.Substring(3));
            if (hoursCurrent < 0 || hoursCurrent > 23 || hoursCorrect < 0 || hoursCorrect > 23 || minutesCurrent < 0 || minutesCurrent > 59 || minutesCorrect < 0 || minutesCorrect > 59)
            {
                return false;
            }
            int totalMinutesCurrent = 60 * hoursCurrent + minutesCurrent;
            int totalMinutesCorrect = 60 * hoursCorrect + minutesCorrect;
            int differenceMinutes = totalMinutesCorrect - totalMinutesCurrent;
            if (differenceMinutes < 0)
            {
                return false;
            }
            return true;
        }
        private int convertTime(string current, string correct)
        {
            int hoursCurrent = Int32.Parse(current.Substring(0,2));
            int minutesCurrent = Int32.Parse(current.Substring(3));
            int hoursCorrect = Int32.Parse(correct.Substring(0, 2));
            int minutesCorrect = Int32.Parse(correct.Substring(3));
            int totalMinutesCurrent = 60*hoursCurrent + minutesCurrent;
            int totalMinutesCorrect = 60 * hoursCorrect + minutesCorrect;
            int differenceMinutes = totalMinutesCorrect - totalMinutesCurrent;
            int countOper = 0;
            while (differenceMinutes != 0)
            {
                countOper++;
                if (differenceMinutes >= 60)
                {
                    differenceMinutes -= 60;
                }
                else if (differenceMinutes >= 15)
                {
                    differenceMinutes -= 15;
                }
                else if (differenceMinutes >= 5)
                {
                    differenceMinutes -= 5;
                }
                else
                {
                    differenceMinutes -= 1;
                }
            }
            return countOper;
        }
    }
}
