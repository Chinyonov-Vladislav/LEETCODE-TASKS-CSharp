using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2744
{
    /*
     2744. Найдите максимальное количество пар строк
    Вам дан массив с нулевой индексацией words, состоящий из различных строк.
    Строка words[i] может быть сопряжена со строкой words[j] , если:
            Строка words[i] равна перевернутой строке из words[j].
            0 <= i < j < words.length.
    Верните максимальноеколичествопар, которые можно составить из массива words.
    Обратите внимание, что каждая строка может принадлежать не более чем одной паре.
     */
    public class Task2744 : InfoBasicTask
    {
        public Task2744(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] words = new string[] { "cd", "ac", "dc", "ca", "zz" };
            printArray(words);
            if (isValid(words))
            {
                int countPair = maximumNumberOfStringPairs(words);
                Console.WriteLine($"Максимальное количество пар = {countPair}");
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
        private bool isValid(string[] words)
        {
            if (words.Length < 1 || words.Length > 50)
            {
                return false;
            }
            foreach (string word in words) {
                if (word.Length != 2)
                {
                    return false;
                }
                foreach (char ch in word)
                {
                    if (ch < 'a' || ch > 'z')
                    {
                        return false;
                    }
                }
            }
            HashSet<string> result = new HashSet<string>(words);
            if (result.Count() != words.Length)
            {
                return false;
            }
            return true;
        }
        private int maximumNumberOfStringPairs(string[] words)
        {
            int count = 0;
            for (int i = 0; i < words.Length - 1; i++)
            {
                for (int j = i + 1; j < words.Length; j++)
                {
                    if (words[j][0] == words[i][1] && words[j][1] == words[i][0])
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
