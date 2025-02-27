using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2287
{
    /*
     2287. Измените порядок символов, чтобы получилась целевая строка
    Вам даны две строки с нулевым индексом s и target. Вы можете взять несколько букв из s и переставить их, чтобы сформировать новые строки.
    Верните максимальное количество копий target , которые можно получить, взяв буквы из s и переставив их.
    https://leetcode.com/problems/rearrange-characters-to-make-target-string/description/
     */
    public class Task2287 : InfoBasicTask
    {
        public Task2287(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string initialTarget = "ilovecodingonleetcode";
            string target = "code";
            Console.WriteLine($"Исходная строка: \"{initialTarget}\"");
            Console.WriteLine($"Целевая строка: \"{target}\"");
            int count = rearrangeCharacters(initialTarget, target);
            Console.WriteLine($"Максимальное количество копий целевой строки , которые можно получить, взяв буквы из исходной строки и переставив их = {count}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int rearrangeCharacters(string s, string target)
        {
            Dictionary<char, int> dictInitialString = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (dictInitialString.ContainsKey(c))
                {
                    dictInitialString[c]++;
                }
                else
                {
                    dictInitialString.Add(c, 1);
                }
            }
            Dictionary<char, int> dictTargetString = new Dictionary<char, int>();
            foreach (char c in target)
            {
                if (dictTargetString.ContainsKey(c))
                {
                    dictTargetString[c]++;
                }
                else
                {
                    dictTargetString.Add(c, 1);
                }
            }
            int count = Int32.MaxValue;
            foreach (var pair in dictTargetString)
            {
                if (!dictInitialString.ContainsKey(pair.Key))
                {
                    count = 0;
                    break;
                }
                else
                {
                    int countByLetter = dictInitialString[pair.Key] / pair.Value;
                    if (countByLetter < count)
                    {
                        count = countByLetter;
                    }
                }
            }
            return count;
        }
    }
}
