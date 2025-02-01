using LeetCode.Basic;
using System;
using System.Collections.Generic;

namespace LeetCode.Tasks.task1160
{
    public class Task1160 : InfoBasicTask
    {
        /*
         1160. Найдите слова, которые можно составить из этих символов
         Вам будет предоставлен массив строк words и строка chars.
        Строка хороша, если она может быть составлена из символов chars (каждый символ может использоваться только один раз).
        Возвращает сумму длин всех подходящих строк в словах.
         */
        public Task1160(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] words = new string[] { "cat", "bt", "hat", "tree" };
            string chars = "atach";
            int result = countCharacters(words, chars);
            Console.WriteLine($"Ответ = {result}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int countCharacters(string[] words, string chars)
        {
            int sum = 0;
            List<Dictionary<char, int>> charsByWords = new List<Dictionary<char, int>>();
            for (int i = 0; i < words.Length; i++)
            {
                Dictionary<char, int> dict = new Dictionary<char, int>();
                for (int j = 0; j < words[i].Length; j++)
                {
                    if (dict.ContainsKey(words[i][j]))
                    {
                        dict[words[i][j]]++;
                    }
                    else
                    {
                        dict.Add(words[i][j], 1);
                    }
                }
                charsByWords.Add(dict);
            }
            Dictionary<char, int> charsInStrChars = new Dictionary<char, int>();
            for (int i = 0; i < chars.Length; i++)
            {
                if (charsInStrChars.ContainsKey(chars[i]))
                {
                    charsInStrChars[chars[i]]++;
                }
                else
                {
                    charsInStrChars.Add(chars[i], 1);
                }
            }
            for (int i = 0; i < charsByWords.Count; i++)
            {
                Dictionary<char, int> currentWordByChars = charsByWords[i];
                bool currentWordCanBeConstructedFromWord = true;
                foreach (var pair in currentWordByChars)
                {
                    if (!charsInStrChars.ContainsKey(pair.Key) || currentWordByChars[pair.Key] > charsInStrChars[pair.Key])
                    {
                        currentWordCanBeConstructedFromWord = false;
                        break;
                    }
                }
                
                sum = currentWordCanBeConstructedFromWord ? sum + words[i].Length : sum;
            }
            return sum;
        }
    }
}
