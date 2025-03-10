using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3210
{
    /*
     3210. Найдите зашифрованную строку
    Вам дана строка s и целое число k. Зашифруйте строку с помощью следующего алгоритма:
        Для каждого символа c в s замените c на символ kth после c в строке (по кругу).
    Возвращает зашифрованную строку.
    Ограничения:
        1 <= s.length <= 100
        1 <= k <= 10^4
        s состоит только из строчных английских букв.
    https://leetcode.com/problems/find-the-encrypted-string/description/
     */
    public class Task3210 : InfoBasicTask
    {
        public Task3210(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s = "dart";
            int k = 3;
            Console.WriteLine($"Исходная строка: \"{s}\"\nЗначение переменной k = {k}");
            if (isValid(s, k))
            {
                string res = getEncryptedString(s, k);
                Console.WriteLine($"Зашифрованная строка: \"{res}\"");
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
        private bool isValid(string s, int k)
        {
            if (s.Length < 1 || s.Length > 100)
            {
                return false;
            }
            int highLimit = (int)Math.Pow(10, 4);
            if (k < 1 || k > highLimit)
            {
                return false;
            }
            foreach (char c in s)
            {
                if (!(c >= 'a' && c <= 'z'))
                {
                    return false;
                }
            }
            return true;
        }
        private string getEncryptedString(string s, int k)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                int newIndex = (k + i)%s.Length;
                sb.Append(s[newIndex]);
            }
            return sb.ToString();
        }
    }
}
