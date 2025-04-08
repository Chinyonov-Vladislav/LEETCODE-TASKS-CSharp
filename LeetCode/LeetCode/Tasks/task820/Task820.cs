using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task820
{
    /*
     820. Краткая кодировка слов
    Допустимая кодировка массива words — это любая ссылочная строка s и массив индексов, indices такие что:
        words.length == indices.length
        Строка ссылки s заканчивается символом '#' .
        Для каждого индекса indices[i] подстрока,s начинающаяся с indices[i] и заканчивающаяся (но не включающая) следующий '#' символ, равна words[i].
    Учитывая массив из words, верните в длину кратчайшей ссылочной строки s возможную из любой допустимой кодировки из words.
    Ограничения:
        1 <= words.length <= 2000
        1 <= words[i].length <= 7
        words[i] состоит только из строчных букв.
    https://leetcode.com/problems/short-encoding-of-words/description/
     */
    public class Task820 : InfoBasicTask
    {
        public Task820(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] words = new string[] { "time", "me", "bell" };
            printArray(words);
            if (isValid(words))
            {
                int res = minimumLengthEncoding(words);
                Console.WriteLine($"Минимальная длина возможной закодированной строки = {res}");
            }
            else
            {
                printInfoNotValidData();
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(string[] words)
        {
            int lowLimitWordsLength = 1;
            int highLimitWordsLength = 2000;
            if (words.Length < lowLimitWordsLength || words.Length > highLimitWordsLength)
            {
                return false;
            }
            int lowLimitLengthWord = 1;
            int highLimitLengthWord = 7;
            foreach (string word in words)
            {
                if(word.Length<lowLimitLengthWord || word.Length>highLimitLengthWord)
                {
                    return false;
                }
                foreach (char c in word)
                {
                    if (!(c >= 'a' && c <= 'z'))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private int minimumLengthEncoding(string[] words)
        {
            int count = 0;
            HashSet<string> setUniqueWords = new HashSet<string>(words);
            List<string> uniqueWords = setUniqueWords.ToList();
            for (int i = 0; i < uniqueWords.Count; i++)
            {
                bool isSuffix = false;
                for (int j = 0; j < uniqueWords.Count; j++) 
                {
                    if (i == j)
                    {
                        continue;
                    }
                    if (uniqueWords[j].EndsWith(uniqueWords[i]))
                    {
                        isSuffix = true;
                        break;
                    }
                }
                if (!isSuffix)
                {
                    count += uniqueWords[i].Length + 1;
                }
            }
            return count;
        }
        private int bestSolution(string[] words) // скопировано с leetcode
        {
            var distinctWords = new HashSet<string>(words);
            foreach (string word in words)
            {
                for (int startIndex = 1; startIndex < word.Length; startIndex++)
                {
                    distinctWords.Remove(word.Substring(startIndex));
                }
            }
            int totalLength = 0;
            foreach (string uniqueWord in distinctWords)
            {
                totalLength += uniqueWord.Length + 1;
            }
            return totalLength;
        }
    }
}
