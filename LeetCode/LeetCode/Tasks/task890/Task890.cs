using LeetCode.Basic;
using LeetCode.Tasks.task705;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task890
{
    /*
     890. Найдите и замените шаблон
    Учитывая список строк words и строку pattern, верните список words[i] совпадающих pattern. Вы можете вернуть ответ в любом порядке.
    Слово соответствует шаблону, если существует перестановка букв p таким образом, что после замены каждой буквы x в шаблоне на p(x) мы получим желаемое слово.
    Напомним, что перестановка букв — это биекция между буквами: каждая буква сопоставляется с другой буквой, и никакие две буквы не сопоставляются с одной и той же буквой.
    Ограничения:
        1 <= pattern.length <= 20
        1 <= words.length <= 50
        words[i].length == pattern.length
        pattern и words[i] - это строчные английские буквы.
    https://leetcode.com/problems/find-and-replace-pattern/description/
     */
    public class Task890 : InfoBasicTask
    {
        public Task890(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] words = new string[] { "abc", "deq", "mee", "aqq", "dkd", "ccc" };
            string pattern = "abb";
            printArray(words, "Массив слов: ");
            Console.WriteLine($"Паттерн: \"{pattern}\"");
            if (isValid(words, pattern))
            {
                IList<string> res = findAndReplacePattern(words, pattern);
                printIListString(res, $"Массив слов, подходящих под паттерн \"{pattern}\": ");
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
        private bool isValid(string[] words, string pattern)
        {
            int lowLimitLengthPattern = 1;
            int highLimitLengthPattern = 20;
            int lowLimitLengthArrayWords = 1;
            int highLimitLengthArrayWords = 50;
            if (pattern.Length < lowLimitLengthPattern || pattern.Length > highLimitLengthPattern)
            {
                return false;
            }
            if (words.Length < lowLimitLengthArrayWords || words.Length > highLimitLengthArrayWords)
            {
                return false;
            }
            foreach (string word in words)
            {
                if (word.Length != pattern.Length)
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
            foreach (char c in pattern)
            {
                if (!(c >= 'a' && c <= 'z'))
                {
                    return false;
                }
            }
            return true;
        }
        private IList<string> findAndReplacePattern(string[] words, string pattern)
        {
            IList<string> result = new List<string>();
            foreach (string word in words)
            {
                Dictionary<char, char> dict = new Dictionary<char, char>();
                bool isCorrect = true;
                for (int i = 0; i < pattern.Length; i++)
                {
                    if (dict.ContainsKey(pattern[i]))
                    {
                        char charFromWord = dict[pattern[i]];
                        if (charFromWord != word[i])
                        {
                            isCorrect = false;
                            break;
                        }
                    }
                    else
                    {
                        dict.Add(pattern[i], word[i]);
                    }
                }
                if (isCorrect)
                {
                    HashSet<char> set = new HashSet<char>(dict.Values);
                    if (set.Count == dict.Count)
                    {
                        result.Add(word);
                    }
                }
            }
            return result;
        }
    }
}
