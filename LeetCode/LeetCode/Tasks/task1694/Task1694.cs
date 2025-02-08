using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1694
{
    /*
     1694. Переформатировать номер телефона
    Вам дан номер телефона в виде строки number. number состоящей из цифр, пробелов ' ' и/или тире '-'.
    Вы хотели бы переформатировать номер телефона определенным образом. Во-первых, удалите все пробелы и тире. 
    Затем сгруппируйте цифры слева направо в блоки длиной 3, пока не останется 4 или меньше цифр. Затем последние цифры группируются следующим образом:
        2 цифры: один блок длиной 2.
        3 цифры: один блок длиной 3.
        4 цифры: два блока длиной по 2 каждый.
    Затем блоки соединяются тире. Обратите внимание, что в процессе переформатирования никогда не должно появляться блоков длиной 1 и максимум два блока длиной 2.
    Верните номер телефона после форматирования.
    https://leetcode.com/problems/reformat-phone-number/description/
     */
    public class Task1694 : InfoBasicTask
    {
        public Task1694(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string initialNumber = "1-23-45 6";
            Console.WriteLine($"Исходный формат номера телефона = \"{initialNumber}\"");
            string finalNumber = reformatNumber(initialNumber);
            Console.WriteLine($"Номер телефона после форматирования = \"{finalNumber}\"");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string reformatNumber(string number)
        {
            StringBuilder numberPhone = new StringBuilder();
            for (int i = 0; i < number.Length; i++)
            {
                if (char.IsDigit(number[i]))
                {
                    numberPhone.Append(number[i]);
                }
            }
            string str = numberPhone.ToString();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length;)
            {
                int countRemainDigits = str.Length - i;
                if (countRemainDigits == 4)
                {
                    sb.Append(str.Substring(i, 2));
                    sb.Append('-');
                    sb.Append(str.Substring(i + 2, 2));
                    break;
                }
                else if (countRemainDigits > 3)
                {
                    sb.Append(str.Substring(i, 3));
                    sb.Append('-');
                    i += 3;
                }
                else if (countRemainDigits == 3)
                {
                    sb.Append(str.Substring(i, 3));
                    break;
                }
                else if (countRemainDigits == 2)
                {
                    sb.Append(str.Substring(i, 2));
                    break;
                }
            }
            return sb.ToString();
        }
    }
}
