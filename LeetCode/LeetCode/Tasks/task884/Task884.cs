using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task884
{
    /*
     884. Необычные слова из двух предложений
    Предложение — это строка из слов, разделённых одним пробелом, где каждое слово состоит только из строчных букв.
    Слово является необычным, если оно встречается ровно один раз в одном из предложений и не встречается в другом предложении.
    Учитывая два предложения s1 и s2, верните список всехнеобычных слов. Вы можете возвращать ответ в любом порядке.
    https://leetcode.com/problems/uncommon-words-from-two-sentences/description/
     */
    public class Task884 : InfoBasicTask
    {
        public Task884(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str1 = "this apple is sweet";
            string str2 = "this apple is sour";
            Console.WriteLine($"Первая строка = \"{str1}\"\nПервая строка = \"{str2}\"");
            printArray(uncommonFromSentences(str1, str2), "Уникальные слова из двух строк: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string[] uncommonFromSentences(string s1, string s2)
        {
            List<string[]> allWords = new List<string[]>() { s1.Split(' '), s2.Split(' ') };
            Dictionary<string, int> wordsInStrs = new Dictionary<string, int>();
            foreach (var arrayWord in allWords)
            {
                foreach (var word in arrayWord)
                {
                    if (wordsInStrs.ContainsKey(word))
                    {
                        wordsInStrs[word]++;
                    }
                    else
                    {
                        wordsInStrs.Add(word, 1);
                    }
                }
            }
            List<string> uniqueWords = new List<string>();
            foreach (var pair in wordsInStrs)
            {
                if (pair.Value == 1)
                {
                    uniqueWords.Add(pair.Key);
                }
            }
            return uniqueWords.ToArray();
        }
    }
}
