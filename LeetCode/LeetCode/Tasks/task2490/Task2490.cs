using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2490
{
    /*
     2490. Круговое предложение
    Предложение — это список слов, разделённых одним пробелом без пробелов в начале или в конце.
        Например, "Hello World", "HELLO", "hello world hello world" — все это предложения.
    Слова состоят из только прописных и строчных английских букв. Прописные и строчные английские буквы считаются разными.
    Предложение является круговым если:
        Последний символ каждого слова в предложении совпадает с первым символом следующего за ним слова.
        Последний символ последнего слова равен первому символу первого слова.
    Например, "leetcode exercises sound delightful" "eetcode", "leetcode eats soul" все эти предложения являются замкнутыми. Однако, "Leetcode is cool" "happy Leetcode", "Leetcode" и "I like Leetcode" не являются замкнутыми предложениями.
    Если дана строка sentence, верните true, если она замкнутая. В противном случае верните false.
    Ограничения:
        1 <= sentence.length <= 500
        sentence состоит только из строчных и прописных английских букв и пробелов.
        Слова в sentence разделяются одним пробелом.
        Здесь нет начальных или завершающих пробелов.
    https://leetcode.com/problems/circular-sentence/description/
     */
    public class Task2490 : InfoBasicTask
    {
        public Task2490(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string sentence = "leetcode exercises sound delightful";
            Console.WriteLine($"Исходная строка: \"{sentence}\"");
            if (isValid(sentence))
            {
                Console.WriteLine(isCircularSentence(sentence) ? "Исходное предложение является круговым" : "Исходное предложение не является круговым");
            }
            else
            {
                Console.WriteLine("Исходные данные не валидны!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(string sentence)
        {
            if (sentence.Length < 1 || sentence.Length > 500)
            {
                return false;
            }
            int countWhiteSpaces = 0;
            foreach (var c in sentence) {
                if (c==' ')
                {
                    countWhiteSpaces += 1;
                }
                if (!(char.IsLetter(c) && (c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z') || c == ' '))
                {
                    return false;
                }
            }
            if (sentence.StartsWith(" ") || sentence.EndsWith(" "))
            {
                return false;
            }
            string[] words = sentence.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (countWhiteSpaces != words.Length - 1)
            {
                return false;
            }
            return true;
        }
        private bool isCircularSentence(string sentence)
        {
            string[] words = sentence.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                char lastCharOfCurrentWord = words[i][words[i].Length - 1];
                char firstCharOfNextWord = ' ';
                if (i == words.Length - 1)
                {
                    firstCharOfNextWord = words[0][0];
                }
                else
                {
                    firstCharOfNextWord = words[i+1][0];
                }
                if (lastCharOfCurrentWord != firstCharOfNextWord)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
