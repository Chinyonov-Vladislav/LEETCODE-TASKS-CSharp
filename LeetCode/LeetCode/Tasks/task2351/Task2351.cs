using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2351
{
    /*
     2351. Первая буква, появившаяся дважды
    Дана строка s, состоящая из строчных букв английского алфавита. Верните первую букву, которая встречаетсядважды.
    Примечание:
        Буква a появляется дважды перед другой буквой b, если второе появление a предшествует второму появлению b.
        s будет содержать по крайней мере одну букву, которая появляется дважды.
    Ограничения:
        2 <= s.length <= 100
        s состоит из строчных английских букв.
        s содержит по крайней мере одну повторяющуюся букву.
    https://leetcode.com/problems/first-letter-to-appear-twice/description/
     */
    public class Task2351 : InfoBasicTask
    {
        public Task2351(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string initialString = "abccbaacz";
            Console.WriteLine($"Исходная строка: \"{initialString}\"");
            char symbol = repeatedCharacter(initialString);
            Console.WriteLine(symbol == ' '? "В строке нет повторяющихся символов" : $"Первый повторяющийся символ: \'{symbol}\'");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private char repeatedCharacter(string s)
        {
            HashSet<char> set = new HashSet<char>();
            char returnedChar = ' ';
            for (int i = 0; i < s.Length; i++)
            {
                int sizeSet = set.Count;
                set.Add(s[i]);
                if (sizeSet == set.Count)
                {
                    return s[i];
                }
            }
            return returnedChar;
        }
    }
}
