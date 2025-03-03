using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2710
{
    /*
     2710. Удаление завершающих нулей из строки
    Учитывая положительное целое число num, представленное в виде строки, верните целое числоnumбез конечных нулей в виде строки.
    Ограничения:
        1 <= num.length <= 1000
        num состоит только из цифр.
        num не имеет никаких начальных нулей.
    https://leetcode.com/problems/remove-trailing-zeros-from-a-string/description/
     */
    public class Task2710 : InfoBasicTask
    {
        public Task2710(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = "51230100";
            Console.WriteLine($"Исходная строка: \"{str}\"");
            if (isValid(str))
            {
                string res = removeTrailingZeros(str);
                Console.WriteLine(res==str ? "Исходная строка не содержала завершающих нулей!" :$"Результирующая строка без нулей в окончании: \"{res}\"");
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
        private bool isValid(string num)
        {
            if (num.Length < 1 || num.Length > 1000)
            {
                return false;
            }
            foreach (char c in num)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            string stringWithoutLeadingZero = num.TrimStart('0');
            if (stringWithoutLeadingZero != num)
            {
                return false;
            }
            return true;
        }
        private string removeTrailingZeros(string num)
        {
            int indexFirstNotZero = -1;
            for (int i = num.Length - 1; i >= 0; i--)
            {
                if (num[i] != '0')
                {
                    indexFirstNotZero = i;
                    break;
                }
            }
            if (indexFirstNotZero == -1)
            {
                return num;
            }
            return num.Substring(0, indexFirstNotZero + 1);
        }
    }
}
