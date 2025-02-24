using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2085
{
    /*
     2085. Подсчитайте распространенные слова с одним вхождением
    Учитывая два массива строк words1 и words2, верните количество строк, которые встречаютсяровно один раз в каждом из двух массивов.
    https://leetcode.com/problems/count-common-words-with-one-occurrence/description/
     */
    public class Task2085 : InfoBasicTask
    {
        public Task2085(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] words1 = new string[] { "leetcode", "is", "amazing", "as", "is" };
            string[] words2 = new string[] { "amazing", "leetcode", "is" };
            printArray(words1, "Массив строк №1: ");
            printArray(words2, "Массив строк №2: ");
            int count = countWords(words1, words2);
            Console.WriteLine($"Количество слов, которые встречаются в обеих массивах ровно 1 раз = {count}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int countWords(string[] words1, string[] words2)
        {
            int count = 0;
            Dictionary<string, int> dictFreqFromWords1 = new Dictionary<string, int>();
            Dictionary<string, int> dictFreqFromWords2 = new Dictionary<string, int>();
            foreach (var item in words1)
            {
                if (dictFreqFromWords1.ContainsKey(item))
                {
                    dictFreqFromWords1[item]++;
                }
                else
                {
                    dictFreqFromWords1.Add(item, 1);
                }
            }
            foreach (var item in words2)
            {
                if (dictFreqFromWords2.ContainsKey(item))
                {
                    dictFreqFromWords2[item]++;
                }
                else
                {
                    dictFreqFromWords2.Add(item, 1);
                }
            }
            foreach (var item in dictFreqFromWords1)
            {
                if (item.Value == 1 && dictFreqFromWords2.ContainsKey(item.Key) && dictFreqFromWords2[item.Key] == 1)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
