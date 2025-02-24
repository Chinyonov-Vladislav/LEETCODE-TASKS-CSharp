using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2027
{
    /*
     2027. Минимальные шаги для преобразования строки
    Вам дана строка s, состоящая из n символов, которые являются либо 'X', либо 'O'.
    Ход определяется как выбор трёх последовательных символов s и преобразование их в 'O'. 
    Обратите внимание, что если ход применяется к символу 'O', он останется прежним.
    Верните минимальноеколичествоходов, необходимых для преобразования всех символов в s'O'.
    https://leetcode.com/problems/minimum-moves-to-convert-string/description/
     */
    public class Task2027 : InfoBasicTask
    {
        public Task2027(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s = "XXOX";
            Console.WriteLine($"Исходная строка = \"{s}\"");
            int count = minimumMoves(s);
            Console.WriteLine($"минимальное количество ходов, необходимых для преобразования всех символов в s 'O' = {count}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int minimumMoves(string s)
        {
            int count = 0;
            char[] chars = s.ToCharArray();
            int position = 0;
            while (position < chars.Length)
            {
                if (chars[position] == 'X')
                {
                    count++;
                    position += 3;
                }
                else
                {
                    position++;
                }
            }
            return count;
        }
    }
}
