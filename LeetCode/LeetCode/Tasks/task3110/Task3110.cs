using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3110
{
    /*
     3110. Партитура строки
    Вам дана строка s.Оценка строки определяется как сумма абсолютных разностей между значениями ASCII соседних символов.
    Верните счет s.
    Ограничения:
        2 <= s.length <= 100
        s состоит только из строчных английских букв.
    https://leetcode.com/problems/score-of-a-string/description/
     */
    public class Task3110 : InfoBasicTask
    {
        public Task3110(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s = "hello";
            Console.WriteLine($"Исходная строка: \"{s}\"");
            if (isValid(s))
            {
                int score = scoreOfString(s);
                Console.WriteLine($"Счёт исходной строки = {score}");
            }
            else
            {
                Console.WriteLine("Исходная строка не валидна");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(string s)
        {
            if (s.Length < 2 || s.Length > 100)
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
            return true;
        }
        private int scoreOfString(string s)
        {
            int score = 0;
            for (int i = 0; i < s.Length - 1; i++)
            {
                score += Math.Abs(s[i] - s[i + 1]);
            }
            return score;
        }
    }
}
