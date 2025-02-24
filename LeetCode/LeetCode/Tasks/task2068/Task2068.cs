using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2068
{
    /*
     2068. Проверьте, являются ли две строки почти эквивалентными
    Две строки word1 и word2 считаются почти эквивалентными, если разница между частотами каждой буквы от 'a' до 'z' в word1 и word2 составляет не более 3.
    Даны две строки word1 и word2, каждая длиной n, верните true если word1 и word2 они почти эквивалентны, то false иначе.
    Частота появления буквы x — это количество раз, которое она встречается в строке.
    https://leetcode.com/problems/check-whether-two-strings-are-almost-equivalent/description/
     */
    public class Task2068 : InfoBasicTask
    {
        public Task2068(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str1 = "abcdeef";
            string str2 = "abaaacc";
            Console.WriteLine($"Исходное слово №1: \"{str1}\"");
            Console.WriteLine($"Исходное слово №2: \"{str2}\"");
            Console.WriteLine(checkAlmostEquivalent(str1,str2) ? "Исходное слово №1 и №2 почти идентичны" : "Исходное слово №1 и №2 не идентичны");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool checkAlmostEquivalent(string word1, string word2)
        {
            Dictionary<char,int> charsFreq = new Dictionary<char,int>();
            for (int i = 0; i < word1.Length; i++)
            {
                if (charsFreq.ContainsKey(word1[i]))
                {
                    charsFreq[word1[i]]++;
                }
                else
                {
                    charsFreq.Add(word1[i],1);
                }
            }
            HashSet<char> newAddedChars = new HashSet<char>();
            for (int i = 0; i < word2.Length; i++)
            {
                if (charsFreq.ContainsKey(word2[i]) && !newAddedChars.Contains(word2[i]))
                {
                    charsFreq[word2[i]]--;
                }
                else if (charsFreq.ContainsKey(word2[i]) && newAddedChars.Contains(word2[i]))
                {
                    charsFreq[word2[i]]++;
                }
                else
                {
                    newAddedChars.Add(word2[i]);
                    charsFreq.Add(word2[i], 1);
                }
            }
            foreach (var pair in charsFreq)
            {
                if (pair.Value > 3 || pair.Value < -3)
                {
                    return false;
                }
            }
            return true;
        }
        //скопировано с leetcode
        private bool bestSolution(string word1, string word2)
        {
            // Create two frequency arrays for letters 'a' to 'z'
            int[] freq1 = new int[26];
            int[] freq2 = new int[26];

            // Count frequencies for word1
            foreach (char c in word1)
            {
                freq1[c - 'a']++;
            }

            // Count frequencies for word2
            foreach (char c in word2)
            {
                freq2[c - 'a']++;
            }

            // Compare frequencies for each letter
            for (int i = 0; i < 26; i++)
            {
                if (Math.Abs(freq1[i] - freq2[i]) > 3)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
