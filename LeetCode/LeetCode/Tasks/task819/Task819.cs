using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task819
{
    /*
     819. Самое распространенное слово
    Учитывая строку paragraph и массив строк с запрещенными словами banned, верните наиболее часто встречающееся слово, которое не является запрещенным.
    Гарантируется, что хотя бы одно слово не является запрещенным и что ответ уникален.
    Слова в paragraph не чувствительны к регистру, и ответ должен быть возвращён в нижнем регистре.
     */
    public class Task819 : InfoBasicTask
    {
        public Task819(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string initialStr = "a, a, a, a, b,b,b,c, c";
            string[] banned = new string[] {  };
            Console.WriteLine($"Оригинальная строка = {initialStr}");
            Console.WriteLine($"Самое распространенное слово = {mostCommonWord(initialStr, banned)}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string mostCommonWord(string paragraph, string[] banned)
        {
            paragraph = paragraph.Trim().ToLower();
            List<string> words = new List<string>();
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < paragraph.Length; i++)
            {
                if (!char.IsPunctuation(paragraph[i]) && !char.IsWhiteSpace(paragraph[i]))
                {
                    stringBuilder.Append(paragraph[i]);
                }
                else if(stringBuilder.Length>0)
                {
                    words.Add(stringBuilder.ToString());
                    stringBuilder.Clear();
                }
            }
            if (stringBuilder.Length > 0)
            {
                words.Add(stringBuilder.ToString());
            }
            Dictionary<string, int> wordsByCount = new Dictionary<string, int>();
            foreach (string word in words)
            {
                if (!banned.Contains(word))
                {
                    if (!wordsByCount.ContainsKey(word))
                    {
                        wordsByCount.Add(word, 1);
                    }
                    else
                    {
                        wordsByCount[word]++;
                    }
                }
            }
            int maxValue = Int32.MinValue;
            string mostCommonWord = String.Empty;
            foreach (var pair in wordsByCount)
            {
                if (pair.Value > maxValue)
                {
                    maxValue = pair.Value;
                    mostCommonWord = pair.Key;
                }
            }
            return mostCommonWord;
        }
    }
}
