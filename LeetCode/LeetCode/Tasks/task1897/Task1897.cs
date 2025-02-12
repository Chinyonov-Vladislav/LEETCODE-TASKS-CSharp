using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1897
{
    /*
     1897. Перераспределите символы, чтобы сделать все строки равными
    Вам будет предоставлен массив строк words (с индексом 0).
    За одну операцию выберите два разных индекса i и j, где words[i] — непустая строка, и переместите любой символ из words[i] в любую позицию в words[j].
    Верните true если вы можете сделать каждую строку в words равной используя любое количество операций, и false в противном случае.
    https://leetcode.com/problems/redistribute-characters-to-make-all-strings-equal/description/
     */
    public class Task1897 : InfoBasicTask
    {
        public Task1897(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] words = new string[] { "abc", "aabc", "bc" };
            printArray(words, "Исходный массив слов: ");
            Console.WriteLine(makeEqual(words) ? "Используя любое количество операций, возможно сделать строки в массиве words одинаковыми" : "Невозможно сделать строки в массиве words одинаковыми");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool makeEqual(string[] words)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < words[i].Length; j++)
                {
                    if (dict.ContainsKey(words[i][j]))
                    {
                        dict[words[i][j]]++;
                    }
                    else
                    {
                        dict.Add(words[i][j], 1);
                    }
                }
            }
            foreach (var pair in dict)
            {
                if (pair.Value % words.Length != 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
