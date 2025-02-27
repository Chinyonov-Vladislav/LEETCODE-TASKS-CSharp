using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2309
{
    /*
     2309. Самая большая английская буква в верхнем и нижнем регистре
    Учитывая строку из английских букв s, верните самую большую букву, которая встречается как в нижнем, так и в верхнем регистре. 
    Возвращаемая буква должна быть в верхнем регистре. Если такой буквы не существует, верните пустую строку.
    Английская буква b больше другой буквы a, если b стоит после a неё в английском алфавите.
    https://leetcode.com/problems/greatest-english-letter-in-upper-and-lower-case/description/
     */
    public class Task2309 : InfoBasicTask
    {
        public Task2309(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string initialString = "lEeTcOdE";
            Console.WriteLine($"Исходная строка: \"{initialString}\"");
            string res = greatestLetter(initialString);
            Console.WriteLine(res == String.Empty ? "В текст нет буквы, которая встречалась бы в верхнем и нижнем регистре" : $"Самая дальняя по алфавиту буква, которая встречалась бы в верхнем и нижнем регистре в тексте - {res}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string greatestLetter(string s)
        {
            HashSet<char> chars = new HashSet<char>(s);
            for (char start = 'Z'; start >= 'A'; start--)
            {
                char lower = (char)((int)start + 32);
                if (chars.Contains(start) && chars.Contains(lower))
                {
                    return start.ToString();
                }
            }
            return String.Empty;
        }
    }
}
