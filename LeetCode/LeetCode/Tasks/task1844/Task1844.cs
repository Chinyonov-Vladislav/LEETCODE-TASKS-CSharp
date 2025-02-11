using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1844
{
    /*
     1844. Замените Все Цифры Символами
    Вам будет предоставлена строка с sиндексом 0, в четных индексах которой есть строчные английские буквы, а в нечетных" - цифры.
    Вы должны выполнить операцию shift(c, x), где c — символ, а x — цифра, которая возвращает символ xth после c.
        Например, shift('a', 5) = 'f' и shift('x', 0) = 'x'.
    Для каждого нечётного индекса i вы хотите заменить цифру s[i] на результат операции shift(s[i-1], s[i]) .
    Вернитесь s после замены всех цифр. Гарантируется, что shift(s[i-1], s[i]) это значение никогда не превысит 'z'.
    Обратите внимание, что shift(c, x) — это не предустановленная функция, а операция, которая должна быть реализована как часть решения.
    https://leetcode.com/problems/replace-all-digits-with-characters/description/
     */
    public class Task1844 : InfoBasicTask
    {
        public Task1844(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = "a1b2c3d4e";
            Console.WriteLine($"Исходная строка: \"{str}\"");
            string result = replaceDigits(str);
            Console.WriteLine($"Результирующая строка: \"{result}\"");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string replaceDigits(string s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <= s.Length - 2; i += 2)
            {
                sb.Append(s[i]);
                char newChar = Convert.ToChar(s[i] + (Convert.ToInt32(s[i + 1]) - '0'));
                sb.Append(newChar);
            }
            if (s.Length % 2 != 0)
            {
                sb.Append(s[s.Length - 1]);
            }
            return sb.ToString();
        }
    }
}
