using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2315
{
    /*
     2315. Подсчитайте звездочки
    Вам дана строка s, в которой каждые две последовательные вертикальные черты '|' образуют пару. Другими словами, 1я и 2я '|' образуют пару, 3я и 4я '|' образуют пару и так далее.
    Верните количество '*' в s, исключая '*' между каждой парой '|'.
    Обратите внимание, что каждый '|' будет принадлежать ровно одной паре.
    https://leetcode.com/problems/count-asterisks/description/
     */
    public class Task2315 : InfoBasicTask
    {
        public Task2315(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = "yo|uar|e**|b|e***au|tifu|l";
            Console.WriteLine($"Исходная строка: \"{str}\"");
            int count = countAsterisks(str);
            Console.WriteLine($"Количество звездочек,  исключая '*' между каждой парой \'|\' = {count}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int countAsterisks(string s)
        {
            int count = 0;
            string[] parts = s.Split('|');
            for (int i = 0; i < parts.Length; i+=2)
            {
                for (int indexChar = 0; indexChar < parts[i].Length; indexChar++)
                {
                    if (parts[i][indexChar] == '*')
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
