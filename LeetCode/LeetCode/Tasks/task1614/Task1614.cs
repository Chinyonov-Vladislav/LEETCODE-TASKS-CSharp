using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1614
{
    /*
     1614. Максимальная глубина вложенности круглых скобок
    Учитывая корректную последовательность скобок s, верните глубину вложенности s. Глубина вложенности — это максимальное количество вложенных скобок.
    https://leetcode.com/problems/maximum-nesting-depth-of-the-parentheses/description/
     */
    public class Task1614 : InfoBasicTask
    {
        public Task1614(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = "(1+(2*3)+((8)/4))+1";
            Console.WriteLine($"Исходная строка = \"{str}\"");
            int maxDepthNestingParentheses = maxDepth(str);
            Console.WriteLine($"Максимальная глубина вложенности круглых скобок = {maxDepthNestingParentheses}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int maxDepth(string s)
        {
            int max = 0;
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    count++;
                    if (count > max)
                    {
                        max = count;
                    }
                }
                else if (s[i] == ')')
                {
                    count--;
                }
            }
            return max;
        }
    }
}
