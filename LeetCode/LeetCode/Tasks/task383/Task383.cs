using LeetCode.Basic;
using System;
using System.Collections.Generic;

namespace LeetCode.Tasks.task383
{
    public class Task383 : InfoBasicTask
    {
        /*
         383. Ransom Note
        Учитывая две строки ransomNote и magazine, верните true если ransomNote можно составить из букв magazine и false в противном случае.
        Каждая буква в magazine может быть использована только один раз в ransomNote.
         */
        public Task383(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string ransomNote = "aa";
            string magazine = "aab";
            Console.WriteLine(canConstruct(ransomNote, magazine) ? $"Строка \"{ransomNote}\" может быть сконструирована из строки \"{magazine}\"" : $"Строка \"{ransomNote}\" не может быть сконструирована из строки \"{magazine}\"");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool canConstruct(string ransomNote, string magazine)
        {
            Dictionary<char,int> chars = new Dictionary<char, int>();
            foreach (char symbol in magazine)
            {
                if (chars.ContainsKey(symbol))
                {
                    chars[symbol]++;
                }
                else
                {
                    chars[symbol]=1;
                }
            }
            foreach (char symbol in ransomNote)
            {
                if (chars.ContainsKey(symbol))
                {
                    chars[symbol]--;
                    if (chars[symbol] < 0)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        private bool bestSolution(string ransomNote, string magazine)
        {
            char[] magazineArray = magazine.ToCharArray();
            foreach (char character in ransomNote)
            {
                int index = Array.IndexOf(magazineArray, character);
                if (index == -1)
                {
                    return false;
                }
                magazineArray[index] = 'A';
            }
            return true;
        }
    }
}
