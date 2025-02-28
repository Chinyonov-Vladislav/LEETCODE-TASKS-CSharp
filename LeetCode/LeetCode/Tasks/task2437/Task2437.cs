using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2437
{
    /*
     2437. Количество действительных часов
    Вам дана строка длиной 5 под названием time, представляющая текущее время на цифровых часах в формате "hh:mm". Самое раннее возможное время — "00:00", а самое позднее возможное время — "23:59".
    В строке time цифры, обозначенные символом ?, неизвестны и должны быть заменены цифрами от 0 до 9.
    Возвращает целое число answer, количество допустимых тактов, которое может быть создано путем замены каждого ? на цифру от 0 до 9.
    Ограничения:
        time является допустимой строкой длины 5 в формате "hh:mm".
        "00" <= hh <= "23"
        "00" <= mm <= "59"
        Некоторые цифры могут быть заменены на '?' и должны быть заменены на цифры от 0 до 9.
     */
    public class Task2437 : InfoBasicTask
    {
        public Task2437(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string time = "?5:00";
            Console.WriteLine($"Исходное время в строковом формате: \"{time}\"");
            if (isValid(time))
            {
                int res = countTime(time);
                Console.WriteLine($"Количество возможных действительных часов = {res}");
            }
            else
            {
                Console.WriteLine("Исходные данные не валидны!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(string time)
        {
            if (time.Length != 5)
            {
                return false;
            }
            if (time[2] != ':')
            {
                return false;
            }
            if (time[0] != '?')
            {
                int firstDigitHour = time[0] - '0';
                if (firstDigitHour > 3 || firstDigitHour < 0)
                {
                    return false;
                }
            }
            if (time[1] != '?')
            {
                int firstDigitHour = time[0] - '0';
                int secondDigitHour = time[1] - '0';
                if (firstDigitHour == 2)
                {
                    if (secondDigitHour > 3 || secondDigitHour < 0)
                    {
                        return false;
                    }
                }
                else
                {
                    if (secondDigitHour > 9 || secondDigitHour < 0)
                    {
                        return false;
                    }
                }
            }
            if (time[3] != '?')
            {
                int firstDigitMinutes = time[3] - '0';
                if (firstDigitMinutes > 5 || firstDigitMinutes < 0)
                {
                    return false;
                }
            }
            if (time[4] != '?')
            {
                int secondDigitMinutes = time[4] - '0';
                if (secondDigitMinutes < 0 || secondDigitMinutes >9)
                {
                    return false;
                }
            }
            return true;
        }
        private int countTime(string time)
        {
            if (!time.Contains('?'))
            {
                return 1;
            }
            int count = 1;
            if (time[0] == '?' && time[1] == '?')
            {
                count *= 24;
            }
            else if (time[0] == '?')
            {
                if (time[1] - '0' >= 4)
                {
                    count *= 2;
                }
                else
                {
                    count *= 3;
                }
            }
            else if (time[1] == '?')
            {
                if (time[0] - '0' == 2)
                {
                    count *= 4;
                }
                else
                {
                    count *= 10;
                }
            }
            if (time[3] == '?' && time[4] == '?')
            {
                count *= 60;
            }
            else if (time[3] == '?')
            {
                count *= 6;
            }
            else if (time[4] == '?')
            {
                count *= 10;
            }
            return count;
        }
    }
}
