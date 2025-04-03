using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task720
{
    /*
     720. Самое длинное слово в словаре
    Учитывая массив строк words из английского словаря, верните самое длинное слово, которое words можно составить из других слов, добавляя по одному символу за раз words.
    Если существует несколько возможных ответов, верните самое длинное слово с наименьшим лексикографическим порядком. Если ответа нет, верните пустую строку.
    Обратите внимание, что слово должно быть составлено слева направо, при этом каждый дополнительный символ добавляется в конец предыдущего слова.
    Ограничения:
        1 <= words.length <= 1000
        1 <= words[i].length <= 30
        words[i] состоит из строчных английских букв.
    https://leetcode.com/problems/longest-word-in-dictionary/description/
     */
    public class Task720 : InfoBasicTask
    {
        public Task720(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] words = new string[] { "a", "banana", "app", "appl", "ap", "apply", "apple" };
            printArray(words);
            if (isValid(words))
            {
                string res = longestWord(words);
                Console.WriteLine(res == String.Empty ? "Отсутствует самое длинное слово с наименьшим лексикографическим порядком из words, которое можно составить из других слов, добавляя по одному символу за раз" : $"Самое длинное слово с наименьшим лексикографическим порядком из words, которое можно составить из других слов, добавляя по одному символу за раз = {res}");
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
            int lowLimitCountWords = 1;
            int highLimitCountWords = 1000;
            int lowLimitLengthWord = 1;
            int highLimitLengthWord = 30;
            if (words.Length < lowLimitCountWords || words.Length > highLimitCountWords)
            {
                return false;
            }
            foreach (string word in words)
            {
                if (word.Length < lowLimitLengthWord || word.Length > highLimitLengthWord)
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
        private string longestWord(string[] words)
        {
            Dictionary<int, List<string>> dict = new Dictionary<int, List<string>>();
            Array.Sort(words);
            HashSet<string> set = new HashSet<string>(words);
            for (int i = words.Length - 1; i >= 0; i--)
            {
                string currentWord = words[i];
                bool existAllPrefix = true;
                for (int length = 1; length <= currentWord.Length-1; length++)
                {
                    string subString = currentWord.Substring(0, length);
                    if (!set.Contains(subString))
                    {
                        existAllPrefix = false;
                        break;
                    }
                }
                if (existAllPrefix)
                {
                    if (dict.ContainsKey(currentWord.Length))
                    {
                        dict[currentWord.Length].Add(currentWord);
                    }
                    else
                    {
                        dict.Add(currentWord.Length, new List<string>() { currentWord });
                    }
                }
            }
            if (dict.Count == 0)
            {
                return String.Empty;
            }
            List<string> candidates = dict.OrderByDescending(item => item.Key).First().Value;
            candidates.Sort();
            return candidates[0];
        }
    }
}
