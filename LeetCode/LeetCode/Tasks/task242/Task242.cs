using LeetCode.Basic;
using System;
using System.Collections.Generic;

namespace LeetCode.Tasks.task242
{
    public class Task242 : InfoBasicTask
    {
        /*
         242. Допустимая Анаграмма

        Учитывая две строки s и t, верните true, если t является анаграмма из s, и false в противном случае.
         */
        public Task242(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string first = "anagram";
            string second = "nagaram";
            Console.WriteLine(isAnagram(first, second) ? $"Строки \"{first}\" и \"{second}\" являются анаграмами" : $"Строки \"{first}\" и \"{second}\" не являются анаграмами");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isAnagram(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }
            Dictionary<char, int> charsFromFirstStr = new Dictionary<char, int>();
            for(int i=0; i< s.Length; i++)
            {
                if (charsFromFirstStr.ContainsKey(s[i]))
                {
                    charsFromFirstStr[s[i]]++;
                }
                else
                {
                    charsFromFirstStr.Add(s[i], 1);
                }
            }
            for (int i = 0; i < t.Length; i++)
            {
                if (charsFromFirstStr.ContainsKey(t[i]))
                {
                    charsFromFirstStr[t[i]]--;
                }
                else
                {
                    return false;
                }
            }
            foreach (var pair in charsFromFirstStr)
            {
                if (pair.Value != 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
