using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1221
{
    /*
     1221. Разделите строку на сбалансированные строки
    Сбалансированные строки — это строки, в которых одинаковое количество символов 'L' и 'R'.
    Дана сбалансированная строка s, разделите её на некоторое количество подстрок таким образом, чтобы:
        Каждая подстрока сбалансирована.
    Верните максимальное количество сбалансированных строк, которые вы можете получить.
    https://leetcode.com/problems/split-a-string-in-balanced-strings/description/
     */
    public class Task1221 : InfoBasicTask
    {
        public Task1221(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s = "RLRRLLRLRL";
            int result = balancedStringSplit(s);
            Console.WriteLine($"Максимальное количество сбалансированных подстрок: {result}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int balancedStringSplit(string s)
        {
            int balance = 0;
            int count = 0;

            foreach (char c in s)
            {
                if (c == 'L')
                {
                    balance++;
                }
                else if (c == 'R')
                {
                    balance--;
                }

                if (balance == 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
