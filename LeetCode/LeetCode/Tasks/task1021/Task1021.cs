using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1021
{
    /*
     1021. Удалите крайние круглые скобки
    Допустимая строка в скобках — это либо пустая "", либо "(" + A + ")", либо A + B, где A и B — допустимые строки в скобках, а + обозначает объединение строк.
        Например, "", "()", "(())()" и "(()(()))" все допустимые строки в круглых скобках.
    Допустимая строка в круглых скобках s является примитивной, если она непустая, и не существует способа разделить ее на s = A + B, с A и B непустые допустимые строки в круглых скобках.
    Рассмотрим допустимую последовательность скобок s и её примитивное разложение: s = P1 + P2 + ... + Pk, где Pi — примитивные допустимые последовательности скобок.
    Вернёмся s к удалению внешних скобок каждой примитивной строки в примитивном разложенииs.
    https://leetcode.com/problems/remove-outermost-parentheses/description/
     */
    public class Task1021 : InfoBasicTask
    {
        public Task1021(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = "(()())(())";
            Console.WriteLine($"Исходная строка: \"{str}\"");
            string resultStr = removeOuterParentheses(str);
            Console.WriteLine($"Результирующая строка = \"{resultStr}\"");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string removeOuterParentheses(string s)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int start = -1;
            int finish = -1;
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    count++;
                }
                if (s[i] == ')')
                {
                    count--;
                }
                if (count == 1 && start == -1 && s[i] == '(')
                {
                    start = i;   
                }
                else if (count == 0 & start > -1 && finish == -1 && s[i] == ')')
                {
                    finish = i;
                    if (finish - start > 1)
                    {
                        stringBuilder.Append(s.Substring(start + 1, finish-start -1 ));
                    }
                    start = -1;
                    finish = -1;
                }
            }
            return stringBuilder.ToString();
        }
    }
}
