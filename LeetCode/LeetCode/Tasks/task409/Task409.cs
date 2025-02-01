using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Tasks.task409
{
    public class Task409 : InfoBasicTask
    {
        /*
         409. Самый длинный Палиндром
        Дана строка s, состоящая из строчных или прописных букв. Верните длину самого длинного из возможных палиндромов, которые могут быть построены с помощью этих букв.
        Буквы чувствительны к регистру, например, "Aa" не считается палиндромом.
         */
        public Task409(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string originalStr = "abccccdd";
            Console.WriteLine($"Максимальная длина палиндрома из строки \"{originalStr}\" равна {longestPalindrome(originalStr)}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        public int longestPalindrome(string s)
        {
            Dictionary<char, int> chars = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (chars.ContainsKey(c))
                {
                    chars[c]++;
                }
                else
                {
                    chars.Add(c, 1);
                }
            }
            int countSymbolsInPalindrome = 0;
            foreach (var key in chars.Keys.ToList())
            {
                if (chars[key] % 2 == 0)
                {
                    countSymbolsInPalindrome += chars[key];
                    chars[key] = 0;
                }
                else
                {
                    countSymbolsInPalindrome += chars[key] - 1;
                    chars[key] = 1;
                }
            }
            foreach (var pair in chars)
            {
                if (pair.Value == 1)
                {
                    return countSymbolsInPalindrome + 1;
                }
            }
            return countSymbolsInPalindrome;
        }
    }
}
