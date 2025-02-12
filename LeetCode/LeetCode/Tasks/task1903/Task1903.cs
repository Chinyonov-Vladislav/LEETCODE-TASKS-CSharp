using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1903
{
    /*
     1903. Наибольшее нечетное число в строке
    Вам дана строка num, представляющая собой большое целое число. Верните наибольшеенечётноецелое число (в виде строки), которое являетсянепустой подстрокой в num, или пустую строку,""если нечётное целое число не существует.
    Подстрока - это непрерывная последовательность символов внутри строки.
    https://leetcode.com/problems/largest-odd-number-in-string/description/
     */
    public class Task1903 : InfoBasicTask
    {
        public Task1903(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = "35427";
            Console.WriteLine($"Исходная строка: \"{str}\"");
            string largestOdd = largestOddNumber(str);
            Console.WriteLine(largestOdd == String.Empty ? "В исходной строке отсутствует нечётное целое число" : $"Наибольшее нечетное целое число в исходной строке = {largestOdd}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string largestOddNumber(string num)
        {
            int right = num.Length-1;
            while (0 <= right)
            {
                int rightValue = num[right] - '0';
                if (rightValue % 2 == 1)
                {
                    break;
                }
                if (rightValue % 2 != 1)
                {
                    right--;
                }
            }
            if (right < 0)
            {
                return String.Empty;
            }
            return num.Substring(0, right + 1);
        }
    }
}
