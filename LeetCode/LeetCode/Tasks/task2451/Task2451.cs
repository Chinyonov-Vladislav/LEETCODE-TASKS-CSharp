using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2451
{
    /*
     2451. Разница в нечетных строках
    Вам дан массив строк одинаковой длины words. Предположим, что длина каждой строки равна n.
    Каждая строка words[i] может быть преобразована в целый массив разностей difference[i] длиной n - 1 где difference[i][j] = words[i][j+1] - words[i][j] где 0 <= j <= n - 2. 
    Обратите внимание, что разница между двумя буквами — это разница между их положениями в алфавите, то есть позиция 'a' — 0, 'b' — 1, а 'z' — 25.
    Например, для строки "acb" разностный целочисленный массив равен [2 - 0, 1 - 2] = [2, -1]
    Все строки в словах имеют одинаковый целочисленный массив различий, кроме одной. Вам нужно найти эту строку.
    Верните строку в words, в которой есть разница в целочисленном массиве.
    Ограничения:
        3 <= words.length <= 100
        n == words[i].length
        2 <= n <= 20
        words[i] состоит из строчных английских букв.
    https://leetcode.com/problems/odd-string-difference/description/
     */
    public class Task2451 : InfoBasicTask
    {
        public Task2451(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] words = new string[] { "adc", "wzy", "abc" };
            printArray(words);
            if (isValid(words))
            {
                string word = oddString(words);
                Console.WriteLine($"Результат: \"{word}\"");
            }
            else
            {
                Console.WriteLine("Невалидные исходные данные!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(string[] words)
        {
            if (words.Length < 3 || words.Length > 100)
            {
                return false;
            }
            int size = words[0].Length;
            for (int i = 1; i < words.Length; i++)
            {
                if (words[i].Length != size)
                {
                    return false;
                }
            }
            if (size < 2 || size > 20)
            {
                return false;
            }
            foreach (string word in words) {
                for (int i = 0; i < word.Length; i++)
                {
                    if (!char.IsLetter(word[i]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private string oddString(string[] words)
        {
            List<List<int>> res = new List<List<int>>();
            foreach (string word in words)
            {
                res.Add(new List<int>());
                for (int i = 0; i < word.Length - 1; i++)
                {
                    int valueFirstChar = word[i] - 'a';
                    int valueSecondChar = word[i + 1] - 'a';
                    int diff = valueSecondChar - valueFirstChar;
                    res[res.Count - 1].Add(diff);
                }
            }
            if (res[0].SequenceEqual(res[1]))
            {
                for (int i = 2; i < res.Count; i++)
                {
                    if (!res[i].SequenceEqual(res[0]))
                    {
                        return words[i];
                    }
                }
            }
            if (res[0].SequenceEqual(res[2]))
            {
                return words[1];
            }
            else
            {
                return words[0];
            }
        }
    }
}
