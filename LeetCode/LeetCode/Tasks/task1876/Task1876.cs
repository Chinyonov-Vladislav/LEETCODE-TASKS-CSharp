using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1876
{
    /*
     1876. Подстроки размером три с разными символами
    Строка хороша, если в ней нет повторяющихся символов.
    Учитывая строку s​​​​​, верните количество хороших подстрокдлиной три в s​​​​​​.
    Обратите внимание, что если одна и та же подстрока встречается несколько раз, то нужно учитывать каждое её появление.
    Подстрока - это непрерывная последовательность символов в строке.
    https://leetcode.com/problems/substrings-of-size-three-with-distinct-characters/description/
     */
    public class Task1876 : InfoBasicTask
    {
        public Task1876(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string initialString = "xyzzaz";
            Console.WriteLine($"Исходная строка: \"{initialString}\"");
            int count = countGoodSubstrings(initialString);
            Console.WriteLine($"Количество подстрок длиной 3 символа с уникальными символами = {count}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int countGoodSubstrings(string s)
        {
            int count = 0;
            for (int i = 0; i < s.Length - 2; i++)
            {
                string substring = s.Substring(i, 3);
                HashSet<char> uniqueChars = new HashSet<char>(substring);
                if (uniqueChars.Count == substring.Length)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
