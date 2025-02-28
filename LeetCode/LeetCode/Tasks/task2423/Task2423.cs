using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2423
{
    /*
     2423. Удалите букву, чтобы выровнять частоту
    Вам дана строка с нулевой индексацией word, состоящая из строчных букв английского алфавита. Вам нужно выбрать один индекс и удалить букву с этим индексом из word так, чтобы частота появления каждой буквы в word была одинаковой.
    Верните true если можно удалить одну букву так, чтобы частота встречаемости всех букв в word была одинаковой, и false в противном случае.
        Примечание:
        Частота появления буквы x — это количество раз, которое она встречается в строке.
        Вы должны удалить ровно одну букву и не можете ничего не делать.
    Ограничения:
    2 <= word.length <= 100
    word состоит только из строчных английских букв.
    https://leetcode.com/problems/remove-letter-to-equalize-frequency/description/
     */
    public class Task2423 : InfoBasicTask
    {
        public Task2423(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string word = "abcc";
            Console.WriteLine($"Исходная строка: \"{word}\"");
            if (isValid(word))
            {
                Console.WriteLine(equalFrequency(word) ? "Можно удалить одну букву так, чтобы частота встречаемости всех букв в word была одинаковой" : "Нельзя удалить одну букву так, чтобы частота встречаемости всех букв в word была одинаковой");
            }
            else
            {
                Console.WriteLine("Не валидные исходные данные!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(string word)
        {
            if (word.Length < 2 || word.Length > 100)
            {
                return false;
            }
            foreach (char letter in word)
            {
                if (!char.IsLetter(letter))
                {
                    return false;
                }
            }
            return true;
        }
        private bool equalFrequency(string word)
        {
            int[] freq = new int[26];
            foreach (char c in word)
            {
                freq[c - 'a']++;
            }
            for (int i = 0; i < freq.Length; i++)
            {
                if (freq[i] != 0)
                {
                    freq[i]--;
                    HashSet<int> set = new HashSet<int>();
                    for (int j = 0; j < freq.Length; j++)
                    {
                        if (freq[j] != 0)
                        {
                            set.Add(freq[j]);
                        }
                    }
                    if (set.Count == 1)
                    {
                        return true;
                    }
                    else
                    {
                        freq[i]++;
                    }
                }
            }
            return false;
        }
    }
}
