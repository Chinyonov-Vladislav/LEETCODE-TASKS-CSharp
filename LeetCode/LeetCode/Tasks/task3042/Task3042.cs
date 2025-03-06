using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3042
{
    /*
     3042. Подсчитайте количество пар префиксов и суффиксов I
    Вам будет предоставлен строковый массив с индексом 0words.
    Давайте определим логическую функцию isPrefixAndSuffix для двух строк, str1 и str2:
        isPrefixAndSuffix(str1, str2) возвращает true если str1 является и префиксом, и суффиксом str2 и false в противном случае.
    Например, isPrefixAndSuffix("aba", "ababa") — это true, потому что "aba" является префиксом "ababa" и суффиксом, но isPrefixAndSuffix("abc", "abcd") — это false.
    Верните целое число, обозначающее количество пар индексов, (i, j)таких что i < j, и isPrefixAndSuffix(words[i], words[j]) равно true.
    Ограничения:
        1 <= words.length <= 50
        1 <= words[i].length <= 10
        words[i] состоит только из строчных английских букв.
    https://leetcode.com/problems/count-prefix-and-suffix-pairs-i/description/
     */
    public class Task3042 : InfoBasicTask
    {
        public Task3042(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] words = new string[] { "a", "aba", "ababa", "aa" };
            printArray(words);
            if (isValid(words))
            {
                int count = countPrefixSuffixPairs(words);
                Console.WriteLine($"Количество пар индексов, где i<j и элемент массива под индексом i является суффиксом и префиксом для строки под индексом j = {count}");
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
            if (words.Length < 1 || words.Length > 50)
            {
                return false;
            }
            foreach (string word in words) {
                if (word.Length < 1 || word.Length > 10)
                {
                    return false;
                }
                foreach (char c in word)
                {
                    if (c < 'a' || c > 'z')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private int countPrefixSuffixPairs(string[] words)
        {
            int count = 0;
            for (int i = 0; i < words.Length - 1; i++)
            {
                for (int j = i + 1; j < words.Length; j++)
                {
                    if (words[j].StartsWith(words[i]) && words[j].EndsWith(words[i]))
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
