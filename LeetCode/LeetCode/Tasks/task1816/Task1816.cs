using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1816
{
    /*
     1816. Усечь предложение
    Предложение — это список слов, разделённых одним пробелом без начальных и конечных пробелов. Каждое из слов состоит только из прописных и строчных букв английского алфавита (без знаков препинания).
    Например, "Hello World", "HELLO" и "hello world hello world" - это все предложения.
    Вам дано предложение s​​​​​​ и целое число k​​​​​​. Вы хотите сократить s​​​​​​ его так, чтобы оно содержало только первые k​​​​​​ слова. Верните s​​​​​​ после сокращения его.
    https://leetcode.com/problems/truncate-sentence/description/
     */
    public class Task1816 : InfoBasicTask
    {
        public Task1816(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = "Hello how are you Contestant";
            Console.WriteLine($"Исходная строка: \"{str}\"");
            int k = 4;
            Console.WriteLine($"Количество слов в новой строке из исходной = {k}");
            string result = truncateSentence(str, k);
            Console.WriteLine($"Результирующая строка: \"{result}\"");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string truncateSentence(string s, int k)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string[] words = s.Split(' ');
            for (int i = 0; i < k; i++)
            {
                stringBuilder.Append(words[i]);
                if (i != k - 1)
                {
                    stringBuilder.Append(" ");
                }
            }
            return stringBuilder.ToString();
        }
    }
}
