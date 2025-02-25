using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2114
{
    /*
     2114. Максимальное количество слов, встречающихся в предложениях
    Предложение — это список слов, разделённых одним пробелом без пробелов в начале или в конце.
    Вам дан массив строк sentences, где каждая sentences[i] представляет собой отдельное предложение.
    Верните значение максимального количества слов, которые встречаются в одном предложении.
    https://leetcode.com/problems/maximum-number-of-words-found-in-sentences/description/
     */
    public class Task2114 : InfoBasicTask
    {
        public Task2114(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] sentences = new string[] { "alice and bob love leetcode", "i think so too", "this is great thanks very much" };
            printArray(sentences, "Массив предложений: ");
            int max = mostWordsFound(sentences);
            Console.WriteLine($"Максимальное количество слов в одном предложении = {max}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int mostWordsFound(string[] sentences)
        {
            int max = 0;
            foreach (string sentence in sentences)
            {
                string[] words = sentence.Split(' ');
                if (words.Length > max)
                {
                    max = words.Length;
                }
            }
            return max;
        }
    }
}
