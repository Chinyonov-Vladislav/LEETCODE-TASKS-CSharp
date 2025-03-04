using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2810
{
    /*
     2810. Неисправная клавиатура
    Клавиатура вашего ноутбука неисправна, и всякий раз, когда вы вводите на ней символ 'i', он меняет местами символы в строке, которую вы написали. Ввод других символов работает как обычно.
    Вам дана строка с индексом 0s, и вы вводите каждый символ s с помощью неисправной клавиатуры.
    Верните последнюю строку, которая будет присутствовать на экране вашего ноутбука.
    Ограничения:
        1 <= s.length <= 100
        s состоит из строчных английских букв.
        s[0] != 'i'
    https://leetcode.com/problems/faulty-keyboard/description/
     */
    public class Task2810 : InfoBasicTask
    {
        public Task2810(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = "string";
            Console.WriteLine($"Исходная строка: \"{str}\"");
            if (isValid(str))
            {
                string result = finalString(str);
                Console.WriteLine($"Результирующая строка: \"{result}\"");
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
        private bool isValid(string s)
        {
            if (s.Length < 1 || s.Length > 100)
            {
                return false;
            }
            foreach (char c in s)
            {
                if (c < 'a' || c > 'z')
                {
                    return false;
                }
            }
            if (s[0] == 'i')
            {
                return false;
            }
            return true;
        }
        private string finalString(string s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != 'i')
                {
                    sb.Append(s[i]);
                }
                else
                {
                    string str = sb.ToString();
                    char[] charArray = str.ToCharArray(); 
                    Array.Reverse(charArray);
                    string reversedStr =  new string(charArray);
                    sb.Clear();
                    sb.Append(reversedStr);
                }
            }
            return sb.ToString();
        }
    }
}
