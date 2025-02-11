using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1859
{
    /*
     1859. Сортировка предложения
    Предложение — это список слов, разделённых одним пробелом без начальных и конечных пробелов. Каждое слово состоит из строчных и прописных английских букв.
    Предложение можно переставить местами, добавив к каждому слову индекс позиции и затем переставив слова в предложении.
        Например, предложение "This is a sentence" можно переставить как "sentence4 a3 is2 This1" или "is2 sentence4 This1 a3".
    Дано переставленное местами предложение s, содержащее не более 9 слов. Восстановите и верните исходное предложение.
    Ограничения:
        2 <= s.length <= 200
        s состоит из строчных и прописных английских букв, пробелов и цифр от 1 до 9.
        Количество слов в s находится между 1 и 9.
        Слова в s разделяются одним пробелом.
        s не содержит начальных или завершающих пробелов.
    https://leetcode.com/problems/sorting-the-sentence/description/
     */
    public class Task1859 : InfoBasicTask
    {
        public Task1859(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string initialString = "is2 sentence4 This1 a3";
            Console.WriteLine($"Исходная строка: \"{initialString}\"");
            string result = sortSentence(initialString);
            Console.WriteLine($"Результирующая строка: \"{result}\"");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string sortSentence(string s)
        {
            string[] words = s.Split(' ');
            string[] sortedWords = new string[words.Length];
            for (int i = 0; i < words.Length; i++)
            {
                int index = words[i][words[i].Length - 1] - '0';
                string subString = words[i].Substring(0, words[i].Length-1);
                sortedWords[index-1] = subString;
            }
            return String.Join(" ", sortedWords);
        }
    }
}
