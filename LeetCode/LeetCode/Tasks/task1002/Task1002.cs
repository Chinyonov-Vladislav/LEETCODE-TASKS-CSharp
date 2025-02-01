using LeetCode.Basic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1002
{
    /*
     1002. Найти общие символы
    Учитывая массив строк words, верните массив всех символов, которые встречаются во всех строках в words (включая дубликаты). Вы можете вернуть ответ в любом порядке.
     https://leetcode.com/problems/find-common-characters/description/
     */
    public class Task1002 : InfoBasicTask
    {
        public Task1002(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] array = new string[] { "bella", "label", "roller" };
            printArray(array, "Массив строк: ");
            IList<string> commonCharsList = commonChars(array);
            printIListString(commonCharsList, "Общие символы во всех строках: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private IList<string> commonChars(string[] words)
        {
            IList<string> result = new List<string>();
            foreach (var c in words[0])
            {
                if (!result.Contains(c.ToString()))
                {
                    List<int> countCharInEveryWord = new List<int>();
                    for (int i = 0; i < words.Length; i++)
                    {
                        int countLetterInCurrentWord = words[i].Where(p => p == c).Count();
                        countCharInEveryWord.Add(countLetterInCurrentWord);
                    }
                    int minCount = countCharInEveryWord.Min();
                    for (int i = 0; i < minCount; i++)
                    {
                        result.Add(c.ToString());
                    }
                }
            }
            return result;
        }
        private IList<string> bestSolution(string[] words)
        {
            // Initialize frequency for first word
            int[] minFreq = new int[26]; // Frequency array for 'a' to 'z'
            foreach (char c in words[0])
            {
                minFreq[c - 'a']++;
            }

            // Compare with other words
            for (int i = 1; i < words.Length; i++)
            {
                int[] charCount = new int[26]; // Frequency for current word
                foreach (char c in words[i])
                {
                    charCount[c - 'a']++;
                }

                // Update min frequency count for each character
                for (int j = 0; j < 26; j++)
                {
                    minFreq[j] = Math.Min(minFreq[j], charCount[j]);
                }
            }

            // Collect the common characters
            List<string> result = new List<string>();
            for (int i = 0; i < 26; i++)
            {
                while (minFreq[i] > 0)
                {
                    result.Add(((char)(i + 'a')).ToString());
                    minFreq[i]--;
                }
            }

            return result;
        }
    }
}
