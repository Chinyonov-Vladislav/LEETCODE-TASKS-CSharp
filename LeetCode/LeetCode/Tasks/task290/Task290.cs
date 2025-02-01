using LeetCode.Basic;
using System;
using System.Collections.Generic;

namespace LeetCode.Tasks.task290
{
    public class Task290 : InfoBasicTask
    {
        /* 
         290. Словесный паттерн

        Учитывая pattern и строку s, найдите, если s соответствует тому же шаблону.
        Здесь следовать означает полное соответствие, при котором существует взаимно-однозначное соответствие между буквой в pattern и непустым словом в s. В частности:
            Каждая буква в pattern соответствует ровно одному уникальному слову в s.
            Каждое уникальное слово в s соответствует ровно одной букве в pattern.
            Никакие две буквы не соответствуют одному и тому же слову, и никакие два слова не соответствуют одной и той же букве.
         */
        public Task290(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string pattern = "abba";
            string str = "dog, cat, cat, dog";
            Console.WriteLine(wordPattern(pattern, str) ? $"Строка \"{str}\" соответствует паттерну \"{pattern}\"" : $"Строка \"{str}\" не соответствует паттерну \"{pattern}\"");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool wordPattern(string pattern, string s)
        {
            char[] separators = new char[] { ',', ' ' };
            Dictionary<char, string> dict = new Dictionary<char, string>();
            string[] words = s.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length != pattern.Length)
            {
                return false;
            }
            for (int i = 0; i < pattern.Length; i++)
            {
                if (dict.ContainsKey(pattern[i]))
                {
                    string word = dict[pattern[i]];
                    if (word != words[i])
                    {
                        return false;
                    }
                }
                else
                {
                    if (!dict.ContainsValue(words[i]))
                    {
                        dict.Add(pattern[i], words[i]);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
