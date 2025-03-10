using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3174
{
    /*
     3174. Четкие цифры
    Вам дается строка s.
    Ваша задача состоит в том, чтобы удалить все цифры, выполнив эту операцию повторно:
        Удалите первую цифру и ближайший нецифровый символ слева от нее.
    Верните результирующую строку после удаления всех цифр.
    Обратите внимание, что операция не может быть выполнена для цифры, слева от которой нет нецифровых символов.
    Ограничения:
        1 <= s.length <= 100
        s состоит только из строчных английских букв и цифр.
        Входные данные генерируются таким образом, что можно удалить все цифры.
    https://leetcode.com/problems/clear-digits/description/
     */
    public class Task3174 : InfoBasicTask
    {
        public Task3174(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string initialString = "cb34";
            Console.WriteLine($"Исходная строка: \"{initialString}\"");
            if (isValid(initialString))
            {
                string res = clearDigits(initialString);
                Console.WriteLine($"Результирующая строка после удаления всех цифр из строки и символа слева от них: \"{res}\"");
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
            if (s.Length < 1 || s.Length > 100)
            {
                return false;
            }
            foreach (char c in s)
            {
                if (!(c >= '0' && c < '9') && !(c >= 'a' && c <= 'z'))
                {
                    return false;
                }
            }
            StringBuilder sb = new StringBuilder(s);
            foreach (char c in s)
            {
                if (c >= '0' && c <= '9')
                {
                    if (sb.Length == 0)
                    {
                        return false;
                    }
                    sb.Remove(sb.Length - 1, 1);
                }
                else
                {
                    sb.Append(c);
                }
            }
            return true;
        }
        private string clearDigits(string s)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in s)
            {
                if (c >= '0' && c <= '9')
                {
                    sb = sb.Remove(sb.Length - 1, 1);
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}
