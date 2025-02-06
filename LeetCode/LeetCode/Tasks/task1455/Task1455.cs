using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1455
{
    /*
     1455. Проверьте, является ли слово приставкой какого-либо слова в предложении
    Учитывая sentence , состоящее из нескольких слов, разделённых одним пробелом, и searchWord, проверьте, является ли searchWord префиксом какого-либо слова в sentence.
    Верните индекс слова в sentence (с 1-индексированием), где searchWord является префиксом этого слова. Если searchWord является префиксом более чем одного слова, верните индекс первого слова (минимальный индекс). Если такого слова нет, верните -1.
    Префиксом строки s является любая начальная непрерывная подстрока s.
     https://leetcode.com/problems/check-if-a-word-occurs-as-a-prefix-of-any-word-in-a-sentence/description/
     */
    public class Task1455 : InfoBasicTask
    {
        public Task1455(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string sentence = "this problem is an easy problem";
            string searchWord = "pro";
            Console.WriteLine($"Исходное предложение: \"{sentence}\"");
            Console.WriteLine($"Искомый префикс: \"{searchWord}\"");
            int minIndex = isPrefixOfWord(sentence, searchWord);
            Console.WriteLine(minIndex == -1 ? "В исходном предложении нет слова с искомым префиксом" : $"Первое слово с искомым префиксом в исходном предложении находится под индексом = {minIndex} (индексация с 1)");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int isPrefixOfWord(string sentence, string searchWord)
        {
            int index = -1;
            string[] words = sentence.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].StartsWith(searchWord))
                {
                    index = i+1;
                    break;
                }
            }
            return index;
        }
    }
}
