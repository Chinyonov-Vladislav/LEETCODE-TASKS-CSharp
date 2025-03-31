using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task692
{
    /*
     692. Топ-K Часто встречающихся слов
    Учитывая массив строк words и целое число k, верните в k наиболее часто встречающиеся строки.
    Верните ответ, отсортированный по частоте от наибольшей к наименьшей. Отсортируйте слова с одинаковой частотой по их лексикографическому порядку.
    Ограничения:
        1 <= words.length <= 500
        1 <= words[i].length <= 10
        words[i] состоит из строчных английских букв.
        k находится в пределах досягаемости [1, The number of unique words[i]]
    https://leetcode.com/problems/top-k-frequent-words/description/
     */
    public class Task692 : InfoBasicTask
    {
        public Task692(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] words = new string[] { "the", "day", "is", "sunny", "the", "the", "the", "sunny", "is", "is" };
            printArray(words);
            int k = 4;
            Console.WriteLine($"Значение переменной k = {k}");
            if (isValid(words, k))
            {
                IList<string> res = topKFrequent(words, k);
                printIListString(res, $"{k} наиболее часто встречающиеся строки: ");
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
        private bool isValid(string[] words, int k)
        {
            int lowLimitLengthArr = 1;
            int highLimitLengthArr = 500;
            int lowLimitLengthWord = 1;
            int highLimitLengthWord = 10;
            if (words.Length < lowLimitLengthArr || words.Length > highLimitLengthArr)
            {
                return false;
            }
            HashSet<string> uniqueWords = new HashSet<string>();
            foreach (string word in words)
            {
                uniqueWords.Add(word);
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
            int lowLimitK = 1;
            int highLimitK = uniqueWords.Count;
            if (k < lowLimitK || k > highLimitK)
            {
                return false;
            }
            return true;
        }
        private IList<string> topKFrequent(string[] words, int k)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (string word in words)
            {
                if (dict.ContainsKey(word))
                {
                    dict[word]++;
                }
                else
                {
                    dict.Add(word, 1);
                }
            }
            return dict.OrderByDescending(item => item.Value).ThenBy(item => item.Key).Take(k).ToDictionary(item => item.Key, item => item.Value).Keys.ToList();
        }
    }
}
