using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1507
{
    /*
     1507. Переформатирование даты
    Дана date строка в форме Day Month Year, где:
        Day есть в наборе {"1st", "2nd", "3rd", "4th", ..., "30th", "31st"}.
        Month есть в наборе {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"}.
        Year находится в пределах досягаемости [1900, 2100].
    Преобразуйте строку даты в формат YYYY-MM-DD, где:
        YYYY обозначает 4-значный год.
        MM обозначает 2-значный месяц.
        DD обозначает 2-значный день.
    https://leetcode.com/problems/reformat-date/description/
     */
    public class Task1507 : InfoBasicTask
    {
        public Task1507(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string dateInInitialForm = "20th Oct 2052";
            Console.WriteLine($"Дата в изначальном формате: \"{dateInInitialForm}\"");
            string dateInFinishForm = reformatDate(dateInInitialForm);
            Console.WriteLine($"Дата в конечном формате: \"{dateInFinishForm}\"");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string reformatDate(string date)
        {
            Dictionary<string, string> months = new Dictionary<string, string>() {
                {"Jan","01" },
                {"Feb","02" },
                {"Mar","03" },
                {"Apr","04" },
                {"May","05" },
                {"Jun","06" },
                {"Jul","07" },
                {"Aug","08" },
                {"Sep","09" },
                {"Oct","10" },
                {"Nov","11" },
                {"Dec","12" },
            };
            string[] parts = date.Split(' ');
            string day = parts[0].Substring(0, parts[0].Length - 2);
            string month = months[parts[1]];
            string year = parts[2];
            StringBuilder sb = new StringBuilder();
            sb.Append(year);
            sb.Append('-');
            sb.Append(month);
            sb.Append('-');
            if (day.Length < 2)
            {
                sb.Append('0');
                
            }
            sb.Append(day);
            return sb.ToString();
        }
    }
}
