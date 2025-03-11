using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3280
{
    /*
     3280. Преобразование даты в двоичный код
    Вам дана строка date, представляющая дату по григорианскому календарю в формате yyyy-mm-dd.
    date можно записать в двоичном представлении, полученном путём преобразования года, месяца и дня в их двоичные представления без ведущих нулей и записи их в формате year-month-day.
    Возвращает двоичное представление date.
    Ограничения:
        date.length == 10
        date[4] == date[7] == '-', а все остальные date[i] - это цифры.
        Входные данные генерируются таким образом, что date представляет собой допустимую дату по григорианскому календарю в период с 1го января 1900 года по 31е декабря 2100 года (включительно).
     https://leetcode.com/problems/convert-date-to-binary/description/
     */
    public class Task3280 : InfoBasicTask
    {
        public Task3280(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string date = "2080-02-29";
            Console.WriteLine($"Дата в строковом формате: \"{date}\"");
            if (isValid(date))
            {
                string binary = convertDateToBinary(date);
                Console.WriteLine($"Репрезентация даты в бинарном виде: \"{binary}\"");
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
        private bool isValid(string date)
        {
            if (date.Length != 10)
            {
                return false;
            }
            if (!(date[4] =='-' && date[7]=='-'))
            {
                return false;
            }
            for (int i = 0; i < date.Length; i++)
            {
                if (i == 4 || i == 7)
                {
                    continue;
                }
                if (!char.IsDigit(date[i]))
                {
                    return false;
                }
            }
            if (!DateTime.TryParseExact(date, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
            {
                return false;
            }
            DateTime minDate = new DateTime(1900, 1, 1);
            DateTime maxDate = new DateTime(2100, 12, 31);
            if (!(parsedDate >= minDate && parsedDate <= maxDate))
            {
                return false;
            }
            return true;
        }
        private string convertDateToBinary(string date)
        {
            StringBuilder sb = new StringBuilder();
            string[] parts = date.Split('-');
            for (int i = 0; i < parts.Length; i++)
            {
                int partValueInt = Convert.ToInt32(parts[i]);
                string binaryRepresentationPart = Convert.ToString(partValueInt, 2);
                sb.Append(binaryRepresentationPart);
                if (parts.Length - 1 != i)
                {
                    sb.Append("-");
                }
            }
            return sb.ToString();
        }
    }
}
