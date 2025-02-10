using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1704
{
    /*
     1704. Определите, содержат ли половинки строки одинаковое количество гласных символов
    Вам дана строка s чётной длины. Разделите эту строку на две половины равной длины и пусть a будет первой половиной, а b — второй.
    Две строки одинаковы , если они имеют одинаковое число гласных ('a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'). Обратите внимание, что s содержит заглавные и строчные буквы.
    Верните true если a и b то, что одинаково. В противном случае верните false.
    https://leetcode.com/problems/determine-if-string-halves-are-alike/description/
     */
    public class Task1704 : InfoBasicTask
    {
        public Task1704(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = "book";
            Console.WriteLine($"Исходная строка: \"{str}\"");
            if (isCorrectString(str))
            {
                Console.WriteLine(halvesAreAlike(str) ? "Первая половина строки и вторая половина строки содержат одинаковое количество гласных символов" : "Первая половина строки и вторая половина строки содержат различное количество гласных символов");
            }
            else
            {
                Console.WriteLine($"Исходная строка не является корректной, так как её длина является нечетной!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isCorrectString(string str)
        {
            return str.Length % 2 == 0;
        }
        private bool halvesAreAlike(string s)
        {
            List<char> vowels = new List<char>() { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            int countVowelsInFirstHalf = 0;
            int countVowelsInSecondHalf = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (vowels.Contains(s[i]))
                {
                    if (i < s.Length / 2)
                    {
                        countVowelsInFirstHalf++;
                    }
                    else
                    {
                        countVowelsInSecondHalf++;
                    }
                }
            }
            return countVowelsInFirstHalf == countVowelsInSecondHalf;
        }
    }
}
