using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task921
{
    /*
     921. Минимальное добавление, чтобы сделать круглые скобки допустимыми
    Строка в круглых скобках допустима тогда и только тогда, когда:
        Это пустая строка,
        Это можно записать как AB (A объединено с B), где A и B являются допустимыми строками, или
        Это может быть записано как (A), где A - допустимая строка.
    Вам дана строка из скобок s. За один ход вы можете вставить скобку в любое место строки.
        Например, если s = "()))" — вы можете вставить открывающую скобку "(()))" или закрывающую скобку "())))".
    Возвращает минимальное количество ходов, необходимых для того, чтобы сделать s действительным.
    Ограничения:
        1 <= s.length <= 1000
        s[i] является либо '(', либо ')'.
    https://leetcode.com/problems/minimum-add-to-make-parentheses-valid/description/
     */
    public class Task921 : InfoBasicTask
    {
        public Task921(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s = "(((";
            Console.WriteLine($"Исходная строка: \"{s}\"");
            if (isValid(s))
            {
                int count = minAddToMakeValid(s);
                Console.WriteLine($"Минимальное количество операций вставки скобок для того, чтобы сделать строку валидной = {count}");
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
            int minLengthInitialString = 1;
            int maxLengthInitialString = 1000;
            if (s.Length < minLengthInitialString || s.Length > maxLengthInitialString)
            {
                return false;
            }
            List<char> acceptedChars = new List<char>() { '(', ')' };
            foreach (char c in s)
            {
                if (!acceptedChars.Contains(c))
                {
                    return false;
                }
            }    
            return true;        
        }
        private int minAddToMakeValid(string s)
        {
            int count = 0;
            Stack<char> chars = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    chars.Push(s[i]);
                }
                else
                {
                    if (chars.Count > 0)
                    {
                        chars.Pop();
                    }
                    else
                    {
                        count++;
                    }
                }
            }
            count += chars.Count;
            return count;
        }
    }
}
