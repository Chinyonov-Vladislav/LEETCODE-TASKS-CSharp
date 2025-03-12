using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3461
{
    /*
     3461. Проверьте, совпадают ли цифры в строке после выполнения операций I
    Вам дана строка s, состоящая из цифр. Выполняйте следующую операцию до тех пор, пока в строке не останется ровно две цифры:
        Для каждой пары последовательных цифр в s, начиная с первой цифры, вычислите новую цифру как сумму двух цифр по модулю 10.
        Замените s на последовательность только что вычисленных цифр, сохраняя порядок, в котором они вычисляются.
    Верните true если последние две цифры в sодинаковы; в противном случае верните false.
    Ограничения:
        3 <= s.length <= 100
        s состоит только из цифр.
    https://leetcode.com/problems/check-if-digits-are-equal-in-string-after-operations-i/description/
     */
    public class Task3461 : InfoBasicTask
    {
        public Task3461(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s = "3902";
            Console.WriteLine($"Исходная строка: \"{s}\"");
            if (isValid(s))
            {
                Console.WriteLine(hasSameDigits(s) ? "Строка длиной 2 после выполнения операций имеет одинаковые цифры" : "Строка длиной 2 после выполнения операций имеет различные цифры");
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
        private bool isValid(string s)
        {
            if (s.Length < 3 || s.Length > 100)
            {
                return false;
            }
            foreach (char c in s)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
        private bool hasSameDigits(string s)
        {
            while (s.Length != 2)
            {
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 1; i < s.Length; i++)
                {
                    int firstDigit = s[i-1]-'0';
                    int secondDigit = s[i] - '0';
                    stringBuilder.Append((secondDigit+firstDigit) %10);
                }
                s = stringBuilder.ToString();
            }
            return s[0] == s[1];
        }
    }
}
