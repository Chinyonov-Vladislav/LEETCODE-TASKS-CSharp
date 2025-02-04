using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1309
{
    /*
     1309. Расшифровать строку из алфавита в целочисленное сопоставление
    Вам дана строка s, состоящая из цифр и '#'. Мы хотим преобразовать s в строчные буквы английского алфавита следующим образом:
        Символы ('a' to 'i') представлены символом ('1' to '9') соответственно.
        Символы ('j' to 'z') представлены символом ('10#' to '26#') соответственно.
        Возвращает строку, сформированную после сопоставления.
    Тестовые примеры генерируются таким образом, чтобы всегда существовало уникальное сопоставление.
    https://leetcode.com/problems/decrypt-string-from-alphabet-to-integer-mapping/description/
     */
    public class Task1309 : InfoBasicTask
    {
        public Task1309(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = "10#11#12";
            Console.WriteLine($"Начальная строка = \"{str}\"");
            string result = freqAlphabets(str);
            Console.WriteLine($"Расшифрованная строка = \"{result}\"");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string freqAlphabets(string s)
        {
            StringBuilder result = new StringBuilder();
            StringBuilder sb = new StringBuilder();
            for (int i = s.Length - 1; i >= 0; )
            {
                if (s[i] == '#')
                {
                    sb.Append(s[i - 2]);
                    sb.Append(s[i - 1]);
                }
                else
                {
                    sb.Append(s[i]);
                }
                int number = Convert.ToInt32(sb.ToString());
                char c = (char)(96 + number);
                result.Insert(0, c);
                sb.Clear();
                if (s[i] == '#')
                {
                    i -= 3;
                }
                else
                {
                    i--;
                }
            }
            return result.ToString();
        }
    }
}
